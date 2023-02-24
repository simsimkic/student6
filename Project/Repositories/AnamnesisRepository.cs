using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;


namespace Project.Repositories
{
    public class AnamnesisRepository :
        CSVRepository<Anamnesis, long>,
        IAnamnesisRepository,
        IEagerCSVRepository<Anamnesis, long>
    {
        private const string ENTITY_NAME = "Anamnesis";

        public AnamnesisRepository(
            ICSVStream<Anamnesis> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }

        public new IEnumerable<Anamnesis> Find(Func<Anamnesis, bool> predicate)
            => GetAllEager().Where(predicate);

        public IEnumerable<Anamnesis> GetAllEager()
            => GetAll();

        public IEnumerable<Anamnesis> GetByMedicalAppointmentId(long id)
            => GetAll().Where(item => item.MedicalAppoitmentId == id).ToList();


        public Anamnesis GetEager(long id)
            => GetById(id);
    }
}
