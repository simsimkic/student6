using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class ReportConverter : IConverter<Report, ReportDTO>
    {
        public Report ConvertDTOToEntity(ReportDTO dto)
        => new Report(dto.Id, dto.Path, dto.Date, dto.Type);

        public ReportDTO ConvertEntityToDTO(Report entity)
        => new ReportDTO(entity.Id, entity.Path, entity.Date, entity.Type);

        public List<Report> ConvertListDTOToListEntity(IEnumerable<ReportDTO> dtos)
         => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<ReportDTO> ConvertListEntityToListDTO(List<Report> entities)
         => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
