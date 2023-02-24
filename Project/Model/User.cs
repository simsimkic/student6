// File:    User.cs
// Created: Thursday, March 19, 2020 7:12:43 PM
// Purpose: Definition of Class User

using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class User : IIdentifiable<long>
    {
        public long Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public string TelephoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Feedback> Feedbacks;
        public Address Address;

        public List<Report> Reports { get; set; }
        public User() { }

        public User(long id, Address address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
        {
            Id = id;
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
        public User(Address address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
        {
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public User(long id)
        {
            this.Id = id;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }

}