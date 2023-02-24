// File:    OrderController.cs
// Created: Friday, May 1, 2020 2:21:16 AM
// Purpose: Definition of Class OrderController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class OrderController : IController<OrderDTO, long>
    {
     
        private IService<Order, long> _service;
        private IConverter<Order, OrderDTO> _orderConverter;

        public OrderController(IService<Order, long> service,
            IConverter<Order, OrderDTO> orderConverter
            )
        {
            _service = service;
            _orderConverter = orderConverter;
        }

        public IEnumerable<OrderDTO> GetAll()
            => _orderConverter.ConvertListEntityToListDTO((List<Order>)_service.GetAll());

        public OrderDTO GetById(long id)
            => _orderConverter.ConvertEntityToDTO(_service.GetById(id));

        public OrderDTO Remove(OrderDTO entity)
            => _orderConverter.ConvertEntityToDTO(_service.Remove(_orderConverter.ConvertDTOToEntity(entity)));

        public OrderDTO Save(OrderDTO entity)
            => _orderConverter.ConvertEntityToDTO(_service.Save(_orderConverter.ConvertDTOToEntity(entity)));

        public OrderDTO Update(OrderDTO entity)
            => _orderConverter.ConvertEntityToDTO(_service.Update(_orderConverter.ConvertDTOToEntity(entity)));
    }
}