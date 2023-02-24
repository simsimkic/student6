using Project.Controllers.Abstract;
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
    public class SecretaryController: ISecretaryController
    {
        private ISecretaryService _service;
        private IConverter<Secretary, SecretaryDTO> _secretaryConverter;

        public SecretaryController(
            ISecretaryService service,
            IConverter<Secretary, SecretaryDTO> secretaryConverter
         )
        {
            _service = service;
            _secretaryConverter = secretaryConverter;
        }

        public IEnumerable<SecretaryDTO> GetAll()
            => _secretaryConverter.ConvertListEntityToListDTO((List<Secretary>)_service.GetAll());

        public SecretaryDTO GetByEmail(string email)
            => _secretaryConverter.ConvertEntityToDTO(_service.GetByEmail(email));

        public SecretaryDTO GetById(long id)
            => _secretaryConverter.ConvertEntityToDTO(_service.GetById(id));

        public SecretaryDTO Remove(SecretaryDTO entity)
            => _secretaryConverter.ConvertEntityToDTO(_service.Remove(_secretaryConverter.ConvertDTOToEntity(entity)));

        public SecretaryDTO Save(SecretaryDTO entity)
            => _secretaryConverter.ConvertEntityToDTO(_service.Save(_secretaryConverter.ConvertDTOToEntity(entity)));

        public SecretaryDTO Update(SecretaryDTO entity)
            => _secretaryConverter.ConvertEntityToDTO(_service.Update(_secretaryConverter.ConvertDTOToEntity(entity)));
    }
}
