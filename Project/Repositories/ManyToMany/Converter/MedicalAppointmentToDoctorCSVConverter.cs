using Project.Model;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.ManyToMany.Converter
{
    class MedicalAppointmentToDoctorCSVConverter : ICSVConverter<MedicalAppointmentToDoctor>
    {
        private readonly string _delimiter;
        public MedicalAppointmentToDoctorCSVConverter(
            string delimiter
            )
        {
            _delimiter = delimiter;
        }

        public MedicalAppointmentToDoctor ConvertCSVFormatToEntity(string entityCSVFormat)
        { 
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new MedicalAppointmentToDoctor(
                long.Parse(tokens[1]),
                long.Parse(tokens[2])
            );
        }

        public string ConvertEntityToCSVFormat(MedicalAppointmentToDoctor entity)
           => string.Join(_delimiter,
               entity.Id,
               entity.MedicalAppointmentId,
               entity.DoctorId
               );

    }
}
