using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp.Data
{
    public class PseudoDbContext
    {
        // This class simulates an Entity Framework DbContext.
        // Instead of connecting to an actual database, it just
        // contains mock objects that are regenerated every
        // time the application starts.

        public PseudoDbContext()
        {
            Users = CreateUsers().ToList();
            Patients = CreatePatients().ToList();
        }

        private static IEnumerable<AppUser> CreateUsers()
        {
            yield return new AppUser()
            {
                Id = 1,
                Email = "alice.demo@nowhere.example.com",
                Name = "Alice Demo",
                PasswordHash = HashHelper.CreateHash("demo"),
                Username = "demo",
                IsLocked = false
            };
            yield return new AppUser()
            {
                Id = 2,
                Email = "bob.demo@nowhere.example.com",
                Name = "Bob Demo",
                PasswordHash = HashHelper.CreateHash("secret123"),
                Username = "bob",
                IsLocked = false
            };
        }

        private static IEnumerable<Patient> CreatePatients()
        {
            yield return new Patient()
            {
                Id = 1,
                FamilyName = "Anchovy",
                GivenName = "Arnold",
                AdministrativeGender = AdministrativeGender.Male,
                DateOfBirth = null
            };

            yield return new Patient()
            {
                Id = 2,
                FamilyName = "Basil",
                GivenName = "Bianca",
                AdministrativeGender = AdministrativeGender.Female,
                DateOfBirth = new DateTime(1984, 5, 11)
            };

            yield return new Patient()
            {
                Id = 3,
                FamilyName = "Celery",
                GivenName = "Charles",
                AdministrativeGender = AdministrativeGender.Male,
                DateOfBirth = new DateTime(1980, 4, 10)
            };
        }

        public ICollection<AppUser> Users { get; }

        public ICollection<Patient> Patients { get; }

    }
}
