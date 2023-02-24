using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class InventoryManagementConverter : IConverter<InventoryManagement, InventoryManagementDTO>
    {
        private EquipmentConverter _equipmentConverter;
        private RoomConverter _roomConverter;

        public InventoryManagementConverter(EquipmentConverter equipmentConverter
            , RoomConverter roomConverter)
        {
            _equipmentConverter = equipmentConverter;
            _roomConverter = roomConverter;
        }

        public InventoryManagement ConvertDTOToEntity(InventoryManagementDTO dto)
        {
            Room room = _roomConverter.ConvertDTOToEntity(dto.Room);
            Room roomTo = _roomConverter.ConvertDTOToEntity(dto.RoomTo);
            List<Equipment> equipment = dto.Equipment.Select(eq => _equipmentConverter.ConvertDTOToEntity(eq)).ToList();

            return new InventoryManagement(dto.Id, dto.Beginning, dto.End, room, equipment, roomTo);
        }

        public InventoryManagementDTO ConvertEntityToDTO(InventoryManagement entity)
        {
            RoomDTO room = _roomConverter.ConvertEntityToDTO(entity.Room);
            RoomDTO roomTo = _roomConverter.ConvertEntityToDTO(entity.RoomTo);
            List<EquipmentDTO> equipment = entity.Equipment.Select(eq => _equipmentConverter.ConvertEntityToDTO(eq)).ToList();

            return new InventoryManagementDTO(entity.Id, entity.Beginning, entity.End, room, equipment, roomTo);
        }

        public List<InventoryManagement> ConvertListDTOToListEntity(IEnumerable<InventoryManagementDTO> dtos)
        => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<InventoryManagementDTO> ConvertListEntityToListDTO(List<InventoryManagement> entities)
        => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
