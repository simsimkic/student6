using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    public class PropositionConverter : IConverter<Proposition, PropositionDTO>
    {
        private MedicineConverter _medicineConverter;
        private ApprovalConverter _approvalConverter;
        private DoctorConverter _doctorConverter;
        private PropositionConverter _propositionConverter;

        public PropositionConverter(MedicineConverter medicineConverter, ApprovalConverter approvalConverter, DoctorConverter doctorConverter)
        {
            _medicineConverter = medicineConverter;
            _approvalConverter = approvalConverter;
            _doctorConverter = doctorConverter;
        }

        public PropositionConverter(MedicineConverter medicineConverter)
        {
            _medicineConverter = medicineConverter;
        }

        public Proposition ConvertDTOToEntity(PropositionDTO dto)
            => new Proposition(
                dto.State,
                _approvalConverter.ConvertListDTOToListEntity(dto.Approvals),
                _medicineConverter.ConvertDTOToEntity(dto.Medicine)
            );

        public PropositionDTO ConvertEntityToDTO(Proposition entity)
                => new PropositionDTO(
                entity.Id,
                entity.State,
                _medicineConverter.ConvertEntityToDTO(entity.Medicine)
                );

        public List<Proposition> ConvertListDTOToListEntity(IEnumerable<PropositionDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<PropositionDTO> ConvertListEntityToListDTO(List<Proposition> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();

        
        public Approval ConvertDTOToEntity(ApprovalDTO dto)
            => new Approval(
                dto.Id,
                dto.Description,
                dto.IsApproved,
                _doctorConverter.ConvertDTOToEntity(dto.Doctor),
                ConvertDTOToEntity(dto.Proposition)

            );

        public ApprovalDTO ConvertEntityToDTO(Approval entity)
            => new ApprovalDTO(
                entity.Id,
                entity.Description,
                entity.IsApproved,
                _doctorConverter.ConvertEntityToDTO(entity.Doctor),
                ConvertEntityToDTO(entity.Proposition)
                );

        public List<Approval> ConvertListDTOToListEntity(IEnumerable<ApprovalDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<ApprovalDTO> ConvertListEntityToListDTO(List<Approval> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();

    }
}
