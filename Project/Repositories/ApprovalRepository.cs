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
    public class ApprovalRepository:CSVRepository<Approval,long>,
        IApprovalRepository,
        IEagerCSVRepository<Approval, long>
    {
        private const string ENTITY_NAME = "Approval";

        public ApprovalRepository(ICSVStream<Approval> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Approval> Find(Func<Approval, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Approval> GetAllEager() => GetAll();
        public Approval GetEager(long id) => GetById(id);


    }
}
