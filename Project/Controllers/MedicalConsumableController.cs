// File:    MedicalConsumableController.cs
// Created: Friday, May 8, 2020 12:10:05 AM
// Purpose: Definition of Class MedicalConsumableController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class MedicalConsumableController : IController<MedicalConsumableDTO, long>
    {
        private IService<MedicalConsumables,long> _service;
        private IConverter<MedicalConsumables, MedicalConsumableDTO> _medicalConsumableConverter;

        public MedicalConsumableController(
            IService<MedicalConsumables, long> service,
            IConverter<MedicalConsumables, MedicalConsumableDTO> medicalConsumableConverter
            )
        {
            _service = service;
            _medicalConsumableConverter = medicalConsumableConverter;
        }

        public IEnumerable<MedicalConsumableDTO> GetAll()
            => _medicalConsumableConverter.ConvertListEntityToListDTO((List<MedicalConsumables>)_service.GetAll());

        public MedicalConsumableDTO GetById(long id)
            => _medicalConsumableConverter.ConvertEntityToDTO(_service.GetById(id));


        public MedicalConsumableDTO Remove(MedicalConsumableDTO entity)
            => _medicalConsumableConverter.ConvertEntityToDTO(_service.Remove(_medicalConsumableConverter.ConvertDTOToEntity(entity)));

        public MedicalConsumableDTO Save(MedicalConsumableDTO entity)
            => _medicalConsumableConverter.ConvertEntityToDTO(_service.Save(_medicalConsumableConverter.ConvertDTOToEntity(entity)));

        public MedicalConsumableDTO Update(MedicalConsumableDTO entity)
            => _medicalConsumableConverter.ConvertEntityToDTO(_service.Update(_medicalConsumableConverter.ConvertDTOToEntity(entity)));
    }
}