using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;
using Project.Services.Abstract;

namespace Project.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll() 
            => _patientRepository.GetAll();

        public Patient GetById(long id) 
            => _patientRepository.GetById(id);
        public Patient Save(Patient patient) 
            => _patientRepository.Save(patient);

        public Patient Update(Patient patient) 
            => _patientRepository.Update(patient);

        public Patient Remove(Patient client) 
            => _patientRepository.Remove(client);

        public Patient GetByEmail(string email)
            => _patientRepository.GetByEmail(email);
        public Patient ClaimGuestAccount(Guest guest, string email, string password)
        {
            Patient tempPatient = _patientRepository.GetById(guest.Id);
            tempPatient.Email = email;
            tempPatient.Password = password;
            return _patientRepository.Update(tempPatient);
        }
    }
}
