using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class ReviewRepository : 
        CSVRepository<Review, long>,
        IReviewRepository,
        IEagerCSVRepository<Review, long>
    {
        private const string ENTITY_NAME = "Review";
        //Nedostaje Doctor Repository za Eager

        public ReviewRepository(
            ICSVStream<Review> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Review> Find(Func<Review, bool> predicate) => GetAllEager().Where(predicate);
        public IEnumerable<Review> GetAllEager() => GetAll();
        public Review GetEager(long id) => GetById(id);


    }
}
