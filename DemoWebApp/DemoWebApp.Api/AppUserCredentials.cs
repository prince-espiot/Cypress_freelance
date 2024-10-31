using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp.Api
{
    public class AppUserCredentials
    {
        public AppUserCredentials(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        public string Username { get; }

        public string PasswordHash { get; }
    }
}
