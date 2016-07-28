using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaster
{
    public class Event
    {
        public string Name { get; set; }
        public User Owner { get; set; }
        public Schedule Schedule { get; set; }
        public TimeSpan ConfirmationDelta { get; set; }
    }
}
