using System;
using System.Collections.Generic;
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

        public string ArtID {
            get { return _ArtID; }
            set { _ArtID = value; }
        }

        public string ArtTitle {
            get { return _ArtTitle; }
            set { _ArtTitle = value; }
        }

        public string ArtDescription {
            get { return _ArtDescription; }
            set { _ArtDescription = value; }
        }

        public string SellingOption {
            get { return _SellingOption; }
            set { _SellingOption = value; }
        }

        public double Price {
            get { return _Price; }
            set { _Price = value; }
        }

    }
}
