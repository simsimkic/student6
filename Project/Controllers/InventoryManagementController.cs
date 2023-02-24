using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class InventoryManagementController : IController<InventoryManagementDTO, long>
    {
        private IService<InventoryManagement, long> _service;
        private IConverter<InventoryManagement, InventoryManagementDTO> _inventoryConverter;

        public InventoryManagementController(
            IService<InventoryManagement, long> service,
            IConverter<InventoryManagement, InventoryManagementDTO> inventoryConverter
            )

        {
            _service = service;
            _inventoryConverter = inventoryConverter;
        }

        public IEnumerable<InventoryManagementDTO> GetAll()
            => _inventoryConverter.ConvertListEntityToListDTO((List<InventoryManagement>)_service.GetAll());

        public InventoryManagementDTO GetById(long id)
            => _inventoryConverter.ConvertEntityToDTO(_service.GetById(id));

        public InventoryManagementDTO Remove(InventoryManagementDTO entity)
            => _inventoryConverter.ConvertEntityToDTO(_service.Remove(_inventoryConverter.ConvertDTOToEntity(entity)));

        public InventoryManagementDTO Save(InventoryManagementDTO entity)
            => _inventoryConverter.ConvertEntityToDTO(_service.Save(_inventoryConverter.ConvertDTOToEntity(entity)));

        public InventoryManagementDTO Update(InventoryManagementDTO entity)
            => _inventoryConverter.ConvertEntityToDTO(_service.Update(_inventoryConverter.ConvertDTOToEntity(entity)));
    }
}
