using System.Collections.Generic;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;
using Project.Services.Abstract;

namespace Project.Services
{
    class AnamnesisService : IAnamnesisService
    {
        private readonly IAnamnesisRepository _anamnesisRepository;

        public AnamnesisService(IAnamnesisRepository anamnesisRepository)
        {
            _anamnesisRepository = anamnesisRepository;
        }

        public IEnumerable<Anamnesis> GetAll()
            => _anamnesisRepository.GetAll();

        public Anamnesis GetById(long id)
            => _anamnesisRepository.GetById(id);

        public IEnumerable<Anamnesis> GetByMedicalAppointmentId(long id)
            => _anamnesisRepository.GetByMedicalAppointmentId(id);

        public Anamnesis Remove(Anamnesis entity)
            => _anamnesisRepository.Remove(entity);

        public Anamnesis Save(Anamnesis entity)
            => _anamnesisRepository.Save(entity);

        public Anamnesis Update(Anamnesis entity)
            => _anamnesisRepository.Update(entity);
    }
}
