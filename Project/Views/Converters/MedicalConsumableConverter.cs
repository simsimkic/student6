using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class MedicalConsumableConverter : IConverter<MedicalConsumables, MedicalConsumableDTO>
    {
        public MedicalConsumableConverter() { }

        public MedicalConsumables ConvertDTOToEntity(MedicalConsumableDTO dto)
        => new MedicalConsumables(
            dto.Id,
            dto.Quantity,
            dto.Type,
            dto.Description,
            dto.Name
            );

        public MedicalConsumableDTO ConvertEntityToDTO(MedicalConsumables entity)
            => new MedicalConsumableDTO(
                entity.Id,
                entity.Name,
                entity.Type,
                entity.Description,
                entity.Quantity
                );

        public List<MedicalConsumables> ConvertListDTOToListEntity(IEnumerable<MedicalConsumableDTO> dtos)
         => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<MedicalConsumableDTO> ConvertListEntityToListDTO(List<MedicalConsumables> entities)
        => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
