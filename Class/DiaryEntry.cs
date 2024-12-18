using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawdoc.Class
{
    public class DiaryEntry
    {
        public string UserId { get; set; }
        public string Id { get;  set; } // Read-only after initialization
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public string ExtraNote { get; set; }
        public DateTime DateCreated { get;  set; } // Read-only after initialization

        // Constructor
        
    }
}
