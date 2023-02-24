using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV.Converter
{
    class FeedbackCSVConverter:ICSVConverter<Feedback>
    {
        private readonly string _delimiter;
        public FeedbackCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Feedback feedback)
          => string.Join(_delimiter,
              feedback.Id,
              feedback.Issue,
              feedback.Description
              );

        public Feedback ConvertCSVFormatToEntity(string feedbackCSVFormat)
        {
            string[] tokens = feedbackCSVFormat.Split(_delimiter.ToCharArray());
            return new Feedback(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2]
            );
        }

    }
}
