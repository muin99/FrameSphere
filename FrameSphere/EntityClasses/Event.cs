using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere.EntityClasses
{
    public class Event
    {
        public string EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string Organization { get; set; }
        public double TicketPrice { get; set; }
        public string Poster { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }

        public List<User> Visitors = new List<User>();
        public List<Artist> Artists = new List<Artist>();
        public List<User> Organizers = new List<User>();

        public void AddVisitor(User visitor)
        {
            Visitors.Add(visitor);
        }

        public void AddArtist(Artist artist)
        {
            Artists.Add(artist);
        }

        public void AddOrganizer(User organizer)
        {
            Organizers.Add(organizer);
        }

        
    }
}

