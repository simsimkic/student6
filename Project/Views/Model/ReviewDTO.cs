// File:    Review.cs
// Created: Friday, April 17, 2020 5:21:46 PM
// Purpose: Definition of Class Review

using System;

namespace Project.Views.Model
{
    public class ReviewDTO
    {
        public long Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

        public DoctorDTO Doctor{get; set;}

        public ReviewDTO(int rating, string description,DoctorDTO doctor)
        {
            Rating = rating;
            Description = description;
            Doctor = doctor;
        }
        public ReviewDTO(int rating, string description)
        {
            Rating = rating;
            Description = description;
        }

        public ReviewDTO(long id,int rating, string description,DoctorDTO doctor)
        {
            Id = id;
            Rating = rating;
            Description = description;
            Doctor = doctor;
        }

        public ReviewDTO()
        {
        }
    }
}