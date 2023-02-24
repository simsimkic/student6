using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class ReferralDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public MedicalAppointmentDTO MedicalAppointment { get; set; }

        public ReferralDTO() { }

        public ReferralDTO(long id, DateTime date, MedicalAppointmentDTO medicalAppointment)
        {
            Id = id;
            Date = date;
            MedicalAppointment = medicalAppointment;
        }

    }
}
