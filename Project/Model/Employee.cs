// File:    Employee.cs
// Created: Thursday, March 19, 2020 7:20:36 PM
// Purpose: Definition of Class Employee

using System;

namespace Project.Model
{
   public class Employee : User
   {
      public int Salary { get; set; }
      public TimeInterval AnnualLeave { get; set; }
      public TimeInterval WorkingHours { get; set; }
      public string Email {get;set;}
      public string Password {get;set;}
      
      public Hospital Hospital { get; set; }
   
      public Employee() {}
      public Employee(long id, Address address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password): 
            base( id,  address, firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth) {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
      }

        public Employee(Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
        }
    }
}