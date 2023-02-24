using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class OrderDTO
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Supplier { get; set; }

        public List<EquipmentDTO> Equipment { get; set; }

        public List<MedicalConsumableDTO> Consumables { get; set; }

        public List<MedicineDTO> Medicine { get; set; }

        public OrderDTO(long id, DateTime date, string supplier, List<EquipmentDTO> equipments, List<MedicalConsumableDTO> consumebles,List<MedicineDTO> medicine)
        {
            Id = id;
            Date = date;
            Supplier = supplier;
            Equipment = equipments;
            Consumables = consumebles;
            Medicine = medicine;
        }

        public OrderDTO(DateTime date, string supplier, List<EquipmentDTO> equipments, List<MedicalConsumableDTO> consumebles, List<MedicineDTO> medicine)
        {
            Date = date;
            Supplier = supplier;
            Equipment = equipments;
            Consumables = consumebles;
            Medicine = medicine;
        }


    }
}
