using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp.Data
{
    public class Patient
    {
        public long Id { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public AdministrativeGender? AdministrativeGender { get; set; }
    }
}
