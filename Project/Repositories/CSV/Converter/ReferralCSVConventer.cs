using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Repositories.CSV.Converter
{
    class ReferralCSVConventer : ICSVConverter<Model.Referral>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;

        public ReferralCSVConventer(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;
        }

        public string ConvertEntityToCSVFormat(Model.Referral referral)
           => string.Join(_delimiter,
               referral.Id,
               referral.Date.ToString(_datetimeFormat),
               referral.MedicalAppointment.Id
               );

        public Model.Referral ConvertCSVFormatToEntity(string referralCSVFormat)
        {
            string[] tokens = referralCSVFormat.Split(_delimiter.ToCharArray());
            return new Model.Referral(
                long.Parse(tokens[0]),
                DateTime.Parse(tokens[1]),
                new MedicalAppointment(long.Parse(tokens[2]))
            );
        }

    }
}
