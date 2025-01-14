using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameSphere.EntityClasses;

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
        public static bool Login(string userId, string password)
        {
            using (SqlConnection c = DB.Connect())
            {
                c.Open();
                string q = $"select count(*) from AllUser where (username = '{userId}' or email = '{userId}') and password='{password}'";
                using (SqlCommand cmd = new SqlCommand(q, c))
                {
                    try
                    {
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            FSystem.loggedInUser = new User(userId, password);
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
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
            if (user.isAdmin) TotalAdmins++;
            if (user.isArtist) TotalArtists++;
        }

        public static void AddEvent(Event eventItem)
        {
            AllEvents.Add(eventItem);
            TotalEvents++;
        }


    }
}
