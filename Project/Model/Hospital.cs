// File:    Hospital.cs
// Created: Thursday, March 19, 2020 8:23:57 PM
// Purpose: Definition of Class Hospital

using System;
using System.Collections.Generic;


namespace Project.Model
{
    public class Hospital
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public List<Medicine> Medicines { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Room> Rooms { get; set; }
        public List<MedicalConsumables> Consumables { get; set; }

        public Hospital()
        {

        }

        public Hospital(string name, Address address, List<Medicine> medicines, List<Employee> employees, List<Room> rooms, List<MedicalConsumables> consumebles)
        {
            Name = name;
            Address = address;
            Medicines = medicines;
            Employees = employees;
            Rooms = rooms;
            Consumables = consumebles;
        }

    }
}