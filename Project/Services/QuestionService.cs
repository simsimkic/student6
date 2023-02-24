using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class QuestionService : IService<Question, long>
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public IEnumerable<Question> GetAll() 
            => _questionRepository.GetAll();

        public Question GetById(long id) 
            => _questionRepository.GetById(id);

        public Question Save(Question question) 
            => _questionRepository.Save(question);

        public Question Update(Question question) 
            => _questionRepository.Update(question);

        public Question Remove(Question question) 
            => _questionRepository.Remove(question);

    }
}
