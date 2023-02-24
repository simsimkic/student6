using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class RoomCSVConverter:ICSVConverter<Room>
    {
        private readonly string _delimiter;
        public RoomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Room room)
          => string.Join(_delimiter,
              room.Id,
              room.Type,
              room.Ward,
              room.Floor
              );

        public Room ConvertCSVFormatToEntity(string questionCSVFormat)
        {
            string[] tokens = questionCSVFormat.Split(_delimiter.ToCharArray());
            return new Room(
                long.Parse(tokens[0]),
                (RoomType)Enum.Parse(typeof(RoomType),tokens[1]),
                tokens[2],
                tokens[3]
            );
        }

    }
}
