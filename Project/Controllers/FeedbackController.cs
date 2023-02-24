using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class FeedbackController : IController<FeedbackDTO, long>
    {
        private IService<Feedback, long> _service;
        private IConverter<Feedback, FeedbackDTO> _feedbackConverter;


        public FeedbackController(
            IService<Feedback, long> service,
            IConverter<Feedback, FeedbackDTO> feedbackConverter
            )
        {
            _service = service;
            _feedbackConverter = feedbackConverter;
        }

        public FeedbackDTO GetById(long id)
            => _feedbackConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<FeedbackDTO> GetAll()
            => _feedbackConverter.ConvertListEntityToListDTO((List<Feedback>)_service.GetAll());

        public FeedbackDTO Remove(FeedbackDTO entity)
            => _feedbackConverter.ConvertEntityToDTO(_service.Remove(_feedbackConverter.ConvertDTOToEntity(entity)));

        public FeedbackDTO Save(FeedbackDTO entity)
            => _feedbackConverter.ConvertEntityToDTO(_service.Save(_feedbackConverter.ConvertDTOToEntity(entity)));

        public FeedbackDTO Update(FeedbackDTO entity)
            => _feedbackConverter.ConvertEntityToDTO(_service.Update(_feedbackConverter.ConvertDTOToEntity(entity)));
    }
}