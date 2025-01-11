using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere.EntityClasses
{
    public class Artist : User
    {
        public int NumberOfArts { get; set; }

        public Art[] HisArts = new Art[1000];
    }
}
