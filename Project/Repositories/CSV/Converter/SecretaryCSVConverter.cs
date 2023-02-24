using Org.BouncyCastle.Asn1.Cms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class SecretaryCSVConverter: ICSVConverter<Secretary>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
        private readonly string _timeFormat;

        public SecretaryCSVConverter(string delimiter, string datetimeFormat,string timeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
            _timeFormat = timeFormat;
        }

        public string ConvertEntityToCSVFormat(Secretary secretary)
           => string.Join(_delimiter,
               secretary.Id,
               secretary.Address.Id,
               secretary.FirstName,
               secretary.LastName,
               secretary.Jmbg,
               secretary.TelephoneNumber,
               secretary.Gender,
               secretary.DateOfBirth.ToString(_datetimeFormat),
               secretary.Salary,
               secretary.AnnualLeave.Start.ToString(_datetimeFormat),
               secretary.AnnualLeave.End.ToString(_datetimeFormat),
               secretary.WorkingHours.Start.ToString(_timeFormat),
               secretary.WorkingHours.End.ToString(_timeFormat),
               secretary.Email,
               secretary.Password
               );

        public Secretary ConvertCSVFormatToEntity(string secretaryCSVFormat)
        {
            string[] tokens = secretaryCSVFormat.Split(_delimiter.ToCharArray());
            return new Secretary(
                long.Parse(tokens[0]),
                new Address(long.Parse(tokens[1])),
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                tokens[6],
                DateTime.ParseExact(tokens[7], _datetimeFormat, null),
                int.Parse(tokens[8]),
                new TimeInterval(DateTime.ParseExact(tokens[9], _datetimeFormat, null), DateTime.ParseExact(tokens[10], _datetimeFormat, null)),
                new TimeInterval(DateTime.ParseExact(tokens[11], _timeFormat, null), DateTime.ParseExact(tokens[12], _timeFormat, null)),
                tokens[13],
                tokens[14]
            );
        }
    }
}
