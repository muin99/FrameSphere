using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere.EntityClasses
{
    public class User
    {
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Password;
        private string _UserName;
        private string _Address;
        private string _Phone;
        private string _Status;
        private string _ProfilePic;
        private string _Facebook;
        private string _Instagram;
        private string _Website;
        private string _Pinterest;
        
        public bool isArtist;
        public bool isAdmin;
        public bool isLoggedIn = false;

        public string FirstName {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Email {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }

        public string UserName {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Address {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Phone {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Status {
            get { return _Status; }
            set { _Status = value; }
        }

        public string ProfilePic {
            get { return _ProfilePic; }
            set { _ProfilePic = value; }
        }

        public string Facebook {
            get { return _Facebook; }
            set { _Facebook = value; }
        }

        public string Instagram {
            get { return _Instagram; }
            set { _Instagram = value; }
        }

        public string Website {
            get { return _Website; }
            set { _Website = value; }
        }

        public string Pinterest {
            get { return _Pinterest; }
            set { _Pinterest = value; }
        }
    }
}
