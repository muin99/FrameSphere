using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere.EntityClasses
{
    public class Organizer : User
    {
        public int NumberOfManagedEvents { get; set; }

        public Event[] ManagedEvents = new Event[1000];

        public void AddEvent(Event eventToAdd)
        {
            if (NumberOfManagedEvents < ManagedEvents.Length)
            {
                ManagedEvents[NumberOfManagedEvents++] = eventToAdd;
                Console.WriteLine($"Event '{eventToAdd.EventTitle}' added to Organizer {UserName}'s managed events.");
            }
            else
            {
                Console.WriteLine("Cannot add more events. Maximum capacity reached.");
            }
        }

        public void RemoveEvent(Event eventToRemove)
        {
            for (int i = 0; i < NumberOfManagedEvents; i++)
            {
                if (ManagedEvents[i] == eventToRemove)
                {
                    for (int j = i; j < NumberOfManagedEvents - 1; j++)
                    {
                        ManagedEvents[j] = ManagedEvents[j + 1];
                    }

                    ManagedEvents[--NumberOfManagedEvents] = null;
                    Console.WriteLine($"Event '{eventToRemove.EventTitle}' removed from Organizer {UserName}'s managed events.");
                    return;
                }
            }
            Console.WriteLine("Event not found in the managed list.");
        }

        
    }
}
