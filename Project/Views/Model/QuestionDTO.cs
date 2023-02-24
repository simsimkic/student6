using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class QuestionDTO
    {
        public long Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public PatientDTO Patient { get; set; }
        public SecretaryDTO Secretary { get; set; }
        public DateTime CreationDate { get; set; }

        public QuestionDTO()
        {
        }

        public QuestionDTO(long id, string questionText, string answerText, PatientDTO patient, SecretaryDTO secretary, DateTime creationDate)
        {
            Id = id;
            QuestionText = questionText;
            AnswerText = answerText;
            Patient = patient;
            Secretary = secretary;
            CreationDate = creationDate;
        }


        public QuestionDTO(string questionText, string answerText, PatientDTO patient, SecretaryDTO secretary, DateTime creationDate)
        {
            QuestionText = questionText;
            AnswerText = answerText;
            Patient = patient;
            Secretary = secretary;
            CreationDate = creationDate;
        }
    }
}
