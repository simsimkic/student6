using System.Collections.Generic;
using System.Linq;
using Project.Model;
using Project.Views.Model;


namespace Project.Views.Converters
{
    public class AppointmentConverter : IConverter<Appointment, AppointmentDTO>
    {

        private RoomConverter _roomConverter;

        public AppointmentConverter(RoomConverter roomConverter)
        {
            _roomConverter = roomConverter;

        }

        public Appointment ConvertDTOToEntity(AppointmentDTO dto)
            => new Appointment(
                dto.Id,
                dto.Beginning,
                dto.End,
                _roomConverter.ConvertDTOToEntity(dto.Room)
            );

        public AppointmentDTO ConvertEntityToDTO(Appointment entity)
            => new AppointmentDTO(
                entity.Id,
                entity.Beginning,
                entity.End,
                _roomConverter.ConvertEntityToDTO(entity.Room)
            );

        public List<Appointment> ConvertListDTOToListEntity(IEnumerable<AppointmentDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<AppointmentDTO> ConvertListEntityToListDTO(List<Appointment> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}