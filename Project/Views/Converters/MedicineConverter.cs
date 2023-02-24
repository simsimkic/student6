using System.Collections.Generic;
using System.Linq;
using Project.Model;
using Project.Views.Model;

namespace Project.Views.Converters
{
    public class MedicineConverter : IConverter<Medicine, MedicineDTO>
    {
        public Medicine ConvertDTOToEntity(MedicineDTO dto)
            => new Medicine(
                dto.Id,
                dto.Purpose,
                dto.Administration,
                dto.Approved,
                dto.Quantity,
                dto.Type,
                dto.Description,
                dto.Name);

        public MedicineDTO ConvertEntityToDTO(Medicine entity)
                => new MedicineDTO(
                    entity.Id,
                    entity.Name,
                    entity.Type,
                    entity.Description,
                    entity.Quantity,
                    entity.Purpose,
                    entity.Administration,
                    entity.Approved
                    );

        public List<Medicine> ConvertListDTOToListEntity(IEnumerable<MedicineDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<MedicineDTO> ConvertListEntityToListDTO(List<Medicine> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}