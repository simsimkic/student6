using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories.Abstract;

namespace Project.Services
{
    public class EmployeeService
    {
        private IRepository<Secretary, long> _secretaryRepository;
        private IRepository<Doctor, long> _doctorRepository;
        public EmployeeService(
            IRepository<Secretary, long> secretaryRepository,
            IRepository<Doctor, long> doctorRepository
         )
        {
            _secretaryRepository = secretaryRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Employee> GetAll()
            =>  (_secretaryRepository.GetAll() as List<Employee>)
            .Concat(_doctorRepository.GetAll() as List<Employee>);

        public Employee GetById(long id)
            => GetAll().Where(item => item.Id == id).First();
        public Employee GetByEmail(string email)
            => GetAll().Where(item => item.Email == email).First();

    }
}
