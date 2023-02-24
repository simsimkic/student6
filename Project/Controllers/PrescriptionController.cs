using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Project.Controllers
{
    class PrescriptionController : IController<PrescriptionDTO, long>
    {
        private IService<Prescription, long> _service;
        private IConverter<Prescription, PrescriptionDTO> _prescriptionConverter;

        public PrescriptionController(IService<Prescription, long> service, IConverter<Prescription, PrescriptionDTO> prescriptionConverter)
        {
            _prescriptionConverter = prescriptionConverter;
            _service = service;
        }

        public PrescriptionDTO GetById(long id)
           => _prescriptionConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<PrescriptionDTO> GetAll()
           => (List<PrescriptionDTO>) _prescriptionConverter.ConvertListEntityToListDTO((List<Prescription>)_service.GetAll());

        public PrescriptionDTO Remove(PrescriptionDTO entity)
            => _prescriptionConverter.ConvertEntityToDTO(_service.Remove(_prescriptionConverter.ConvertDTOToEntity(entity)));

        public PrescriptionDTO Save(PrescriptionDTO entity)
            => _prescriptionConverter.ConvertEntityToDTO(_service.Save(_prescriptionConverter.ConvertDTOToEntity(entity)));

        public PrescriptionDTO Update(PrescriptionDTO entity)
            => _prescriptionConverter.ConvertEntityToDTO(_service.Update(_prescriptionConverter.ConvertDTOToEntity(entity)));

        // TODO FIlter
        public IEnumerable<PrescriptionDTO> GetAllPrescriptionsByPatientID(long id) 
            => _prescriptionConverter.ConvertListEntityToListDTO((List<Prescription>)_service.GetAll());
    }
}
