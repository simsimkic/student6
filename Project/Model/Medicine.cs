// File:    Medicine.cs
// Created: Thursday, March 19, 2020 7:29:51 PM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Medicine : Item
    {
        public string Purpose { get; set; }
        public string Administration { get; set; }
        public bool Approved { get; set; }
        public List<Medicine> Alternatives { get; set; }
        public Medicine() : base() { }

        public Medicine(long id) : base(id) { }

        public Medicine(long id, string purpose, string administration, bool approved, int quantity, string type, string description, string name)
        : base(quantity, type, description, name)
        {
            Id = id;
            Purpose = purpose;
            Administration = administration;
            Approved = approved;
        }
        public Medicine(string purpose, string administration, bool approved, int quantity, string type, string description, string name)
        : base(quantity, type, description, name)
        {
            Purpose = purpose;
            Administration = administration;
            Approved = approved;
        }

    }
}