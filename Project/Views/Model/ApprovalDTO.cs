using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{

    public class ApprovalDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PropositionDTO Proposition { get; set; }

        public ApprovalDTO() { }

        public ApprovalDTO(long id, string desc, bool approved, DoctorDTO doctor, PropositionDTO Proposition)
        {
            this.Description = desc;
            this.IsApproved = approved;
            this.Doctor = doctor;
            this.Proposition = Proposition;
        }
    }
}
