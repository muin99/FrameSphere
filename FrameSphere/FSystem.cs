using System;
using System.Collections.Generic;
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
