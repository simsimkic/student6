using Org.BouncyCastle.Asn1.Cms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class DoctorCSVConverter: ICSVConverter<Doctor>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
        private readonly string _timeFormat;


        public DoctorCSVConverter(string delimiter, string datetimeFormat,string timeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
            _timeFormat = timeFormat;
        }

        public string ConvertEntityToCSVFormat(Doctor doctor)
           => string.Join(_delimiter,
               doctor.Id,
               doctor.Address.Id,
               doctor.FirstName,
               doctor.LastName,
               doctor.Jmbg,
               doctor.TelephoneNumber,
               doctor.Gender,
               doctor.DateOfBirth.ToString(_datetimeFormat),
               doctor.Salary,
               doctor.AnnualLeave.Start.ToString(_datetimeFormat),
               doctor.AnnualLeave.End.ToString(_datetimeFormat),
               doctor.WorkingHours.Start.ToString(_timeFormat),
               doctor.WorkingHours.End.ToString(_timeFormat),
               doctor.Email,
               doctor.Password,
               doctor.MedicalRole
               );

        public Doctor ConvertCSVFormatToEntity(string doctorCSVFormat)
        {
            string[] tokens = doctorCSVFormat.Split(_delimiter.ToCharArray());
            return new Doctor(
                long.Parse(tokens[0]),
                new Address(long.Parse(tokens[1])),
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                tokens[6],
                DateTime.Parse(tokens[7]),
                int.Parse(tokens[8]),
                new TimeInterval(DateTime.ParseExact(tokens[9], _datetimeFormat,null), DateTime.ParseExact(tokens[10], _datetimeFormat, null)),
                new TimeInterval(DateTime.ParseExact(tokens[11], _timeFormat,null), DateTime.ParseExact(tokens[12], _timeFormat, null)),
                tokens[13],
                tokens[14],
                tokens[15]
            );
        }
    }
}
