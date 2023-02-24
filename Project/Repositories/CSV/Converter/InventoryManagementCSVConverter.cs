using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class InventoryManagementCSVConverter : ICSVConverter<InventoryManagement>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public InventoryManagementCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public InventoryManagement ConvertCSVFormatToEntity(string inventoryCSVFormat)
        {
            string[] tokens = inventoryCSVFormat.Split(_delimiter.ToCharArray());
            return new InventoryManagement(
                long.Parse(tokens[0]),
                DateTime.ParseExact(tokens[1], _datetimeFormat, null),
                DateTime.ParseExact(tokens[2], _datetimeFormat, null),
                new Room(long.Parse(tokens[3])),
                new Room(long.Parse(tokens[4]))
            );
        }

        public string ConvertEntityToCSVFormat(InventoryManagement inventory)
        {
            return string.Join(_delimiter,
                inventory.Id,
                inventory.Beginning.ToString(_datetimeFormat),
                inventory.End.ToString(_datetimeFormat),
                inventory.Room.Id,
                inventory.RoomTo.Id
                );
        }
    }
}
