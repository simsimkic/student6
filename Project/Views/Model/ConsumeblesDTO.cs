// File:    Consumebles.cs
// Created: Saturday, April 18, 2020 7:48:20 PM
// Purpose: Definition of Class Consumebles

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;

namespace Project.Views.Model
{
    public class ConsumablesDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public List<MedicalAppointmentDTO> medicalAppointment { get; set; }
        public ConsumablesDTO() { }

        public ConsumablesDTO(string name, string type, string description, int quantity)
        {
            Name = name;
            Type = type;
            Description = description;
            Quantity = quantity;
        }

    }
}