using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace Project.Views.Converters
{
    public class OrderConverter : IConverter<Order, OrderDTO>
    {
        private MedicalConsumableConverter _medicalConsumableConverter;
        private MedicineConverter _medicineConverter;
        private EquipmentConverter _equipmentConverter;

        public OrderConverter(MedicalConsumableConverter medicalConsumableConverter,
            MedicineConverter medicineConverter,
            EquipmentConverter equipmentConverter
        )
        {
            _medicalConsumableConverter = medicalConsumableConverter;
            _medicineConverter = medicineConverter;
            _equipmentConverter = equipmentConverter;
        }

        public Order ConvertDTOToEntity(OrderDTO dto)
        {
            List<Medicine> medicine = dto.Medicine.Select(med => _medicineConverter.ConvertDTOToEntity(med)).ToList();
            List<MedicalConsumables> consumables = dto.Consumables.Select(con => _medicalConsumableConverter.ConvertDTOToEntity(con)).ToList();
            List<Equipment> equipment = dto.Equipment.Select(eq => _equipmentConverter.ConvertDTOToEntity(eq)).ToList();

            return new Order(dto.Id, dto.Date, dto.Supplier, equipment, consumables, medicine);
        }

        public OrderDTO ConvertEntityToDTO(Order entity)
        {

            List<MedicineDTO> medicineDTO = entity.Medicine.Select(med => _medicineConverter.ConvertEntityToDTO(med)).ToList();
            List<MedicalConsumableDTO> consumablesDTO = entity.Consumebles.Select(con => _medicalConsumableConverter.ConvertEntityToDTO(con)).ToList();
            List<EquipmentDTO> equipmentDTO = entity.Equipments.Select(eq => _equipmentConverter.ConvertEntityToDTO(eq)).ToList();

            return new OrderDTO(entity.Id, entity.Date, entity.Supplier, equipmentDTO, consumablesDTO, medicineDTO);
        }

        public List<Order> ConvertListDTOToListEntity(IEnumerable<OrderDTO> dtos)
         => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<OrderDTO> ConvertListEntityToListDTO(List<Order> entities)
         => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
