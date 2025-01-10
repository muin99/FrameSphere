using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    internal class FSystem
    {
        public static int TotalUser;
        public static int TotalArtist;
        public static int TotalAdmins;

        public static User[] AllUsers = new User[TotalUser];
        public static Artist[] AllArtists = new Artist[TotalArtist];
        public static User[] Admins = new User[TotalAdmins];


    }
}
