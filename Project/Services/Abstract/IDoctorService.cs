using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Abstract
{
    public interface IDoctorService : IService<Doctor,long>
    {

         bool IsDoctorAvailable(int doctorID);

         List<Doctor> GetAailableDoctors(Array doctorsID);

         List<Doctor> GetAailableDoctors(TimeInterval timeInterval);

         List<Doctor> GetAvailableDoctorsTimeInterval(MedicalAppointment medicalAppointment);

         Doctor GetByEmail(string email);

         List<Doctor> GetAllDoctorsBySpecialization(string specialization); 
    }
}
