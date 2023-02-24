using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class OrderCSVConverter : ICSVConverter<Order>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public OrderCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Order order)
        {
            return string.Join(_delimiter,
                order.Id,
                order.Date.ToString(_datetimeFormat),
                order.Supplier
                );
        }
        public Order ConvertCSVFormatToEntity(string orderCSVFormat)
        {
            string[] tokens = orderCSVFormat.Split(_delimiter.ToCharArray());
            try
            {
                return new Order(
                    long.Parse(tokens[0]),
                    DateTime.Parse(tokens[1]),
                    tokens[2],
                    new List<Equipment>(),
                    new List<MedicalConsumables>(),
                    new List<Medicine>()
                );

            }
            catch (System.Exception)
            {

                return new Order();
            }
        }
    }
}
