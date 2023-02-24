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
    public class FeedbackRepository :
        CSVRepository<Feedback, long>,
        IFeedbackRepository,
        IEagerCSVRepository<Feedback, long>
    {
        private const string ENTITY_NAME = "Feedback";

        public FeedbackRepository(
            ICSVStream<Feedback> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public new IEnumerable<Feedback> Find(Func<Feedback, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Feedback> GetAllEager() => GetAll();
        public Feedback GetEager(long id) => GetById(id);

    }
}
