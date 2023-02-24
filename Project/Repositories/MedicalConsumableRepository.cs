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
    public class MedicalConsumableRepository :
        ItemCSVRepository<MedicalConsumables, Item, long>,
        IMedicalConsumableRepository
    {
        private const string ENTITY_NAME = "MedicalConsumables";
        
        public MedicalConsumableRepository(
            ICSVStream<MedicalConsumables> stream,
            ICSVStream<Equipment> equipmentStream,
            ICSVStream<MedicalConsumables> medicalConsumablesStream,
            ICSVStream<Medicine> medicineStream,
            LongSequencer sequencer
            ) : base (stream, equipmentStream, medicalConsumablesStream, medicineStream, sequencer) { }

        public new IEnumerable<MedicalConsumables> Find(Func<MedicalConsumables, bool> predicate) => GetAll().Where(predicate);

    }
}
