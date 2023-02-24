using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories.Abstract;

namespace Project.Services
{
    public class GuestService : IService<Guest, long>
    {
        private readonly IPatientRepository _patientRepository;

        public GuestService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Guest> GetAll()
            => (IEnumerable<Guest>)_patientRepository.GetAll();

        public Guest GetById(long id)
            => (Guest)_patientRepository.GetById(id);
        public Guest Save(Guest patient)
            => (Guest)_patientRepository.Save((patient as Patient));

        public Guest Update(Guest patient)
            => (Guest)_patientRepository.Update((patient as Patient));

        public Guest Remove(Guest client)
            => (Guest)_patientRepository.Remove((client as Patient));

        public Guest GetByEmail(string email)
            => (Guest)_patientRepository.GetByEmail(email);
    }

}