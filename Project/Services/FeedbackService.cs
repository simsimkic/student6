using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class FeedbackService : IService<Feedback, long>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public IEnumerable<Feedback> GetAll() 
            => _feedbackRepository.GetAll();

        public Feedback GetById(long id) 
            => _feedbackRepository.GetById(id);

        public Feedback Save(Feedback question) 
            => _feedbackRepository.Save(question);

        public Feedback Update(Feedback question) 
            => _feedbackRepository.Update(question);

        public Feedback Remove(Feedback question) 
            => _feedbackRepository.Remove(question);

    }
}
