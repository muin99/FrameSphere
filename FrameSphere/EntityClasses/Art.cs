using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere.EntityClasses
{
    public class Art
    {
        private string _ArtID;
        private string _ArtTitle;
        private string _ArtDescription;
        private string _SellingOption;
        private double _Price;

        public Art(string artID) { this._ArtID = artID; }
        public string ArtID { get { return _ArtID; } }
        public string ArtTitle {
            get {
                string query = $"SELECT ArtTitle FROM Art WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _ArtTitle = (string)command.ExecuteScalar();
                            return _ArtTitle;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Art SET ArtTitle = '{value}' WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
        }

        public string ArtDescription {
            get {
                string query = $"SELECT ArtDescription FROM Art WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _ArtDescription = (string)command.ExecuteScalar();
                            return _ArtDescription;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Art SET ArtDescription = '{value}' WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
        }

        public string SellingOption {
            get {
                string query = $"SELECT SellingOption FROM Art WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _SellingOption = (string)command.ExecuteScalar();
                            return _SellingOption;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Art SET SellingOption = '{value}' WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
        }

        public double Price {
            get {
                string query = $"SELECT Price FROM Art WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _ArtTitle = (string)command.ExecuteScalar();
                            return _Price;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Art SET Price = '{value}' WHERE ArtId = '{ArtID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading user data: {ex.Message}");
                    }
                }
            }
        }

        public void Display()
        {

        }

    }
}
