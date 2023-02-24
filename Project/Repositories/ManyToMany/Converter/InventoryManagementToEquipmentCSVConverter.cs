using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repositories.CSV.Converter;
using Project.Repositories.ManyToMany.Model;

namespace Project.Repositories.ManyToMany.Converter
{
    class InventoryManagementToEquipmentCSVConverter : ICSVConverter<InventoryManagementToEquipment>
    {
        private readonly string _delimiter;

        public InventoryManagementToEquipmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(InventoryManagementToEquipment order)
        {
            return string.Join(_delimiter,
                order.Id,
                order.InventoryManagementId,
                order.EquipmentId
                );
        } 
        public InventoryManagementToEquipment ConvertCSVFormatToEntity(string orderCSVFormat)
        {
            string[] tokens = orderCSVFormat.Split(_delimiter.ToCharArray());
            return new InventoryManagementToEquipment(
                long.Parse(tokens[0]),
                long.Parse(tokens[1]),
                long.Parse(tokens[2])
            );
        }
    }
}
