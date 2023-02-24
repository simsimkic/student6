// File:    Consumebles.cs
// Created: Saturday, April 18, 2020 7:48:20 PM
// Purpose: Definition of Class Consumebles

using System;

namespace Project.Model
{
    public class Consumebles
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Consumebles(int quantity, string type, string description, string name)
        {
            Quantity = quantity;
            Type = type;
            Description = description;
            Name = name;
        }

        public Consumebles()
        {
        }
    }
}