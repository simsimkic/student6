using Project.Model;
using System;

namespace Project.Repositories.CSV.Converter
{
    public class AnamnesisCSVConverter : ICSVConverter<Anamnesis>
    {
        private readonly string _delimiter;


        public AnamnesisCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Anamnesis anamnesis)
            => string.Join(_delimiter, anamnesis.Id, anamnesis.MedicalAppoitmentId, anamnesis.Name, anamnesis.Type, anamnesis.Description);


        public Anamnesis ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Anamnesis(
                long.Parse(tokens[0]),
                long.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                tokens[3]
                );
        }
          
    }
}
