using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repositories
{
    public class QuestionRepository :
        CSVRepository<Question, long>,
        IQuestionRepository,
        IEagerCSVRepository<Question, long>
    {
        private const string ENTITY_NAME = "Question";

        public QuestionRepository(
            ICSVStream<Question> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public new IEnumerable<Question> Find(Func<Question, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Question> GetAllEager() => GetAll();
        public Question GetEager(long id) => GetById(id);

    }
}
