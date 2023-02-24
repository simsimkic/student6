using System.Collections.Generic;
using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IMedicalAppointmentRepository : IRepository<MedicalAppointment, long>
    {
        IEnumerable<MedicalAppointment> GetAllByPatientId(long id);
        IEnumerable<MedicalAppointment> GetAllByDoctorId(long id);
    }
}
