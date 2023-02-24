using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class RenovationConverter:IConverter<Renovation,RenovationDTO>
    {
        private RoomConverter _roomConverter;

        public RenovationConverter(RoomConverter roomConverter)
        {
            _roomConverter = roomConverter;
        }

        public Renovation ConvertDTOToEntity(RenovationDTO dto)
            => new Renovation(
                dto.Id,
                dto.Beginning,
                dto.End,
                _roomConverter.ConvertDTOToEntity(dto.Room),
                dto.Type,
                dto.NewType
            );

        public RenovationDTO ConvertEntityToDTO(Renovation entity)
                => new RenovationDTO(
                    entity.Id,
                    entity.Beginning,
                    entity.End,
                    _roomConverter.ConvertEntityToDTO(entity.Room),
                    entity.Type,
                    entity.NewType
             );

        public List<Renovation> ConvertListDTOToListEntity(IEnumerable<RenovationDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<RenovationDTO> ConvertListEntityToListDTO(List<Renovation> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();

    }
}
