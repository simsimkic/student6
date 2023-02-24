// File:    MedicalConsumables.cs
// Created: Saturday, April 18, 2020 7:56:35 PM
// Purpose: Definition of Class MedicalConsumables

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class MedicalConsumables : Item
    {
        public MedicalConsumables()
        { }

        public MedicalConsumables(long id) :base (id) {}
        public MedicalConsumables(long id,int quantity, string type, string description, string name)
        {
            Id = id;
            Quantity = quantity;
            Type = type;
            Description = description;
            Name = name;
        }

        public MedicalConsumables(int quantity, string type, string description, string name)
        {
            Quantity = quantity;
            Type = type;
            Description = description;
            Name = name;
        }


    }
}