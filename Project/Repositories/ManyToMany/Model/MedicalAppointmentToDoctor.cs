using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.ManyToMany.Model
{
    public class MedicalAppointmentToDoctor : IIdentifiable<long>
    {
        public long Id { get; set;  }
        public long MedicalAppointmentId { get; set; }
        public long DoctorId { get; set; }

        public MedicalAppointmentToDoctor()
        {
        }

        public MedicalAppointmentToDoctor(long medicalAppointmentId, long doctorId)
        {
            MedicalAppointmentId = medicalAppointmentId;
            DoctorId = doctorId;
        }
        public MedicalAppointmentToDoctor(long id, long medicalAppointmentId, long doctorId)
        {
            Id = id;
            MedicalAppointmentId = medicalAppointmentId;
            DoctorId = doctorId;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
