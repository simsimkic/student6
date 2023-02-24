// File:    QuestionController.cs
// Created: Monday, May 4, 2020 8:43:25 PM
// Purpose: Definition of Class QuestionController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class QuestionController : IController<QuestionDTO, long>
    {
        private IService<Question, long> _service;
        private IConverter<Patient, PatientDTO> _patientConverter;
        private IConverter<Question, QuestionDTO> _questionConverter;


        public QuestionController(
            IService<Question, long> service,
            IConverter<Question, QuestionDTO> questionConverter,
            IConverter<Patient, PatientDTO> patientConverter
            )
        {
            _service = service;
            _patientConverter = patientConverter;
            _questionConverter = questionConverter;
        }

        public QuestionDTO GetById(long id) 
            => _questionConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<QuestionDTO> GetAll() 
            => _questionConverter.ConvertListEntityToListDTO((List<Question>)_service.GetAll());

        public QuestionDTO Remove(QuestionDTO entity) 
            => _questionConverter.ConvertEntityToDTO(_service.Remove(_questionConverter.ConvertDTOToEntity(entity)));

        public QuestionDTO Save(QuestionDTO entity) 
            => _questionConverter.ConvertEntityToDTO(_service.Save(_questionConverter.ConvertDTOToEntity(entity)));

        public QuestionDTO Update(QuestionDTO entity) 
            => _questionConverter.ConvertEntityToDTO(_service.Update(_questionConverter.ConvertDTOToEntity(entity)));
    }
}