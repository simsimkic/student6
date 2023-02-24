// File:    Question.cs
// Created: Tuesday, April 21, 2020 10:59:49 PM
// Purpose: Definition of Class Question

using Project.Repositories.Abstract;
using Project.Views.Model;
using System;
namespace Project.Model
{
    public class Question : IIdentifiable<long>
    {

        public long Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public DateTime CreationDate { get; set; }

        public Patient Patient { get; set; }
        public Secretary Secretary { get; set; }

        public Question(long id, string questionText, string answerText, Patient patient, Secretary secretary, DateTime creationDate)
        {
            Id = id;
            QuestionText = questionText;
            AnswerText = answerText;
            Patient = patient;
            Secretary = secretary;
            CreationDate = creationDate;
        }

        public Question(string questionText, string answerText, Patient patient, Secretary secretary, DateTime creationDate)
        {
            QuestionText = questionText;
            AnswerText = answerText;
            Patient = patient;
            Secretary = secretary;
            CreationDate = creationDate;
        }

        public Question()
        {
        }


        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}