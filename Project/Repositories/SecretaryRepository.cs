using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repositories
{
    public class SecretaryRepository:
        UserCSVRepository<Secretary, User, long>,
        ISecretaryRepository,
        IEagerCSVRepository<Secretary, long>
    {
        private const string ENTITY_NAME = "Secretary";
        private readonly IAddressRepository _addressRepository;

        public SecretaryRepository(
            ICSVStream<Secretary> stream,
            ICSVStream<Patient> patientStream,
            ICSVStream<Doctor> doctorStream,
            ICSVStream<Secretary> secretaryStream,
            IAddressRepository addressRepository,
            LongSequencer sequencer
            ) : base(stream, patientStream, doctorStream, secretaryStream, sequencer)
        {
            _addressRepository = addressRepository;
        }
        public IEnumerable<Secretary> GetAllEager() 
            => GetAll();
        public Secretary GetEager(long id) 
            => GetById(id);
        public new IEnumerable<Secretary> Find(Func<Secretary, bool> predicate) 
            => GetAllEager().Where(predicate);

        public new IEnumerable<Secretary> GetAll() 
        {
            var secretaries = base.GetAll();
            var addresses = _addressRepository.GetAll();
            BindSecretaryWithAddress(addresses, secretaries);
            return secretaries;
        }

        public new Secretary GetById(long id) 
        {
            var secretary = base.GetById(id);
            secretary.Address = _addressRepository.GetById(secretary.Address.Id);
            return secretary;
        }
        public new Secretary Save(Secretary entity) 
        {
            entity.Address = _addressRepository.Save(entity.Address);
            return base.Save(entity);
        }
        public new Secretary Update(Secretary entity) 
        {
            entity.Address = _addressRepository.Save(entity.Address);
            return base.Update(entity);
        }
        private void BindSecretaryWithAddress(IEnumerable<Address> addresses, IEnumerable<Secretary> secretaries)
            => secretaries
            .ToList()
            .ForEach(sec => sec.Address = _addressRepository.GetById(sec.Address.Id));
        public Secretary GetByEmail(string email)
        {
            var secretary = GetAll().SingleOrDefault(item => item.Email.Equals(email));
            if(secretary != null)
            {
                secretary.Address = _addressRepository.GetById(secretary.Address.Id);
                return secretary;
            }
            return new Secretary();

        }

    }
}