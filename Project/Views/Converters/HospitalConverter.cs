using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class HospitalConverter : IConverter<Hospital, HospitalDTO>
    {
        public HospitalConverter()
        {

        }

        public Hospital ConvertDTOToEntity(HospitalDTO dto)
           => new Project.Model.Hospital(dto.Name, new Address(), new List<Medicine>(), new List<Employee>(), new List<Room>(), new List<MedicalConsumables>());

        public HospitalDTO ConvertEntityToDTO(Hospital entity)
           => new HospitalDTO(entity.Name, new AddressDTO(), new List<MedicineDTO>(), new List<EmployeeDTO>(), new List<RoomDTO>(), new List<MedicalConsumableDTO>());

        public List<Hospital> ConvertListDTOToListEntity(IEnumerable<HospitalDTO> dtos)
             => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<HospitalDTO> ConvertListEntityToListDTO(List<Hospital> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
