using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FrameSphere.EntityClasses
{
    public class Artist : User
    {
        public int NumberOfArts { get; private set; } = 0;
        public List<Art> HisArts = new List<Art>();

        public Artist(string UserName) : base(UserName)
        {

        }
        public void AddArt(Art art)
        {
            HisArts.Add(art);
            NumberOfArts++;
        }

        
    }
}
