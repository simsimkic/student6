using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Project.Controllers
{
    public class GuestController : IController<GuestDTO, long>
    {
        private IService<Guest, long> _service;
        private IConverter<Guest, GuestDTO> _converter;

        public GuestController(IService<Guest, long> service, IConverter<Guest, GuestDTO> converter)
        {
            _service = service;
            _converter = converter;
        }
        public GuestDTO GetById(long id)
            => _converter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<GuestDTO> GetAll()
            => _converter.ConvertListEntityToListDTO((List<Guest>)_service.GetAll());

        public GuestDTO Remove(GuestDTO entity)
            => _converter.ConvertEntityToDTO(_service.Remove(_converter.ConvertDTOToEntity(entity)));

        public GuestDTO Save(GuestDTO entity)
            => _converter.ConvertEntityToDTO(_service.Save(_converter.ConvertDTOToEntity(entity)));

        public GuestDTO Update(GuestDTO entity)
            => _converter.ConvertEntityToDTO(_service.Update(_converter.ConvertDTOToEntity(entity)));
    }
}