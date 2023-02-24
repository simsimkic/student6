using Project.Model;
using Project.Views.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.Views.Converters
{
    public class MedicalAppointmentConverter : IConverter<MedicalAppointment, MedicalAppointmentDTO>
    {
        private RoomConverter _roomConverter;
        private GuestConverter _guestConverter;
        private DoctorConverter _doctorConverter;
        public MedicalAppointmentConverter(RoomConverter roomConverter, GuestConverter guestConverter, DoctorConverter doctorConverter)
        {
            _roomConverter = roomConverter;
            _guestConverter = guestConverter;
            _doctorConverter = doctorConverter;

        }

        public MedicalAppointment ConvertDTOToEntity(MedicalAppointmentDTO dto)
            => new MedicalAppointment(
                dto.Id,
                dto.Beginning,
                dto.End,
                _roomConverter.ConvertDTOToEntity(dto.Room),
                dto.Type,
                _guestConverter.ConvertDTOToEntity(dto.Patient),
                _doctorConverter.ConvertListDTOToListEntity(dto.Doctors)
                );

        public MedicalAppointmentDTO ConvertEntityToDTO(MedicalAppointment entity)
            => new MedicalAppointmentDTO(
                entity.Id,
                entity.Beginning,
                entity.End,
                _roomConverter.ConvertEntityToDTO(entity.Room),
                entity.Type,
                _guestConverter.ConvertEntityToDTO(entity.Patient),
                _doctorConverter.ConvertListEntityToListDTO(entity.Doctors)
                );

        public List<MedicalAppointment> ConvertListDTOToListEntity(IEnumerable<MedicalAppointmentDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<MedicalAppointmentDTO> ConvertListEntityToListDTO(List<MedicalAppointment> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}