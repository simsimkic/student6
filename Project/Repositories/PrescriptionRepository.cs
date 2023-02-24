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
    public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository, IEagerCSVRepository<Prescription, long>
    {
        private const string ENTITY_NAME = "Prescription";
        private readonly IRepository<Medicine, long> _medicineRepository;
        private readonly IRepository<Patient, long> _patientRepository;

        public PrescriptionRepository(
            ICSVStream<Prescription> stream,
            IRepository<Medicine, long> medicineRepository,
            IRepository<Patient, long> patientRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _medicineRepository = medicineRepository;
            _patientRepository = patientRepository;
        }

        public new IEnumerable<Prescription> Find(Func<Prescription, bool> predicate) => GetAllEager().Where(predicate);


        public IEnumerable<Prescription> GetAllEager()
        {
            IEnumerable<Prescription> list = GetAll();
            foreach (Prescription prescription in list)
                prescription.Medicine = _medicineRepository.GetById(prescription.Medicine.Id);
            foreach (Prescription prescription in list)
                prescription.Patient = _patientRepository.GetById(prescription.Patient.Id);
            return list;

        }

        public Prescription GetAllPrescriptionsByPatientsId(long id)
        {
            throw new NotImplementedException();
        }

        public Prescription GetEager(long id) {
            Prescription prescription = GetById(id);
            prescription.Medicine =_medicineRepository.GetById(prescription.Medicine.Id);
            prescription.Patient =_patientRepository.GetById(prescription.Patient.Id);
            return prescription;
        }

        private List<Prescription> GetPrescriptionsByPatientId(long id)
        => GetPrescriptionsByPatientId(id);
        
    }
}
