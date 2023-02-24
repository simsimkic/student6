// File:    PatientCotroller.cs
// Created: Monday, May 4, 2020 8:27:25 PM
// Purpose: Definition of Class PatientCotroller

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Project.Controllers;
using Project.Views.Model;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Services.Abstract;
using Project.Controllers.Abstract;

namespace Project.Controllers
{
    public class PatientController : IPatientController
    {
        private IPatientService _service;
        private IConverter<Patient, PatientDTO> _converter;
        private IConverter<Guest, GuestDTO> _guestConverter;


        public PatientController(IPatientService service, IConverter<Patient, PatientDTO> converter, IConverter<Guest, GuestDTO> guestConverter)
        {
            _service = service;
            _converter = converter;
            _guestConverter = guestConverter;

        }
        public PatientDTO GetById(long id) 
            => _converter.ConvertEntityToDTO(_service.GetById(id));

        public PatientDTO GetByEmail(string email) 
            => _converter.ConvertEntityToDTO(_service.GetByEmail(email));
        
        public IEnumerable<PatientDTO> GetAll() 
            => _converter.ConvertListEntityToListDTO((List<Patient>)_service.GetAll());

        public PatientDTO Remove(PatientDTO entity)
            => _converter.ConvertEntityToDTO(_service.Remove(_converter.ConvertDTOToEntity(entity)));

        public PatientDTO Save(PatientDTO entity)
            => _converter.ConvertEntityToDTO(_service.Save(_converter.ConvertDTOToEntity(entity)));

        public PatientDTO Update(PatientDTO entity)
            => _converter.ConvertEntityToDTO(_service.Update(_converter.ConvertDTOToEntity(entity)));

        public PatientDTO ClaimGuestAccount(GuestDTO guest, string email, string password)
           => _converter.ConvertEntityToDTO(_service.ClaimGuestAccount(_guestConverter.ConvertDTOToEntity(guest), email, password));
    }
}