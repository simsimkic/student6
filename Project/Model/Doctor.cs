// File:    Doctor.cs
// Created: Thursday, March 19, 2020 7:10:35 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;

namespace Project.Model
{
   public class Doctor : Employee
   {

      public string MedicalRole { get; set; }
      
      public List<Approval> Approval {get; set;}
      public List<MedicalAppointment> Appointments {get;set;}
      
      public Doctor() {}

      
      public Doctor(long id)
      {
          Id = id;
      }
      
      public Doctor(long id, Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, string medicalRole)
            :base(id,  address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password)
      {
            MedicalRole = medicalRole;
            Appointments = new List<MedicalAppointment>();
      }

      public Doctor(Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password, string medicalRole)
            : base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
      {
          MedicalRole = medicalRole;
            Appointments = new List<MedicalAppointment>();
      }
    }
}