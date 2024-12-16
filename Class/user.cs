using Google.Cloud.Firestore;

namespace pawdoc
{
    [FirestoreData] // Atribut untuk serialisasi Firestore
    public class User
    {
        // ID Dokumen Firestore
        public string Id { get; set; }

        // Properti dengan FirestoreProperty untuk Firestore Database
        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }


        [FirestoreProperty]
        public UserRole Role { get; set; } // Enum untuk peran pengguna

        // Constructor Default (Diperlukan oleh Firestore)
        public User() { }

        // Constructor dengan Parameter
        public User(string username, string password, string email, string userphone, string city, UserRole role)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }
    }

    [FirestoreData]
public class Pet
{
    [FirestoreProperty]
    public string PetName { get; set; }

    [FirestoreProperty]
    public string PetSpecies { get; set; }

    [FirestoreProperty]
    public int PetAge { get; set; }
}

    // Enum untuk Role Pengguna
    public enum UserRole
    {
        Owner,
        Vet
    }
}

