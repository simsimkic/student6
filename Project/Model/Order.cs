// File:    Order.cs
// Created: Thursday, March 19, 2020 8:05:24 PM
// Purpose: Definition of Class Order

using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class Order : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Supplier { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<MedicalConsumables> Consumebles { get; set; }

        public List<Medicine> Medicine { get; set; }

        public Order() { }
        public Order(long id, DateTime date, string supplier, List<Equipment> equipments, List<MedicalConsumables> consumebles, List<Medicine> medicine)
        {
            Id = id;
            Date = date;
            Supplier = supplier;
            Equipments = equipments;
            Consumebles = consumebles;
            Medicine = medicine;
        }

        public Order(DateTime date, string supplier, List<Equipment> equipments, List<MedicalConsumables> consumebles, List<Medicine> medicine)
        {
            Date = date;
            Supplier = supplier;
            Equipments = equipments;
            Consumebles = consumebles;
            Medicine = medicine;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}