﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public class Art
    {
        private int _ArtID;
        private string _ArtTitle;
        private string _ArtDescription;
        private string _SellingOption;
        private double _Price;
        private int _photocnt;
        private List<string> _artPhotos = new List<string>(); // Stores photo file paths for simplicity.
        private string _creator;

        public string Creator {
            get {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        string query = "SELECT UserName FROM ArtArtist WHERE ArtId = @ArtID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        connection.Open();
                        _creator = command.ExecuteScalar()?.ToString();
                    }
                    return _creator;

                }
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING CREATOR OF ART: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING CREATOR OF ART: " + e.Message);
                    return null;
                }
               
            }
            set {
                _creator = value;
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        string query = "UPDATE ArtArtist SET UserName = @UserName WHERE ArtId = @ArtID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@UserName", _creator);
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }


                }
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING CREATOR OF ART: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING CREATOR OF ART: " + e.Message);
                    return;
                }
               
            }
        }
        // Constructor for loading existing Art by ArtID
        public Art() { }
        public List<string> artPhotos { get {
                return _artPhotos;
            } }
        public Art(int artID)
        {
            _ArtID = artID;
            LoadArtPhotos();
            //LoadArtDetails(); // Load the art details (and photos) from DB
        }

        /// <summary>
        /// Constructor to create a new art piece and save it to the database.
        /// </summary>
        public Art(string artTitle, string artDescription, string sellingOption, double price, List<string> photoPaths)
        {
            _ArtTitle = artTitle;
            _ArtDescription = artDescription;
            _SellingOption = sellingOption;
            _Price = price;
            _photocnt = photoPaths.Count;



            // Insert the new art into the database
            string insertArtQuery = @"
                INSERT INTO Art (ArtTitle, ArtDescription, SellingOption, Price, photocnt)
                OUTPUT INSERTED.ArtId
                VALUES (@ArtTitle, @ArtDescription, @SellingOption, @Price, @PhotoCount)";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();

                    // Insert art and get the generated ArtID
                    using (SqlCommand command = new SqlCommand(insertArtQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ArtTitle", _ArtTitle);
                        command.Parameters.AddWithValue("@ArtDescription", _ArtDescription);
                        command.Parameters.AddWithValue("@SellingOption", _SellingOption);
                        command.Parameters.AddWithValue("@Price", _Price);
                        command.Parameters.AddWithValue("@PhotoCount", _photocnt);

                        // Retrieve the newly generated ArtID
                        _ArtID = Int32.Parse(command.ExecuteScalar().ToString());
                    }

                    // Add photos to the ArtPhotos table
                    foreach (string photoPath in photoPaths)
                    {
                        AddArtPhoto(photoPath);
                    }

                    // Store the photo paths in the local list
                    _artPhotos.AddRange(photoPaths);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error creating new art: {ex.Message}");
                }
            }
        }

        public int ArtID => _ArtID;

        public string ArtTitle {
            get => LoadValue("ArtTitle", ref _ArtTitle);
            set => UpdateValue("ArtTitle", value);
        }

        public string ArtDescription {
            get => LoadValue("ArtDescription", ref _ArtDescription);
            set => UpdateValue("ArtDescription", value);
        }

        public string SellingOption {
            get => LoadValue("SellingOption", ref _SellingOption);
            set => UpdateValue("SellingOption", value);
        }

        public double Price {
            get => LoadValue("Price", ref _Price);
            set => UpdateValue("Price", value);
        }

        public int PhotoCount {
            get => LoadValue("photocnt", ref _photocnt);
            set => UpdateValue("photocnt", value);
        }

        public List<string> ArtPhotos => _artPhotos;

        /// <summary>
        /// Loads a single value from the database for the given column name.
        /// </summary>
        private T LoadValue<T>(string columnName, ref T field)
        {
            string query = $"SELECT {columnName} FROM Art WHERE ArtId = @ArtID";
            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        object result = command.ExecuteScalar();
                        if (result != null && !(result is DBNull))
                        {
                            field = (T)Convert.ChangeType(result, typeof(T));
                        }
                        return field;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {columnName}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates a value in the database for the given column name.
        /// </summary>
        private void UpdateValue<T>(string columnName, T value)
        {
            string query = $"UPDATE Art SET {columnName} = @Value WHERE ArtId = @ArtID";
            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Value", value);
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating {columnName}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Loads all photos associated with the art piece from the ArtPhotos table.
        /// </summary>
        private void LoadArtDetails()
        {
            string query = "SELECT ArtTitle, ArtDescription, SellingOption, Price, photocnt FROM Art WHERE ArtId = @ArtID";
            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _ArtTitle = reader["ArtTitle"].ToString();
                                _ArtDescription = reader["ArtDescription"].ToString();
                                _SellingOption = reader["SellingOption"].ToString();
                                _Price = Convert.ToDouble(reader["Price"]);
                                _photocnt = Convert.ToInt32(reader["photocnt"]);
                            }
                        }
                    }

                    // Load all photos associated with the art
                    LoadArtPhotos();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading art details: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Loads all photos associated with the art piece from the ArtPhotos table.
        /// </summary>
        public void LoadArtPhotos()
        {
            string query = "SELECT Photo FROM ArtPhotos WHERE ArtId = @ArtID";
            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            _artPhotos.Clear();
                            while (reader.Read())
                            {
                                if (reader["Photo"] != DBNull.Value)
                                {
                                    _artPhotos.Add(reader["Photo"].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading art photos: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Adds a new photo for the art piece to the ArtPhotos table by taking a file path.
        /// </summary>
        public void AddArtPhoto(string photoPath)
        {
            string query = "INSERT INTO ArtPhotos (ArtId, Photo) VALUES (@ArtID, @Photo)";
            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        command.Parameters.AddWithValue("@Photo", photoPath); // Save the file path as a string.
                        command.ExecuteNonQuery();
                        _artPhotos.Add(photoPath);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding art photo: {ex.Message}");
                }
            }
        }
        public void RemoveArtPhoto(string photoPath)
        {
            string query = "DELETE FROM ArtPhotos WHERE ArtId = @ArtID AND Photo = @Photo";
            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtID", _ArtID);
                        command.Parameters.AddWithValue("@Photo", photoPath); // Use the photo path to delete
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            _artPhotos.Remove(photoPath); // Remove from the list after deletion
                            MessageBox.Show("Art photo removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No matching photo found to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error removing art photo: {ex.Message}");
                }
            }
        }
        public bool isSold()
        {
            string q = $"select count(*) from ArtSold " +
                $"where " +
                $"artid = '{this.ArtID}'";
            SqlConnection con = DB.Connect();
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            if ((int)cmd.ExecuteScalar() > 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Displays the art details and its associated photos.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Art ID: {_ArtID}");
            Console.WriteLine($"Title: {ArtTitle}");
            Console.WriteLine($"Description: {ArtDescription}");
            Console.WriteLine($"Selling Option: {SellingOption}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Photo Count: {PhotoCount}");
            Console.WriteLine("Photos:");
            foreach (var photoPath in _artPhotos)
            {
                Console.WriteLine($"  - {photoPath}");
            }
        }
    }
}
