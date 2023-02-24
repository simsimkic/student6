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
    public class PropositionRepository :
        CSVRepository<Proposition, long>,
        IPropositionRepository,
        IEagerCSVRepository<Proposition, long>
    {
        private const string ENTITY_NAME = "Proposition";
        private MedicineRepository _medicineRepository;

        public PropositionRepository(
            ICSVStream<Proposition> stream,
            ISequencer<long> sequencer,
             MedicineRepository medicineRepository
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _medicineRepository = medicineRepository;   
        }
        public new IEnumerable<Proposition> Find(Func<Proposition, bool> predicate) => GetAllEager().Where(predicate);

        public new Proposition Save(Proposition proposition)
        {
            Medicine med=_medicineRepository.Save(proposition.Medicine);
            proposition.Medicine.Id = med.Id;
            return base.Save(proposition);
        }

        public IEnumerable<Proposition> GetAllEager() => GetAll();
        public Proposition GetEager(long id) => GetById(id);

    }
}
