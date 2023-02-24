using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IMedicineRepository : IRepository<Medicine, long>
    {
        Medicine GetByName(string name);
    }

}