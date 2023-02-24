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
    public class AddressRepository :
        CSVRepository<Address, long>,
        IAddressRepository,
        IEagerCSVRepository<Address, long>
    {
        private const string ENTITY_NAME = "Address";

        public AddressRepository(ICSVStream<Address> stream, ISequencer<long> sequencer)
           : base(ENTITY_NAME, stream, sequencer) { }

        public new IEnumerable<Address> Find(Func<Address, bool> predicate)
            => GetAllEager().Where(predicate);


        public new Address Save(Address address)
        {
            //if (IsAddressUnique(address)) // isUniq je uvek false
            //{
            //    return base.Save(address);
            //} else {
            //    return Find(item => item.Equals(address)).SingleOrDefault();
            //}
            return base.Save(address);
        }

        private bool IsAddressUnique(Address address)
            => Find(item => item.Equals(address)) == null;


        public Address GetEager(long id) => GetById(id);
        public IEnumerable<Address> GetAllEager() => GetAll();
    }
}
