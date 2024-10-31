using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp.Data
{
    public class AppUser
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public bool IsLocked { get; set; }
    }
}
