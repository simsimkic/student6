using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class InventoryManagementService:IService<InventoryManagement,long>
    {
        private readonly IInventoryManagementRepository _inventoryRepository;

        public InventoryManagementService(IInventoryManagementRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public IEnumerable<InventoryManagement> GetAll()
            => _inventoryRepository.GetAll();

        public InventoryManagement GetById(long id)
            => _inventoryRepository.GetById(id);

        public InventoryManagement Remove(InventoryManagement entity)
            => _inventoryRepository.Remove(entity);

        public InventoryManagement Save(InventoryManagement entity)
            => _inventoryRepository.Save(entity);

        public InventoryManagement Update(InventoryManagement entity)
            => _inventoryRepository.Update(entity);
    }
}
