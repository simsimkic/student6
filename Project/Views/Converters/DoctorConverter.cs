using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class DoctorConverter : IConverter<Project.Model.Doctor, DoctorDTO>
    {
        private AddressConverter _addressConverter;

        public DoctorConverter( AddressConverter addressConverter)
        {
            _addressConverter = addressConverter;
        }

        public Project.Model.Doctor ConvertDTOToEntity(DoctorDTO dto)
            => new Project.Model.Doctor(
                dto.Id, 
                _addressConverter.ConvertDTOToEntity(dto.Address), 
                dto.FirstName, 
                dto.LastName, 
                dto.Jmbg, 
                dto.TelephoneNumber, 
                dto.Gender, 
                dto.DateOfBirth, 
                dto.Salary, 
                dto.AnnualLeave, 
                dto.WorkingHours, 
                dto.Email, 
                dto.Password,  
                dto.MedicalRole);


        public DoctorDTO ConvertEntityToDTO(Project.Model.Doctor entity){
            try
            {
            return new DoctorDTO(
                entity.Id, 
                _addressConverter.ConvertEntityToDTO(entity.Address),
                entity.FirstName, 
                entity.LastName, 
                entity.Jmbg, 
                entity.TelephoneNumber,
                entity.Gender, 
                entity.DateOfBirth, 
                entity.Salary, 
                entity.AnnualLeave, 
                entity.WorkingHours, 
                entity.Email, 
                entity.Password, 
                entity.MedicalRole);
                
            }
            catch (System.Exception)
            {
                return new DoctorDTO();
            }

        }

        public List<Project.Model.Doctor> ConvertListDTOToListEntity(IEnumerable<DoctorDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<DoctorDTO> ConvertListEntityToListDTO(List<Project.Model.Doctor> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
