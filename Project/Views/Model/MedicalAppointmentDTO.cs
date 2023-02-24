// File:    MedicalAppointment.cs
// Created: Saturday, April 18, 2020 1:03:03 AM
// Purpose: Definition of Class MedicalAppointment

using System;
using System.Windows.Documents;
using Project.Model;
using System.Collections.Generic;

namespace Project.Views.Model
{
    public class MedicalAppointmentDTO : AppointmentDTO
    {
        public MedicalAppointmentType Type { get; set; }
        public IEnumerable<DoctorDTO> Doctors { get; set; }
        public GuestDTO Patient { get; set; }
        public bool IsScheduled { get; set; }
        public ReviewDTO Review { get; set; }
        //public IEnumerable<ConsumabelsDTO> Consumebles;
        public List<AnamnesisDTO> Anamnesis { get; set; }

        public MedicalAppointmentDTO() { }


        public MedicalAppointmentDTO(DateTime beginning, DateTime end, RoomDTO room, MedicalAppointmentType type, GuestDTO patient, IEnumerable<DoctorDTO> doctors)
        : base(beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = doctors;
        }
        public MedicalAppointmentDTO(long id, DateTime beginning, DateTime end, RoomDTO room, MedicalAppointmentType type, GuestDTO patient, IEnumerable<DoctorDTO> doctors)
        : base(id, beginning, end, room)
        {
            Type = type;
            Patient = patient;
            Doctors = doctors;
        }


    }
}