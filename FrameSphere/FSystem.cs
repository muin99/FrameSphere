using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameSphere.EntityClasses;
using System.Drawing;
using Newtonsoft.Json;
using FrameSphere.D3Program;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.DirectoryServices;

namespace FrameSphere
{
    internal static class FSystem
    {
        public static int TotalUsers { get; private set; } = 0;
        public static int TotalArtists { get; private set; } = 0;
        public static int TotalAdmins { get; private set; } = 0;
        public static int TotalEvents { get; private set; } = 0;

        public static List<User> AllUsers = new List<User>();
        public static List<Artist> AllArtists = new List<Artist>();
        public static List<User> Admins = new List<User>();
        public static List<Event> AllEvents = new List<Event>();
        public static User loggedInUser;



        public static Image GetImageFromPath(string relativePath)
        {
            try
            {
                // Combine the application's base directory with the relative path
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(baseDirectory, relativePath);

                // Check if the file exists
                if (File.Exists(fullPath))
                {
                    return Image.FromFile(fullPath); // Return the image
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image from path: {ex.Message}");
            }

            // If the file doesn't exist or an error occurs, return a default image
            return Properties.Resources.defaultProfilePic; // Ensure this default image is added to resources
        }
        public static string GetPathFromRelative(string relativePath)
        {
            try
            {
                // Combine the application's base directory with the relative path
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(baseDirectory, relativePath);

                // Check if the file exists
                if (File.Exists(fullPath))
                {
                    return fullPath; // Return the image
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image from path: {ex.Message}");
            }

            // If the file doesn't exist or an error occurs, return a default image
            return "NULL"; // Ensure this default image is added to resources
        }

        public static void reloadLoggedInUser()
        {
            loggedInUser = new User(FSystem.loggedInUser.UserName);
        }
        public static bool Login(string userId, string password)
        {
            using (SqlConnection c = DB.Connect())
            {
                c.Open();
                string q = $"select count(*) from AllUser where (username = '{userId}' or email = '{userId}') and password ='{password}'";
                using (SqlCommand cmd = new SqlCommand(q, c))
                {
                    try
                    {
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            FSystem.loggedInUser = new User(userId);
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("DB ERROR: "+e.Message);
                    }

                }
            }
            return false;
        }
        // Methods to add and manage entities
        public static void AddUser(User user)
        {
            AllUsers.Add(user);
            TotalUsers++;
            if (user.isAdmin) { TotalAdmins++; }
            if (user.isArtist) { TotalArtists++; }
        }

        public static void AddEvent(Event eventItem)
        {
            AllEvents.Add(eventItem);
            TotalEvents++;
        }

        public static void insert3DData(DataClass data)
        {
            string filePath = "..\\..\\D3Program\\artsCollections.json"; // JSON file path
            // Step 1: Read existing data (or create a new list if the file is empty)
            List<DataClass> dataList = new List<DataClass>();

            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                string jsonData = File.ReadAllText(filePath);
                dataList = JsonConvert.DeserializeObject<List<DataClass>>(jsonData) ?? new List<DataClass>();
            }


            // Step 3: Add the new object to the list
            dataList.Add(data);

            // Step 4: Convert the updated list back to JSON format
            string updatedJson = JsonConvert.SerializeObject(dataList, Formatting.Indented);

            // Step 5: Write the updated JSON back to the file
            File.WriteAllText(filePath, updatedJson);

            Console.WriteLine("New art added successfully!");
        }

        public static bool validEmail(string text)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(text, pattern);
            //@ to not use double slashes since regex uses it often
            //^ Start of string
            //[a - zA - Z0 - 9._ % +-]+ Local part(username)
            //@  compulsory @ symbol
            //[a - zA - Z0 - 9.-]+  Domain name
            //\. Dot before top level domain (TLD)
            //[a - zA - Z]{ 2,}	TLD, {atleast 2 chars, no upper limits}
            //$	End of string
        }
        public static bool isAdminOrOrganizer(Event currentEvent)
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
                    organizerCmd.Parameters.AddWithValue("@eventid", currentEvent.EventID);

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
        public static void DeleteUser(string username)
        {
            string userNameToDelete = username; // Or get the user to delete dynamically

            using (SqlConnection con = DB.Connect())
            {
                try
                {
                    con.Open();

                    // Step 1: Delete related data from Artists table (if user is an artist)
                    string deleteArtistQuery = "DELETE FROM Artists WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(deleteArtistQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userNameToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    // Step 2: Delete user from UserContact table (if user has contact details)
                    string deleteUserContactQuery = "DELETE FROM UserContact WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(deleteUserContactQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userNameToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    // Step 3: Delete user from UserSocials table (if user has social media details)
                    string deleteUserSocialsQuery = "DELETE FROM UserSocials WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(deleteUserSocialsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userNameToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    // Step 4: Finally, delete user from AllUser table
                    string deleteUserQuery = "DELETE FROM AllUser WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(deleteUserQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userNameToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    // Optionally, show a success message
                    MessageBox.Show("User deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Handle any errors (e.g., constraint violations, etc.)
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
