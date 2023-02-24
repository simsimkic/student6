using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class FeedbackConverter : IConverter<Feedback, FeedbackDTO>
    {

        public FeedbackConverter()
        {

        }
        public Feedback ConvertDTOToEntity(FeedbackDTO dto)
            => new Feedback(
                dto.Type,
                dto.Description
            );

        public FeedbackDTO ConvertEntityToDTO(Feedback entity)
            => new FeedbackDTO(
                entity.Issue,
                entity.Description
            );

        public List<Feedback> ConvertListDTOToListEntity(IEnumerable<FeedbackDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<FeedbackDTO> ConvertListEntityToListDTO(List<Feedback> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
