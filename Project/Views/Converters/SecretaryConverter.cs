using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using System.Web.UI.WebControls;

namespace Project.Views.Converters
{
    public class SecretaryConverter : IConverter<Project.Model.Secretary, SecretaryDTO>
    {
        private QuestionConverter _questionConverter;
        private AddressConverter _addressConverter;

        public SecretaryConverter(QuestionConverter questionConverter, AddressConverter addressConverter)
        {
            _questionConverter = questionConverter;
            _addressConverter = addressConverter;
        }

        public Project.Model.Secretary ConvertDTOToEntity(SecretaryDTO dto)
        {
            return new Project.Model.Secretary(
                    dto.Id,
                    _addressConverter.ConvertDTOToEntity(dto.Address),
                    dto.FirstName,
                    dto.LastName,
                    dto.Jmbg,
                    dto.TelephoneNumber,
                    dto.Gender,
                    dto.DateOfBirth,
                    dto.Salary,
                    dto.AnnualLeave,
                    dto.WorkingHours,
                    dto.Email,
                    dto.Password
                    );
        }

        public SecretaryDTO ConvertEntityToDTO(Project.Model.Secretary entity)
        {

            try
            {

                return new SecretaryDTO(
                        entity.Id,
                        _addressConverter.ConvertEntityToDTO(entity.Address),
                        entity.FirstName,
                        entity.LastName,
                        entity.Jmbg,
                        entity.TelephoneNumber,
                        entity.Gender,
                        entity.DateOfBirth,
                        entity.Salary,
                        entity.AnnualLeave,
                        entity.WorkingHours,
                        entity.Email,
                        entity.Password
                        );

            }
            catch (System.Exception)
            {

                return new SecretaryDTO();
            }
        }
        public List<Project.Model.Secretary> ConvertListDTOToListEntity(IEnumerable<SecretaryDTO> dtos)
        => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<SecretaryDTO> ConvertListEntityToListDTO(List<Project.Model.Secretary> entities)
        => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
