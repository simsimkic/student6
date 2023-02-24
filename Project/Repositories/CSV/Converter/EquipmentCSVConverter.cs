using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class EquipmentCSVConverter: ICSVConverter<Equipment>
    {
        private readonly string _delimiter;
        public EquipmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Equipment ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Equipment(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                tokens[3],
                new Room(long.Parse(tokens[4]))
            );
        }

        public string ConvertEntityToCSVFormat(Equipment equipment)
         => string.Join(_delimiter,
               equipment.Id,
               equipment.Type,
               equipment.Description,
               equipment.Name,
               equipment.Room.Id
               );
    }
}
