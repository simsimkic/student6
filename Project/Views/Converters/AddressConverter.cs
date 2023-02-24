using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class AddressConverter : IConverter<Address, AddressDTO>
    {
        public Address ConvertDTOToEntity(AddressDTO dto)
            => new Address(
                dto.Id,
                dto.Number,
                dto.Street,
                dto.City,
                dto.Country,
                dto.PostCode
            );

        public AddressDTO ConvertEntityToDTO(Address entity)
        {
            try
            {
                return new AddressDTO(
                    entity.Id,
                    entity.Number,
                    entity.Street,
                    entity.City,
                    entity.Country,
                    entity.PostCode
                );
            }
            catch (System.Exception)
            {
                return new AddressDTO();
            }
        }

        public List<Address> ConvertListDTOToListEntity(IEnumerable<AddressDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<AddressDTO> ConvertListEntityToListDTO(List<Address> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
