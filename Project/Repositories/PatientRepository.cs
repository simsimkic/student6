using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;

namespace Project.Repositories
{
    public class PatientRepository :
        UserCSVRepository<Patient, User, long>,
        IPatientRepository,
        IEagerCSVRepository<Patient, long>
    {
        private const string ENTITY_NAME = "Patient";
        private readonly IAddressRepository _addressRepository;

        public PatientRepository(
            ICSVStream<Patient> stream,
            ICSVStream<Patient> patientStream,
            ICSVStream<Doctor> doctorStream,
            ICSVStream<Secretary> secretaryStream,
            IAddressRepository addressRepository,
            LongSequencer sequencer
            ) : base(stream, patientStream, doctorStream, secretaryStream, sequencer)
        {
            _addressRepository = addressRepository;
        }
        public new IEnumerable<Patient> Find(Func<Patient, bool> predicate) 
            => GetAllEager().Where(predicate);
        public IEnumerable<Patient> GetAllEager() 
            => base.GetAll();

        public Patient GetEager(long id)
        {
            Patient patient = GetById(id);
            patient.Address = _addressRepository.GetById(patient.Address.Id);
            return patient;
        } 

        public new Patient Save(Patient patient)
        {
            if (IsEmailUnique(patient.Email)){
                patient.Address = _addressRepository.Save(patient.Address);
                return base.Save(patient);
            }
            else
                throw new Exception();
        }

        private bool IsEmailUnique(string email)
            => GetByEmail(email).Id == 0;

        public new Patient Update(Patient patient){
            _addressRepository.Update(patient.Address);
            return base.Update(patient);
        }

        public Patient GetByEmail(string email)
        {
            var patient = GetAll().SingleOrDefault(item => item.Email.Equals(email));
            if(patient != null)
            {
                patient.Address = _addressRepository.GetById(patient.Address.Id);
                return patient;
            }
            return new Patient();
        }

    }
}