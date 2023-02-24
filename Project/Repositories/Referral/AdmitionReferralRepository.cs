using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Referrals;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;

namespace Project.Repositories.Referral
{
    public class AdmitionReferralRepository :
        CSVRepository<Model.Referral, long>,
        IReferralRepository,
        IEagerCSVRepository<Model.Referral, long>
    {
        private const string ENTITY_NAME = "AdmitionReferral";

        // TODO: Multiple IDs
        public AdmitionReferralRepository(
            ICSVStream<Model.Referral> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public IEnumerable<Model.Referral> Find(Func<Model.Referral, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Referral> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Referral> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Model.Referral GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Model.Referral GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public Model.Referral Remove(Model.Referral entity)
        {
            throw new NotImplementedException();
        }

        public Model.Referral Save(Model.Referral entity)
        {
            throw new NotImplementedException();
        }

        public Model.Referral Update(Model.Referral entity)
        {
            throw new NotImplementedException();
        }
    }
}
