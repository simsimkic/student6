using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Views.Model;
using Project.Model;

namespace Project.Views.Converters
{
    public class AnamnesisConvertor : IConverter<Anamnesis, AnamnesisDTO>
    {
        public Anamnesis ConvertDTOToEntity(AnamnesisDTO dto)
            => new Project.Model.Anamnesis(dto.Id, dto.MedicalAppointmentDTO.Id, dto.Name, dto.Type, dto.Description);

        public AnamnesisDTO ConvertEntityToDTO(Anamnesis entity)
            => new AnamnesisDTO(entity.Id, entity.Name, entity.Type, entity.Description, null);

        public List<Anamnesis> ConvertListDTOToListEntity(IEnumerable<AnamnesisDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList(); 

        public IEnumerable<AnamnesisDTO> ConvertListEntityToListDTO(List<Anamnesis> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
