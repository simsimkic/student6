// File:    Prescription.cs
// Created: Thursday, March 19, 2020 7:30:56 PM
// Purpose: Definition of Class Prescription

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Prescription : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int Dosage { get; set; }
        public string Usage { get; set; }
        public string Period { get; set; }
        public Medicine Medicine {get; set;}
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public Prescription(int dosage, string usage, string period, DateTime date, Patient patient)
        {
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Date = date;
            Patient = patient;
        }

        public Prescription(long id, int dosage, string usage, string period, Medicine medicine, DateTime date, Patient patient)
        {
            Id = id;
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Medicine = medicine;
            Date = date;
            Patient = patient;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}