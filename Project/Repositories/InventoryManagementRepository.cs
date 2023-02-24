using Project.Model;
using Project.Repositories.Abstract;
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

namespace Project.Repositories
{
    public class InventoryManagementRepository: CSVRepository<InventoryManagement,long>, IInventoryManagementRepository, IEagerCSVRepository<InventoryManagement,long>
    {
        private const string ENTITY_NAME = "InventoryManagement";
        private readonly IRepository<InventoryManagementToEquipment, long> _inventoryManagementToEquipmentRepository;
        public InventoryManagementRepository(
            ICSVStream<InventoryManagement> stream,
            IInventoryManagementToEquipmentRepository inventoryManagementToEquipmentRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _inventoryManagementToEquipmentRepository = inventoryManagementToEquipmentRepository;
        }

        public new IEnumerable<InventoryManagement> Find(Func<InventoryManagement, bool> predicate) => GetAllEager().Where(predicate);
        public new InventoryManagement Save(InventoryManagement entity){
            InventoryManagement inv = base.Save(entity);
            foreach(var item in inv.Equipment){
                _inventoryManagementToEquipmentRepository.Save(new InventoryManagementToEquipment(inv.Id, item.Id));
            }
            return inv;
        }

        public IEnumerable<InventoryManagement> GetAllEager() => GetAll();
        public InventoryManagement GetEager(long id) => GetById(id);
    }
}
