using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    class PrescriptionConverter : IConverter<Prescription, PrescriptionDTO>
    {
        private PatientConverter _patientConverter;
        private MedicineConverter _medicineConverter;

        public PrescriptionConverter(PatientConverter patientConverter, MedicineConverter medicineConverter)
        {
            _patientConverter = patientConverter;
            _medicineConverter = medicineConverter;

        }
        public Prescription ConvertDTOToEntity(PrescriptionDTO dto)
            => new Prescription(
                dto.Id,
                dto.Dosage,
                dto.Usage,
                dto.Period,
                _medicineConverter.ConvertDTOToEntity(dto.Medicine),
                dto.Date,
                _patientConverter.ConvertDTOToEntity(dto.Patient)
            );

        public PrescriptionDTO ConvertEntityToDTO(Prescription entity)
                => new PrescriptionDTO(
                entity.Id,
                entity.Dosage,
                entity.Usage,
                entity.Period,
                _medicineConverter.ConvertEntityToDTO(entity.Medicine),
                entity.Date,
                _patientConverter.ConvertEntityToDTO(entity.Patient)
            );

        public List<Prescription> ConvertListDTOToListEntity(IEnumerable<PrescriptionDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<PrescriptionDTO> ConvertListEntityToListDTO(List<Prescription> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
