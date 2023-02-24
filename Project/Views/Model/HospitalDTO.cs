using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Views.Model
{
    public class HospitalDTO
    {
        public string Name { get; set; }
        public AddressDTO Address { get; set; }

        public List<MedicineDTO> Medicines { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
        public List<RoomDTO> Rooms { get; set; }
        public List<MedicalConsumableDTO> Consumables { get; set; }

        public HospitalDTO() { }
        public HospitalDTO(string name, AddressDTO address, List<MedicineDTO> medicines, List<EmployeeDTO> employees, List<RoomDTO> rooms, List<MedicalConsumableDTO> consumebles)
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
