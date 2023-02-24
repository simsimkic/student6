using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class ReviewCSVConverter:ICSVConverter<Review>
    {
        private readonly string _delimiter;
        public ReviewCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Review ConvertCSVFormatToEntity(string reviewCSVFormat)
        {
            string[] tokens = reviewCSVFormat.Split(_delimiter.ToCharArray());
            return new Review(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                tokens[2],
                new Doctor(long.Parse(tokens[3]))
            );
        }

        public string ConvertEntityToCSVFormat(Review review)
         => string.Join(_delimiter,
               review.Id,
               review.Rating,
               review.Description,
               review.Doctor.Id
               );
    }
}
