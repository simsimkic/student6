// File:    Feedback.cs
// Created: Friday, April 17, 2020 5:29:24 PM
// Purpose: Definition of Class Feedback

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Feedback : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }

        public Feedback()
        {
        }
        public Feedback(string issue, string description) {
            Issue = issue;
            Description = description;
        }
        public Feedback(long id,string issue, string description)
        {
            Id = id;
            Issue = issue;
            Description = description;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}