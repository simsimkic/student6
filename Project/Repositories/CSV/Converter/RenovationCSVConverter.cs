using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class RenovationCSVConverter: ICSVConverter<Renovation>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public RenovationCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Renovation renovation)
           => string.Join(_delimiter,
               renovation.Id,
               renovation.Beginning.ToString(_datetimeFormat),
               renovation.End.ToString(_datetimeFormat),
               renovation.Room.Id,
               renovation.Type,
               renovation.NewType
               );

        public Renovation ConvertCSVFormatToEntity(string renovationCSVFormat)
        {
            string[] tokens = renovationCSVFormat.Split(_delimiter.ToCharArray());
            return new Renovation(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                new Room(long.Parse(tokens[3])),
                tokens[4],
                (RoomType)Enum.Parse(typeof(RoomType),tokens[5])
            );
        }

    }
}
