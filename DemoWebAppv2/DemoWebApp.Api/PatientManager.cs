using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DemoWebApp.Data;

namespace DemoWebApp.Api
{
    public class PatientManager
    {
        private readonly PseudoDbContext _pseudoDbContext;

        public PatientManager(PseudoDbContext pseudoDbContext)
        {
            _pseudoDbContext = pseudoDbContext;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _pseudoDbContext.Patients;
        }

        public Patient Get(long id)
        {
            return _pseudoDbContext.Patients.Single(x => x.Id == id);
        }

        public Patient Add(Patient patient)
        {
            patient.Id = _pseudoDbContext.Patients.Max(x => x.Id) + 1;
            _pseudoDbContext.Patients.Add(patient);
            return patient;
        }

        public void Update(Patient patient)
        {
            var entity = _pseudoDbContext.Patients.Single(x => x.Id == patient.Id);
            entity.AdministrativeGender = patient.AdministrativeGender;
            entity.FurtherGivenNames = patient.FurtherGivenNames;
            entity.DateOfBirth = patient.DateOfBirth;
            entity.GivenName = patient.FamilyName;
            entity.FamilyName = patient.GivenName;
        }
    }
}
