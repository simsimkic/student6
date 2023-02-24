using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Views.Model;

namespace Project.Views.Converters
{
    public class EquipmentConverter : IConverter<Equipment, EquipmentDTO>
    {
        private RoomConverter _roomConverter;

        public EquipmentConverter(RoomConverter roomConverter)
        {
            _roomConverter = roomConverter;
        }
        public Equipment ConvertDTOToEntity(EquipmentDTO dto)
        => new Equipment(
                dto.Id,
                dto.Type,
                dto.Description,
                dto.Name,
                _roomConverter.ConvertDTOToEntity(dto.Room)
            );

        public EquipmentDTO ConvertEntityToDTO(Equipment entity)
         => new EquipmentDTO(
                    entity.Id,
                    entity.Name,
                    entity.Type,
                    entity.Description,
                    _roomConverter.ConvertEntityToDTO(entity.Room)
                    );

        public List<Equipment> ConvertListDTOToListEntity(IEnumerable<EquipmentDTO> dtos)
                => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<EquipmentDTO> ConvertListEntityToListDTO(List<Equipment> entities)
                => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
