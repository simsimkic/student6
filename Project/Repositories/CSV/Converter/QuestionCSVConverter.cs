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
    class QuestionCSVConverter : ICSVConverter<Question>
    {
        private readonly string _delimiter;
        private readonly string _datetimeFormat;
        private IRepository<Patient, long> _patientRepository;

        public QuestionCSVConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _datetimeFormat = datetimeFormat;

        }

        public string ConvertEntityToCSVFormat(Question question)
           => string.Join(_delimiter,
               question.Id,
               question.QuestionText,
               question.AnswerText,
               question.Patient.Id,
               question.Secretary.Id,
               question.CreationDate.ToString(_datetimeFormat)
               );

        public Question ConvertCSVFormatToEntity(string questionCSVFormat)
        {
            string[] tokens = questionCSVFormat.Split(_delimiter.ToCharArray());
            return new Question(
                long.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                new Patient(),
                new Secretary(),
                DateTime.Parse(tokens[5])
            );
        }
    }
}
