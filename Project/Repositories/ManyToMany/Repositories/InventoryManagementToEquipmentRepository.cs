using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.ManyToMany.Repositories.Abstract;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.ManyToMany.Repositories
{
    public class InventoryManagementToEquipmentRepository : CSVRepository<InventoryManagementToEquipment,long>, IInventoryManagementToEquipmentRepository, IEagerCSVRepository<InventoryManagementToEquipment,long>
    {
        private const string ENTITY_NAME = "InventoryManagementToEquipment";
        public InventoryManagementToEquipmentRepository(
            ICSVStream<InventoryManagementToEquipment> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }


        public IEnumerable<InventoryManagementToEquipment> GetAllEager()
        {
            throw new NotImplementedException();
        }


        public InventoryManagementToEquipment GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public InventoryManagementToEquipment Remove(InventoryManagementToEquipment entity)
        {
            throw new NotImplementedException();
        }


        public InventoryManagementToEquipment Update(InventoryManagementToEquipment entity)
        {
            throw new NotImplementedException();
        }
    }
}
