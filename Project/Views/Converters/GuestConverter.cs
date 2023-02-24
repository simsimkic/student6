using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class GuestConverter : IConverter<Guest, GuestDTO>
    {
        private AddressConverter _addressConverter;

        public GuestConverter(AddressConverter addressConverter)
        {
            _addressConverter = addressConverter;
        }

        public Guest ConvertDTOToEntity(GuestDTO dto)
            => new Guest(
                dto.Id,
                dto.Address == null ? new Address() : _addressConverter.ConvertDTOToEntity(dto.Address),
                dto.FirstName,
                dto.LastName,
                dto.Jmbg, 
                dto.TelephoneNumber, 
                dto.Gender, 
                dto.DateOfBirth, 
                dto.InsurenceNumber,
                dto.Profession,
                dto.BloodType, 
                dto.Height, 
                dto.Weight);

        public GuestDTO ConvertEntityToDTO(Guest entity)
            => new GuestDTO(
                (entity.Address == null) ? new AddressDTO() : _addressConverter.ConvertEntityToDTO(entity.Address),
                entity.FirstName,
                entity.LastName,
                entity.Jmbg,
                entity.TelephoneNumber,
                entity.Gender,
                entity.DateOfBirth,
                entity.InsurenceNumber,
                entity.Profession,
                entity.BloodType,
                entity.Height,
                entity.Weight);

        public List<Guest> ConvertListDTOToListEntity(IEnumerable<GuestDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<GuestDTO> ConvertListEntityToListDTO(List<Guest> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
