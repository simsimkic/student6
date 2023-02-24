// File:    Anamneza.cs
// Created: Friday, March 20, 2020 10:32:33 PM
// Purpose: Definition of Class Anamneza

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Anamnesis : IIdentifiable<long>
    {
        public long Id { get; set; }
        public long MedicalAppoitmentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Anamnesis(long id, long medicalAppoitmentId, string name, string type, string description)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            MedicalAppoitmentId = medicalAppoitmentId;
        }
        public Anamnesis(string name, long medicalAppoitmentId, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
            MedicalAppoitmentId = medicalAppoitmentId;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}