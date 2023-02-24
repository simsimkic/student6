// File:    RoomController.cs
// Created: Friday, May 1, 2020 2:25:17 AM
// Purpose: Definition of Class RoomController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class RoomController : IController<RoomDTO, long>
    {
        private IService<Room, long> _service;
        private IConverter<Room, RoomDTO> _roomConverter;

        public RoomController(
            IService<Room, long> service,
            IConverter<Room, RoomDTO> roomConverter
            )
        {
            _service = service;
            _roomConverter = roomConverter;
        }


        public IEnumerable<RoomDTO> GetAll()
            => _roomConverter.ConvertListEntityToListDTO((List<Room>)_service.GetAll());

        public RoomDTO GetById(long id)
            => _roomConverter.ConvertEntityToDTO(_service.GetById(id));

        public RoomDTO Remove(RoomDTO entity)
            => _roomConverter.ConvertEntityToDTO(_service.Remove(_roomConverter.ConvertDTOToEntity(entity)));

        public RoomDTO Save(RoomDTO entity)
            => _roomConverter.ConvertEntityToDTO(_service.Save(_roomConverter.ConvertDTOToEntity(entity)));

        public RoomDTO Update(RoomDTO entity)
            => _roomConverter.ConvertEntityToDTO(_service.Update(_roomConverter.ConvertDTOToEntity(entity)));
    }
}