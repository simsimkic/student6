using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Project.Views.Model
{
    public class PropositionDTO
    {
        public long Id { get; set; }
        public string State { get; set; }
        public MedicineDTO Medicine { get; set; }


        public int Positive { get; set; }
        public int Negative { get; set; }

        public List<ApprovalDTO> Approvals { get; set; }

        public PropositionDTO() {  }

        public PropositionDTO(string description, string state, MedicineDTO medicine)
        {
            State = state;
            Medicine = medicine;
        }

        public PropositionDTO(long id, string state, int positive, int negative)
        {
            Id = id;
            State = state;
            Positive = positive;
            Negative = negative;
        }

        public PropositionDTO(long id, string state, MedicineDTO medicine)
        {
            Id = id;
            State = state;
            Medicine = medicine;
        }

        public PropositionDTO(long id, string state, int positive, int negative, string description, MedicineDTO medicine, List<ApprovalDTO> approvals)
        {
            Id = id;
            State = state;
            Positive = positive;
            Negative = negative;
            Medicine = medicine;
            Approvals = approvals;
        }

    }
}
