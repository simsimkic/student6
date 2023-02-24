// File:    Secretary.cs
// Created: Thursday, March 19, 2020 7:10:34 PM
// Purpose: Definition of Class Secretary

using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Secretary : Employee
    {
        public List<Question> Questions { get; set; }

        public Secretary(List<Question> questions)
        {
            Questions = questions;
        }

        public Secretary()
        {
        }
        public Secretary(Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
        {
        }

        public Secretary(long id,Address address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(id,address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth, salary, annualLeave, workingHours, email, password)
        {
        }

        public Secretary(long id)
        {
            Id = id;
        }
    }
}