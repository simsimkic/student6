using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class OrderDetailsCSVConverter : ICSVConverter<OrderDetails>
    {
        private readonly string _delimiter;

        public OrderDetailsCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(OrderDetails order)
        {
            return string.Join(_delimiter,
                order.Id,
                order.OrderId,
                order.ItemId,
                order.Quantity
                );
        } 
        public OrderDetails ConvertCSVFormatToEntity(string orderCSVFormat)
        {
            string[] tokens = orderCSVFormat.Split(_delimiter.ToCharArray());
            return new OrderDetails(
                long.Parse(tokens[0]),
                long.Parse(tokens[1]),
                long.Parse(tokens[2]),
                long.Parse(tokens[3])
            );
        }
    }
}
