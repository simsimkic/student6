// File:    EquipmentController.cs
// Created: Thursday, May 7, 2020 11:42:51 PM
// Purpose: Definition of Class EquipmentController

using System;
using Project.Model;
using Project.Controllers;
using Project.Services;
using System.Collections.Generic;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
   public class EquipmentController: IController<EquipmentDTO,long>
   {
      private IService<Equipment, long> _equipmentService;
      private IConverter<Equipment, EquipmentDTO> _equipmentConverter;

        public EquipmentController(
              IService<Equipment, long> service,
              IConverter<Equipment, EquipmentDTO> equipmentConverter
              )
        {
            _equipmentService = service;
            _equipmentConverter = equipmentConverter;
        }

        public IEnumerable<EquipmentDTO> GetAll()
            => _equipmentConverter.ConvertListEntityToListDTO((List<Equipment>)_equipmentService.GetAll());

        public EquipmentDTO GetById(long id)
            => _equipmentConverter.ConvertEntityToDTO(_equipmentService.GetById(id));


        public EquipmentDTO Save(EquipmentDTO entity)
           => _equipmentConverter.ConvertEntityToDTO(_equipmentService.Save(_equipmentConverter.ConvertDTOToEntity(entity)));

        public EquipmentDTO Remove(EquipmentDTO entity)
            => _equipmentConverter.ConvertEntityToDTO(_equipmentService.Remove(_equipmentConverter.ConvertDTOToEntity(entity)));

        public EquipmentDTO Update(EquipmentDTO entity)
            => _equipmentConverter.ConvertEntityToDTO(_equipmentService.Update(_equipmentConverter.ConvertDTOToEntity(entity)));
    }
}