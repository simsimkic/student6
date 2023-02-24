using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{

    public class Approval : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Description {get;set;}
        public bool IsApproved {get;set;}
        public Doctor Doctor { get ; set; }
        public Proposition Proposition { get; set; }

        public Approval() { } 
        public Approval(long id)
        {
            Id = Id;
        }

        public Approval(long id, string description, bool isApproved, Doctor doctor, Proposition proposition)
        {
            Id = id;
            Description = description;
            IsApproved = isApproved;
            Doctor = doctor;
            Proposition = proposition;
        }

        public Approval(string description, bool isApproved, Doctor doctor, Proposition proposition)
        {
            Description = description;
            IsApproved = isApproved;
            Doctor = doctor;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
