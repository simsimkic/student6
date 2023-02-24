using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;

namespace Project.Services
{

    public class AddressService : IService<Address, long>
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<Address> GetAll() 
            => _addressRepository.GetAll();

        public Address GetById(long id) 
            => _addressRepository.GetById(id);

        public Address Save(Address address) 
            => _addressRepository.Save(address); 

        public Address Update(Address address) 
            => _addressRepository.Update(address);

        public Address Remove(Address address) 
            => _addressRepository.Remove(address);

    }
}