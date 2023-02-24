using Project;
using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IPatientRepository : IRepository<Patient, long>
    {

        Patient GetByEmail(string email);
    }
}
