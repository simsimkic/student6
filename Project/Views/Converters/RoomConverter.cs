using Project.Model;
using Project.Views.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.Views.Converters
{
    public class RoomConverter : IConverter<Room, RoomDTO>
    {
        public Room ConvertDTOToEntity(RoomDTO dto) 
            => (dto != null) ? new Room( dto.Id, dto.Type, dto.Ward, dto.Floor ) : new Room();

        public RoomDTO ConvertEntityToDTO(Room entity) 
            => new RoomDTO(entity.Id, entity.Type, entity.Ward, entity.Floor );

        public List<Room> ConvertListDTOToListEntity(System.Collections.Generic.IEnumerable<RoomDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<RoomDTO> ConvertListEntityToListDTO(System.Collections.Generic.List<Room> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}