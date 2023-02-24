using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class MedicineDTO : ItemDTO
    {
        public long Id { get; set; }
        public string Purpose { get; set; }
        public string Administration { get; set; }
        public bool Approved { get; set; }
        public List<MedicineDTO> Alternatives { get; set; }

        public MedicineDTO() { }

        public MedicineDTO(long id, string name, string type, string description, int quantity,string purpose,string administration, bool approved)
            : base(name, type, description, quantity)
        {
            Id = id; 
            Purpose = purpose;
            Administration = administration;
            Approved = approved;
        }

        public MedicineDTO(string name, string type, string description, int quantity, string purpose, string administration, bool approved)
            : base(name, type, description, quantity)
        {
            
            Purpose = purpose;
            Administration = administration;
            Approved = approved;
        }

    }
}
