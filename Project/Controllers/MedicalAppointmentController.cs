// File:    MedicalAppointmentController.cs
// Created: Thursday, May 7, 2020 7:52:18 PM
// Purpose: Definition of Class MedicalAppointmentController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class MedicalAppointmentController : IController<MedicalAppointmentDTO, long>
    {
        private IMedicalAppointmentService _service;
        private IConverter<MedicalAppointment, MedicalAppointmentDTO> _medicalAppointmentConverter;
        private IConverter<Doctor, DoctorDTO> _doctorConverter;
        private IConverter<Room, RoomDTO> _roomConverter;
        public MedicalAppointmentController(
            IMedicalAppointmentService service,
            IConverter<MedicalAppointment, MedicalAppointmentDTO> medicalAppointmentConverter,
            IConverter<Doctor, DoctorDTO> doctorConverter,
            IConverter<Room, RoomDTO> roomConverter
            )
        {
            _service = service;
            _medicalAppointmentConverter = medicalAppointmentConverter;
            _doctorConverter = doctorConverter;
            _roomConverter = roomConverter;
        }
        public IEnumerable<MedicalAppointmentDTO> GetAll()
            => _medicalAppointmentConverter.ConvertListEntityToListDTO((List<MedicalAppointment>)_service.GetAll());
        public IEnumerable<MedicalAppointmentDTO> GetAvailableAppoitments(DoctorDTO doctor, RoomDTO room, TimeInterval timeInterval)
            => _medicalAppointmentConverter.ConvertListEntityToListDTO((List<MedicalAppointment>)_service.GetAvailableAppoitments(
                _doctorConverter.ConvertDTOToEntity(doctor), 
                _roomConverter.ConvertDTOToEntity(room), 
                timeInterval));

        public IEnumerable<MedicalAppointmentDTO> GetAllByPatientID(long id)
            => _medicalAppointmentConverter.ConvertListEntityToListDTO((List<MedicalAppointment>)_service.GetAllByPatientId(id));

        public IEnumerable<MedicalAppointmentDTO> GetAllByDoctorID(long id)
            => _medicalAppointmentConverter.ConvertListEntityToListDTO((List<MedicalAppointment>)_service.GetAllByDoctorID(id));

            
        public IEnumerable<MedicalAppointmentDTO> SuggestAvailableAppoitments(string priority, DoctorDTO doctor, TimeInterval timeInterval)
            => _medicalAppointmentConverter.ConvertListEntityToListDTO((List<MedicalAppointment>)_service.SuggestAvailableAppoitments(priority, _doctorConverter.ConvertDTOToEntity(doctor), timeInterval));

        public MedicalAppointmentDTO GetById(long id)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.GetById(id));

        public MedicalAppointmentDTO Remove(MedicalAppointmentDTO entity)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.Remove(_medicalAppointmentConverter.ConvertDTOToEntity(entity)));

        public MedicalAppointmentDTO Save(MedicalAppointmentDTO entity)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.Save(_medicalAppointmentConverter.ConvertDTOToEntity(entity)));

        public MedicalAppointmentDTO Update(MedicalAppointmentDTO entity)
            => _medicalAppointmentConverter.ConvertEntityToDTO(_service.Update(_medicalAppointmentConverter.ConvertDTOToEntity(entity)));

    }
}