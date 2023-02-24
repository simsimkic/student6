using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class MedicalConsumableCSVConverter: ICSVConverter<MedicalConsumables>
    {
        private readonly string _delimiter;
        public MedicalConsumableCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(MedicalConsumables medicalConsumables)
           => string.Join(_delimiter,
               medicalConsumables.Id,
               medicalConsumables.Quantity,
               medicalConsumables.Type,
               medicalConsumables.Description,
               medicalConsumables.Name
               );

        public MedicalConsumables ConvertCSVFormatToEntity(string medConsumableCSVFormat)
        {
            string[] tokens = medConsumableCSVFormat.Split(_delimiter.ToCharArray());
            return new MedicalConsumables(
                long.Parse(tokens[0]),
                int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                tokens[4]
            );
        }
    }
}
