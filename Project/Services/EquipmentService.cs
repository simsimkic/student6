using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class EquipmentService : IService<Equipment, long>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public IEnumerable<Equipment> GetAll()
            => _equipmentRepository.GetAll();

        public Equipment GetById(long id)
            => _equipmentRepository.GetById(id);

        public Equipment Remove(Equipment entity)
            => _equipmentRepository.Remove(entity);

        public Equipment Save(Equipment entity)
            => _equipmentRepository.Save(entity);

        public Equipment Update(Equipment entity)
            => _equipmentRepository.Update(entity);
    }
}
