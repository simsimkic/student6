using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class ReviewConverter : IConverter<Review, ReviewDTO>
    {
        private DoctorConverter _doctorConverter;

        public ReviewConverter(DoctorConverter doctorConverter)
        {
            _doctorConverter = doctorConverter;
        }

        public Review ConvertDTOToEntity(ReviewDTO dto)
        => new Review(dto.Id,
                    dto.Rating,
                    dto.Description,
                    _doctorConverter.ConvertDTOToEntity(dto.Doctor)
            );

        public ReviewDTO ConvertEntityToDTO(Review entity)
         => new ReviewDTO(
                    entity.Id,
                    entity.Rating,
                    entity.Description,
                    _doctorConverter.ConvertEntityToDTO(entity.Doctor)
                    );

        public List<Review> ConvertListDTOToListEntity(IEnumerable<ReviewDTO> dtos)
         => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<ReviewDTO> ConvertListEntityToListDTO(List<Review> entities)
         => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
