using Project.Model;


namespace Project.Repositories.Abstract
{
    public interface IPrescriptionRepository : IRepository<Prescription, long>
    {
        Prescription GetAllPrescriptionsByPatientsId(long id);
    }
}
