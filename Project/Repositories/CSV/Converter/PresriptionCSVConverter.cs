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
    class PrescriptionCSVConverter : ICSVConverter<Prescription>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public PrescriptionCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;


        }

        public string ConvertEntityToCSVFormat(Prescription prescription)
           => string.Join(_delimiter,
               prescription.Id,
               prescription.Dosage,
               prescription.Usage,
               prescription.Period,
               prescription.Medicine.Id,
               prescription.Date.ToString(_datetimeFormat),
               prescription.Patient.Id
               );

        public Prescription ConvertCSVFormatToEntity(string prescriptionCSVFormat)
        {
            string[] tokens = prescriptionCSVFormat.Split(_delimiter.ToCharArray());
            return new Prescription(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                new Medicine(long.Parse(tokens[4])),
                DateTime.ParseExact(tokens[5], _datetimeFormat, null),
                new Patient(long.Parse(tokens[6]))
            );
        }
    }
}
