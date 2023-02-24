using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
    public interface IMedicalAppointmentService : IService<MedicalAppointment,long>
    {
        bool IsAvailableAtTimeInterval(MedicalAppointment medicalAppointment, TimeInterval timeInterval);
        IEnumerable<MedicalAppointment> GetAllByPatientId(long id);
        IEnumerable<MedicalAppointment> GetAllByDoctorID(long id);

        IEnumerable<MedicalAppointment> GetAvailableAppoitments(Doctor doctor,Room room,TimeInterval timeInterval);
        IEnumerable<MedicalAppointment> SuggestAvailableAppoitments(string priority,Doctor doctor,TimeInterval timeInterval);

    }
}
