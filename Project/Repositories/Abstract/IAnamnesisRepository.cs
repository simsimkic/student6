using Project;
using Project.Model;
using System.Collections.Generic;

namespace Project.Repositories.Abstract
{
    public interface IAnamnesisRepository : IRepository<Anamnesis, long>
    {
        IEnumerable<Anamnesis> GetByMedicalAppointmentId(long id);
    }
}
