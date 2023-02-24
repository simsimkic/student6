using System.Collections.Generic;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Project.Controllers
{
    public class AddressController : IController<AddressDTO, long>
    {
        private IService<Address, long> _service;
        private IConverter<Address, AddressDTO> _converter;
        public AddressController( 
            IService<Address, long> service ,
            IConverter<Address, AddressDTO> converter
            )
        {
            _service = service;
            _converter = converter;
        }
        public IEnumerable<AddressDTO> GetAll()
            => _converter.ConvertListEntityToListDTO((List<Address>)_service.GetAll());

        public AddressDTO GetById(long id)
            => _converter.ConvertEntityToDTO(_service.GetById(id));

        public AddressDTO Remove(AddressDTO entity)
            => _converter.ConvertEntityToDTO(_service.Remove(_converter.ConvertDTOToEntity(entity)));

        public AddressDTO Save(AddressDTO entity)
            => _converter.ConvertEntityToDTO(_service.Save(_converter.ConvertDTOToEntity(entity)));

        public AddressDTO Update(AddressDTO entity)
            => _converter.ConvertEntityToDTO(_service.Update(_converter.ConvertDTOToEntity(entity)));
        
    }
}