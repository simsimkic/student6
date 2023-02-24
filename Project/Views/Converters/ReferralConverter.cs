using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Views.Model;

namespace Project.Views.Converters
{
    public class ReferralConverter : IConverter<Referral, ReferralDTO>
    {

        private MedicalAppointmentConverter _medicalAppointmentConverter;

        public ReferralConverter(MedicalAppointmentConverter medicalAppointmentConverter)
        {
            _medicalAppointmentConverter = medicalAppointmentConverter;
        }

        public Referral ConvertDTOToEntity(ReferralDTO dto)
            => new Referral(
                        dto.Id,
                        dto.Date,
                        _medicalAppointmentConverter.ConvertDTOToEntity(dto.MedicalAppointment)
            );

        public ReferralDTO ConvertEntityToDTO(Referral entity)
        {
            try
            {
                return new ReferralDTO(
                        entity.Id,
                        entity.Date,
                        _medicalAppointmentConverter.ConvertEntityToDTO(entity.MedicalAppointment)
                );
            }
            catch (System.Exception)
            {
                return new ReferralDTO();

            }
        }

        public List<Referral> ConvertListDTOToListEntity(IEnumerable<ReferralDTO> dtos)
            => dtos.Select(dto => ConvertDTOToEntity(dto)).ToList();

        public IEnumerable<ReferralDTO> ConvertListEntityToListDTO(List<Referral> entities)
            => entities.Select(entity => ConvertEntityToDTO(entity)).ToList();
    }
}
