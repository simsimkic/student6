using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class QuestionConverter : IConverter<Question, QuestionDTO>
    {
        private PatientConverter _patientConverter;

        public QuestionConverter(PatientConverter patientConverter)
        {
            _patientConverter = patientConverter;

        }
        public Question ConvertDTOToEntity(QuestionDTO dto)
            => new Question(
                dto.Id,
                dto.QuestionText,
                dto.AnswerText,
                _patientConverter.ConvertDTOToEntity(dto.Patient),
                new Project.Model.Secretary(),
                dto.CreationDate

            );

        public QuestionDTO ConvertEntityToDTO(Question entity)
                => new QuestionDTO(
                    entity.Id,
                    entity.QuestionText,
                    entity.AnswerText,
                    _patientConverter.ConvertEntityToDTO(entity.Patient),
                    new SecretaryDTO(),
                    entity.CreationDate
                    );

        public List<Question> ConvertListDTOToListEntity(IEnumerable<QuestionDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<QuestionDTO> ConvertListEntityToListDTO(List<Question> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
