// File:    RegistredPatient.cs
// Created: Friday, April 17, 2020 2:53:38 PM
// Purpose: Definition of Class RegistredPatient

using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Patient : Guest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Question> Questions { get; set; }

        public List<Prescription> Prescriptions { get; set; }
        public Patient() { }
        public Patient(long id) 
        { 
            Id = id; 
        }

        public Patient(long id, Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insurenceNumber, string profession, string bloodType, float height, float weight, string email, string password)
            : base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, insurenceNumber, profession, bloodType, height, weight)
        {
            Email = email;
            Password = password;
        }
        public Patient(Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, string insurenceNumber, string profession, string bloodType, float height, float weight, string email, string password)
            : base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, insurenceNumber, profession, bloodType, height, weight)
        {
            Email = email;
            Password = password;
        }
    }

}