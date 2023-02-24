using Project.Model;

namespace Project.Repositories.CSV.Converter
{
    public class ApprovalCSVConverter : ICSVConverter<Approval>
    {
        private readonly string _delimiter;

        public ApprovalCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Approval approval)
          => string.Join(_delimiter,
              approval.Id,
              approval.Description,
              approval.IsApproved,
              approval.Doctor,
              approval.Proposition
              );

        public Approval ConvertCSVFormatToEntity(string approvalCSVFormat)
        {
            string[] tokens = approvalCSVFormat.Split(_delimiter.ToCharArray());
            return new Approval(
                long.Parse(tokens[0]),
                tokens[1],
                bool.Parse(tokens[2]),
                new Doctor(long.Parse(tokens[3])),
                new Proposition(long.Parse(tokens[4]))
                );
        }
    }
}
