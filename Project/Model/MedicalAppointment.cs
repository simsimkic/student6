// File:    MedicalAppointment.cs
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;
using System.Windows.Documents;
using System.Collections.Generic;

namespace Project.Model
{
    public class MedicalAppointment : Appointment
    {
        public MedicalAppointmentType Type { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Guest Patient{ get; set; }

        public List<Item> Consumebles{ get; set; }
        public Review Review{ get; set; }
        public List<Anamnesis> Anamnesis { get; set; }
        public MedicalAppointment(long id) : base(id) { }

        public MedicalAppointment(long id, DateTime dateTime) { }
        public MedicalAppointment(DateTime beginning, DateTime end, Room room, MedicalAppointmentType type, Guest patient)
        : base(beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = new List<Doctor>();
        }
        public MedicalAppointment(long id, DateTime beginning, DateTime end, Room room, MedicalAppointmentType type, Guest patient)
        : base(id, beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = new List<Doctor>();
        }

        public MedicalAppointment(long id, DateTime beginning, DateTime end, Room room, MedicalAppointmentType type, Guest patient, List<Doctor> doctors)
        : base(id, beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = doctors;
        }
        public MedicalAppointment(DateTime beginning, DateTime end, Room room, MedicalAppointmentType type, Guest patient, List<Doctor> doctors)
        : base(beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = doctors;
        }

    }
}
