using Project.Model;
using Project.Services;
using Project.Services.Abstract;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class RenovationController:IController<RenovationDTO,long>
    {
        private IRenovationService _service;
        private IConverter<Renovation, RenovationDTO> _renovationConverter;

        public RenovationController(
            IRenovationService service,
            IConverter<Renovation,RenovationDTO> renovationConverter)
        {
            _service = service;
            _renovationConverter = renovationConverter;
        }

        public RenovationDTO GetById(long id)
           => _renovationConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<RenovationDTO> GetAll()
            => _renovationConverter.ConvertListEntityToListDTO((List<Renovation>)_service.GetAll());

        public RenovationDTO Remove(RenovationDTO entity)
            => _renovationConverter.ConvertEntityToDTO(_service.Remove(_renovationConverter.ConvertDTOToEntity(entity)));

        public RenovationDTO Save(RenovationDTO entity)
            => _renovationConverter.ConvertEntityToDTO(_service.Save(_renovationConverter.ConvertDTOToEntity(entity)));

        public RenovationDTO Update(RenovationDTO entity)
            => _renovationConverter.ConvertEntityToDTO(_service.Update(_renovationConverter.ConvertDTOToEntity(entity)));

        public void RealiseRenovation(RenovationDTO entity)
            => _service.RealiseRenovation(_renovationConverter.ConvertDTOToEntity(entity));

    }
}
