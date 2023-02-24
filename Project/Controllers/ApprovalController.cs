using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class ApprovalController : IController<ApprovalDTO, long>
    {
     
        private IService<Approval, long> _service;
        private IConverter<Approval, ApprovalDTO> _orderConverter;

        public ApprovalController(IService<Approval, long> service,
            IConverter<Approval, ApprovalDTO> orderConverter
            )
        {
            _service = service;
            _orderConverter = orderConverter;
        }

        public IEnumerable<ApprovalDTO> GetAll()
            => _orderConverter.ConvertListEntityToListDTO((List<Approval>)_service.GetAll());

        public ApprovalDTO GetById(long id)
            => _orderConverter.ConvertEntityToDTO(_service.GetById(id));

        public ApprovalDTO Remove(ApprovalDTO entity)
            => _orderConverter.ConvertEntityToDTO(_service.Remove(_orderConverter.ConvertDTOToEntity(entity)));

        public ApprovalDTO Save(ApprovalDTO entity)
            => _orderConverter.ConvertEntityToDTO(_service.Save(_orderConverter.ConvertDTOToEntity(entity)));

        public ApprovalDTO Update(ApprovalDTO entity)
            => _orderConverter.ConvertEntityToDTO(_service.Update(_orderConverter.ConvertDTOToEntity(entity)));
    }
}