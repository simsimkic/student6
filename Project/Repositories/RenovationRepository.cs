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
    public class RenovationRepository:CSVRepository<Renovation,long>,
        IRenovationRepository,
        IEagerCSVRepository<Renovation, long>
    {
        private const string ENTITY_NAME = "Renovation";
        public RenovationRepository(
            ICSVStream<Renovation> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Renovation> Find(Func<Renovation, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Renovation> GetAllEager() => GetAll();
        public Renovation GetEager(long id) => GetById(id);


    }
}
