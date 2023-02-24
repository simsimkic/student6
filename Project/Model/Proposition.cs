// File:    Proposition.cs
// Created: Saturday, April 18, 2020 12:29:10 AM
// Purpose: Definition of Class Proposition

using System;
using System.Collections.Generic;
using Project.Repositories.Abstract;
using Project.Services.State;

namespace Project.Model
{
    public class Proposition : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string State { get; set; }
        public IPropositionState CurrentState { get; set; }
        public List<Approval> Approval { get; set; }
        public Medicine Medicine { get; set; }
      
        public Proposition() {}

        public Proposition(long Id)
        {
            this.Id = Id;
        }

        public Proposition(string state, List<Approval> approval, Medicine medicine)
        {
            State = state;
            Approval = approval;
            Medicine = medicine;
        }

        public Proposition(long id, string state, List<Approval> approval, Medicine medicine)
        {
            Id = id;
            State = state;
            Approval = approval;
            Medicine = medicine;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}