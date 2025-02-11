﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using System.Reflection;
using FrameSphere.FormsEvents;

namespace FrameSphere
{
    public partial class ManageEvents : Form
    {
        public Event ev;
        private string _status;

        public ManageEvents(int eventId)
        {
            InitializeComponent();
            this.ev = new Event(eventId);
            if (!FSystem.loggedInUser.isAdmin)
            {
                reject.Visible = false;
                approve.Visible = false;
            }
            if (!isAdminOrOrganizer())
            {
                
                delete.Visible = false;
            }

            // DateTime picker formatting
            startdate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            enddate.CustomFormat = "MM/dd/yyyy hh:mm tt";

            // Load event data
            ev = new Event(eventId);
            eventTitle_field.Text = ev.EventTitle;
            eventDesc_field.Text = ev.EventDescription;
            startdate.Value = ev.StartsAt;
            enddate.Value = ev.EndsAt;
            OrgDetails_field.Text = ev.Organization;
            _status = ev.Status;  // Load existing status

            // Registration type setup
            if (ev.RegistrationType.ToLower() == "paid")
            {
                paid.Checked = true;
                free.Checked = false;
                ticketprice_field.Text = ev.TicketPrice.ToString();
                ticketprice_field.Show();
            }
            else
            {
                free.Checked = true;
                paid.Checked = false;
                ticketprice_field.Hide();
            }

            // Poster image setup
            poster_field.Text = ev.PosterImage;
            posterImage.Image = FSystem.GetImageFromPath(ev.PosterImage);
        }
        private bool isAdminOrOrganizer()
        {
            try
            {
                using (SqlConnection con = DB.Connect())
                {
                    con.Open();

                    // Check if the user is an admin
                    string adminQuery = "SELECT COUNT(*) FROM AdminList WHERE UserName = @username";
                    SqlCommand adminCmd = new SqlCommand(adminQuery, con);
                    adminCmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);

                    int isAdmin = Convert.ToInt32(adminCmd.ExecuteScalar());
                    if (isAdmin > 0)
                        return true; // User is an admin

                    // Check if the user is an organizer for this event
                    string organizerQuery = "SELECT COUNT(*) FROM Organizers WHERE UserName = @username AND EventID = @eventid";
                    SqlCommand organizerCmd = new SqlCommand(organizerQuery, con);
                    organizerCmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);
                    organizerCmd.Parameters.AddWithValue("@eventid", ev.EventID);

                    int isOrganizer = Convert.ToInt32(organizerCmd.ExecuteScalar());
                    return isOrganizer > 0;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("UNEXPECTED ERROR: " + e.Message);
                return false;
            }

        }

        #region Button Click Handlers
        private void approveButton_Click(object sender, EventArgs e)
        {
            
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void update_button_Click_1(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.CheckPassword(CurrentPWField.Text))
            {
                // Update event properties
                ev.EventTitle = eventTitle_field.Text;
                ev.EventDescription = eventDesc_field.Text;
                ev.StartsAt = startdate.Value;
                ev.EndsAt = enddate.Value;
                ev.Organization = OrgDetails_field.Text;
                ev.Status = _status;

                // Handle registration type
                if (free.Checked)
                {
                    ev.RegistrationType = "Free";
                    ev.TicketPrice = 0;
                }
                else if (paid.Checked)
                {
                    if (!int.TryParse(ticketprice_field.Text, out int price))
                    {
                        MessageBox.Show("Invalid ticket price format!");
                        return;
                    }
                    ev.RegistrationType = "Paid";
                    ev.TicketPrice = price;
                }

                // Handle image upload
                // Handle image upload only if changed
                if (!string.IsNullOrEmpty(poster_field.Text) && poster_field.Text != ev.PosterImage)
                {
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string eventPostersFolder = Path.Combine(baseDirectory, "EventPosters");
                    Directory.CreateDirectory(eventPostersFolder);

                    string fileName = Path.GetFileName(poster_field.Text);
                    string destinationPath = Path.Combine(eventPostersFolder, fileName);

                    try
                    {
                        if (!File.Exists(destinationPath) || poster_field.Text != destinationPath)
                        {
                            File.Copy(poster_field.Text, destinationPath, true);
                            ev.PosterImage = Path.Combine("EventPosters", fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}");
                        return;
                    }
                }


                // Save to database
                try
                {
                    ev.Save();
                    MessageBox.Show("Event updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid password!");
            }
        }

        private void posterbtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Event Poster"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                poster_field.Text = imagePath;
                posterImage.Image = Image.FromFile(imagePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.isAdmin)
            {
                Admin_dashboard a = new Admin_dashboard();
                a.Show();
                this.Hide();
            }
            else
            {
                UserEvents u1 = new UserEvents();
                this.Hide();
                u1.Show();
            }
        }

        private void participants_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageParticipants mn = new ManageParticipants(ev);
            mn.Show();
        }

        private void artCollections_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageArtCollection mn = new ManageArtCollection(ev);
            mn.Show();
        }
        #endregion

        #region Radio Button Handlers
        private void free_CheckedChanged(object sender, EventArgs e)
        {
            if (free.Checked) ticketprice_field.Hide();
        }

        private void paid_CheckedChanged(object sender, EventArgs e)
        {
            if (paid.Checked) ticketprice_field.Show();
        }
        #endregion

        private void reject_Click(object sender, EventArgs e)
        {
            _status = "Rejected";
            MessageBox.Show("Status set to Rejected. Click Update to save changes.");
        }

        private void approve_Click(object sender, EventArgs e)
        {
            _status = "Approved";
            MessageBox.Show("Status set to Approved. Click Update to save changes.");
        }

        private void manageOrganizer_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageOrganizer org = new ManageOrganizer(ev);
            org.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this event? All related data will be permanently removed.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        MessageBox.Show($"Deleting Event ID: {ev.EventID}");

                        string[] tables = { "Organizers", "ArtistEvent", "ArtEvent", "UserEvent", "Events" };

                        foreach (string table in tables)
                        {
                            string query = $@"
                                IF EXISTS (SELECT 1 FROM {table} WHERE EventID = @EventId)
                                BEGIN
                                    DELETE FROM {table} WHERE EventID = @EventId
                                END";

                            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@EventId", ev.EventID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //if (!string.IsNullOrEmpty(ev.PosterImage))
                        //{
                        //    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        //    string eventPostersFolder = Path.Combine(baseDirectory, "EventPosters");
                        //    string fileName = Path.GetFileName(ev.PosterImage);
                        //    string fullPath = Path.Combine(eventPostersFolder, fileName);

                        //    if (File.Exists(fullPath))
                        //    {
                        //        try
                        //        {
                        //            File.Delete(fullPath);
                        //        }
                        //        catch (IOException ioEx)
                        //        {
                        //            MessageBox.Show($"Warning: Could not delete image. {ioEx.Message}");
                        //        }
                        //    }
                        //}

                        transaction.Commit();
                        MessageBox.Show("Event deleted successfully.");

                        Form dashboard = FSystem.loggedInUser.isAdmin ? new Admin_dashboard() : new UserEvents();
                        dashboard.Show();
                        this.Close();
                    }
                    catch (SqlException sqlEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"SQL Error: {sqlEx.Message}\nError Code: {sqlEx.Number}", "Database Error");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Deletion Failed");
                    }
                }
            }
        }

    }


}