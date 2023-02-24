using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class MedicalConsumableService : IService<MedicalConsumables, long>
    {
        private readonly IMedicalConsumableRepository _medicalConsumableRepository;

        public MedicalConsumableService(IMedicalConsumableRepository medicalConsumableRepository) 
        {
            _medicalConsumableRepository = medicalConsumableRepository;
        }

        public IEnumerable<MedicalConsumables> GetAll()
         => _medicalConsumableRepository.GetAll();

        public MedicalConsumables GetById(long id)
         => _medicalConsumableRepository.GetById(id);

        public MedicalConsumables Remove(MedicalConsumables entity)
        => _medicalConsumableRepository.Remove(entity);

        public MedicalConsumables Save(MedicalConsumables entity)
         => _medicalConsumableRepository.Save(entity);

        public MedicalConsumables Update(MedicalConsumables entity)
        => _medicalConsumableRepository.Update(entity);
    }
}
