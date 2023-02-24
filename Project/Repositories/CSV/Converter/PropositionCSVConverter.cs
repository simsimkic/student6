using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Repositories.CSV.Converter
{
    class PropositionCSVConverter : ICSVConverter<Proposition>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public PropositionCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Proposition proposition)
           => string.Join(_delimiter,
               proposition.Id,
               proposition.State,
               proposition.Medicine.Id
               );

        public Proposition ConvertCSVFormatToEntity(string propositionCSVFormat)
        {
            string[] tokens = propositionCSVFormat.Split(_delimiter.ToCharArray());
            return new Proposition(
                long.Parse(tokens[0]),
                tokens[1],
                new List<Approval>(),
                new Medicine(long.Parse(tokens[0]))
            );
        }
    }
}
