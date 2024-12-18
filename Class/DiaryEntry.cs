using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawdoc.Class
{
    [FirestoreData]
    public class DiaryEntry
    {
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Id { get;  set; } // Read-only after initialization
        [FirestoreProperty]
        public string Symptoms { get; set; }
        [FirestoreProperty]
        public string Diagnosis { get; set; }
        [FirestoreProperty]
        public string Medicine { get; set; }
        [FirestoreProperty]
        public string ExtraNote { get; set; }
        [FirestoreProperty]
        public Timestamp DateCreated { get;  set; } // Read-only after initialization

        // Constructor
        public DiaryEntry() { }

        public DiaryEntry(string symptoms, string diagnosis, string medicine, string extraNote)
        {
            Id = Guid.NewGuid().ToString();
            Symptoms = symptoms;
            Diagnosis = diagnosis;
            Medicine = medicine;
            ExtraNote = extraNote;
            DateCreated = Timestamp.GetCurrentTimestamp();
        }

    }
}
