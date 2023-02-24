// File:    Review.cs
// Created: Friday, April 17, 2020 5:21:46 PM
// Purpose: Definition of Class Review

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Review : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

        public Doctor Doctor { get; set; }
        public Review() { }

        public Review(long id)
        {
            Id = id;
        }


        public Review(int rating, string description, Doctor doctor)
        {
            Rating = rating;
            Description = description;
            Doctor = doctor;
        }
        public Review(long id, int rating, string description, Doctor doctor)
        {
            Id = id;
            Rating = rating;
            Description = description;
            Doctor = doctor;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}