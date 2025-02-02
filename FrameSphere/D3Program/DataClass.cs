using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameSphere.EntityClasses;

namespace FrameSphere.D3Program
{
    public class DataClass
    {
        public int ArtID { get; set; }
        public string Title { get; set; }
        public List<string> PhotoPath { get; set; }
        public string Description {  get; set; }
        public string nameofCreator { get; set; }
        public string Creator { get; set; }



        public DataClass(int artid)
        {
            Art art = new Art(artid);
            ArtID = art.ArtID;
            Title = art.ArtTitle;
            Description = art.ArtDescription;
            List<string> temp = art.artPhotos;
            User user = new User(art.Creator);
            nameofCreator = user.FullName();
            Creator = user.UserName;

            foreach ( string photo in temp)
            {
                if (PhotoPath == null)
                {
                    PhotoPath = new List<string>(); // Initialize if null
                }

                string path = FSystem.GetPathFromRelative(photo);
                PhotoPath.Add(!string.IsNullOrEmpty(path) ? path : "NULL");

            }


        }
    }
}
