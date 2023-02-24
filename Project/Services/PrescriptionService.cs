using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class PrescriptionService : IService<Prescription, long>
    {
        private IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IService<Medicine, long> medicineService,
            IService<Patient, long> patientService
            )
        {
            _prescriptionRepository = prescriptionRepository;
        }
        public IEnumerable<Prescription> GetAll() 
            => _prescriptionRepository.GetAll();
        public Prescription GetById(long id)
            => _prescriptionRepository.GetById(id);
        public Prescription Save(Prescription prescription)
            => _prescriptionRepository.Save(prescription);

        public Prescription Update(Prescription prescription)
            => _prescriptionRepository.Update(prescription);

        public Prescription Remove(Prescription prescription)
            => _prescriptionRepository.Remove(prescription);

        public Prescription GetAllPrescriptionsByPatientsId(long id)
            => _prescriptionRepository.GetAllPrescriptionsByPatientsId(id);

    }
}
