using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Model;
using Project.Repositories;
using Project.Services.Abstract;
using Project.Repositories.Abstract;

namespace Project.Services
{
    class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
     
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetAll() 
            => _doctorRepository.GetAll();

        public Doctor GetById(long id) 
            => _doctorRepository.GetById(id);

        public Doctor Save(Doctor doctor)
            => _doctorRepository.Save(doctor);

        public Doctor Update(Doctor doctor)
            => _doctorRepository.Update(doctor);

        public Doctor Remove(Doctor client) 
            => _doctorRepository.Remove(client);
        public Doctor GetByEmail(string email) 
            => _doctorRepository.GetByEmail(email);

        public bool IsDoctorAvailable(int doctorID) => throw new NotImplementedException();

        public List<Doctor> GetAailableDoctors(Array doctorsID) => throw new NotImplementedException();

        public List<Doctor> GetAailableDoctors(TimeInterval timeInterval) => throw new NotImplementedException();

        public List<Doctor> GetAvailableDoctorsTimeInterval(MedicalAppointment medicalAppointment) => throw new NotImplementedException();


        public List<Doctor> GetAllDoctorsBySpecialization(string specialization) => _doctorRepository.GetBySpecialization(specialization); 
    }
}
