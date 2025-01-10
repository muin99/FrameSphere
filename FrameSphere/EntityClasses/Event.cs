using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere.EntityClasses
{
    public class Event
    {
        private string _EventID;
        private string _EventTitle;
        private string _EventDescription;
        private string _Organization;
        private string _TicketPrice;
        private string _Poster;
        private string _StartsAt;
        private string _EndsAt;

        public User[] visitors = new User[1000];
        public Artist[] artists = new Artist[1000];
        public User[] Organizers = new User[1000];

        public string EventID {
            get { return _EventID; }
            set { _EventID = value; }
        }

        public string EventTitle {
            get { return _EventTitle; }
            set { _EventTitle = value; }
        }

        public string EventDescription {
            get { return _EventDescription; }
            set { _EventDescription = value; }
        }

        public string Organization {
            get { return _Organization; }
            set { _Organization = value; }
        }

        public string TicketPrice {
            get { return _TicketPrice; }
            set { _TicketPrice = value; }
        }

        public string Poster {
            get { return _Poster; }
            set { _Poster = value; }
        }

        public string StartsAt {
            get { return _StartsAt; }
            set { _StartsAt = value; }
        }

        public string EndsAt {
            get { return _EndsAt; }
            set { _EndsAt = value; }
        }



    }
}
