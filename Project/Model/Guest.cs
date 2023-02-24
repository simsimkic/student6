// File:    Patient.cs
// Created: Friday, April 17, 2020 2:46:58 PM
// Purpose: Definition of Class Patient

using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Guest : User
    {
        public string InsurenceNumber { get; set; }
        public string Profession { get; set; }
        public string BloodType { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public List<MedicalAppointment> Appointments { get; set; }

        public Guest() { }

        public Guest(long id) : base(id) { } 

        public Guest(long id, Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insurenceNumber, string profession, string bloodType, float height, float weight)
         : base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            InsurenceNumber = insurenceNumber;
            Profession = profession;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
        }
        public Guest(Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insurenceNumber, string profession, string bloodType, float height, float weight)
         : base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            InsurenceNumber = insurenceNumber;
            Profession = profession;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
        }
    }
}