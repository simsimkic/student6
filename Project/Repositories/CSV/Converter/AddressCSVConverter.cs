using Project.Model;

namespace Project.Repositories.CSV.Converter
{
    public class AddressCSVConverter : ICSVConverter<Address>
    {
        private readonly string _delimiter;

        public AddressCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Address address)
          => string.Join(_delimiter,
              address.Id,
              address.Number,
              address.Street,
              address.City,
              address.Country,
              address.PostCode );

        public Address ConvertCSVFormatToEntity(string addressCSVFormat)
        {
            string[] tokens = addressCSVFormat.Split(_delimiter.ToCharArray());
            try
            {
                return new Address(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5] );
                
            }
            catch (System.Exception)
            {
                
                return new Address();
            }
        }
    }
}
