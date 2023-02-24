using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Views.Model;
using Project.Model;

namespace Project.Views.Converters
{
    public class PatientConverter : IConverter<Project.Model.Patient, PatientDTO>
    {
        private AddressConverter _addressConverter;

        public PatientConverter(AddressConverter addressConverter)
        {
            _addressConverter = addressConverter;
        }

        public Project.Model.Patient ConvertDTOToEntity(PatientDTO dto)
            => new Project.Model.Patient(
                dto.Id,
                _addressConverter.ConvertDTOToEntity(dto.Address),
                dto.FirstName,
                dto.LastName,
                dto.Jmbg,
                dto.TelephoneNumber,
                dto.Gender,
                dto.DateOfBirth,
                dto.InsurenceNumber,
                dto.Profession,
                dto.BloodType,
                dto.Height,
                dto.Weight,
                dto.Email,
                dto.Password
            );

        public PatientDTO ConvertEntityToDTO(Project.Model.Patient entity)
        {
            try
            {
                return new PatientDTO(
                entity.Id,
                _addressConverter.ConvertEntityToDTO(entity.Address),
                entity.FirstName,
                entity.LastName,
                entity.Jmbg,
                entity.TelephoneNumber,
                entity.Gender,
                entity.DateOfBirth,
                entity.InsurenceNumber,
                entity.Profession,
                entity.BloodType,
                entity.Height,
                entity.Weight,
                entity.Email,
                entity.Password);

            }
            catch (System.Exception)
            {
                return new PatientDTO();

            }
        }

        public List<Project.Model.Patient> ConvertListDTOToListEntity(IEnumerable<PatientDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<PatientDTO> ConvertListEntityToListDTO(List<Project.Model.Patient> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
