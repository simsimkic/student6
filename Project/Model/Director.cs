// File:    Director.cs
// Created: Thursday, March 19, 2020 7:10:36 PM
// Purpose: Definition of Class Director

using System;
using System.Collections;
using System.Collections.Generic;

namespace Project.Model
{
    public class Director : Employee
    {
        public override bool Equals(object obj)
        {
            return obj is Director director &&
                   Id == director.Id &&
                   FirstName == director.FirstName &&
                   LastName == director.LastName &&
                   Jmbg == director.Jmbg &&
                   TelephoneNumber == director.TelephoneNumber &&
                   Gender == director.Gender &&
                   DateOfBirth == director.DateOfBirth &&
                   EqualityComparer<List<Feedback>>.Default.Equals(Feedbacks, director.Feedbacks) &&
                   EqualityComparer<Address>.Default.Equals(Address, director.Address) &&
                   EqualityComparer<List<Report>>.Default.Equals(Reports, director.Reports) &&
                   Salary == director.Salary &&
                   EqualityComparer<TimeInterval>.Default.Equals(AnnualLeave, director.AnnualLeave) &&
                   EqualityComparer<TimeInterval>.Default.Equals(WorkingHours, director.WorkingHours) &&
                   Email == director.Email &&
                   Password == director.Password &&
                   EqualityComparer<Hospital>.Default.Equals(Hospital, director.Hospital);
        }
    }
}