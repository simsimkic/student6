using Project.Repositories.Abstract;
using System;

namespace Project.Model
{
    public class Referral : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }

        public Referral() { }

        public Referral(long id, DateTime date, MedicalAppointment medicalAppointment)
        {
            Id = id;
            Date = date;
            MedicalAppointment = medicalAppointment;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}