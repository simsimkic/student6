using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.ManyToMany.Repositories.Abstract;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.ManyToMany.Repositories
{
    class MedicalAppointmentToDoctorRepository : 
        CSVRepository<MedicalAppointmentToDoctor, long>,
        IMedicalAppointmentToDoctorRepository,
        IEagerCSVRepository<MedicalAppointmentToDoctor, long>
    {
        private const string ENTITY_NAME = "MedicalAppointmentToDoctor";

        public MedicalAppointmentToDoctorRepository(
            ICSVStream<MedicalAppointmentToDoctor> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }


        public IEnumerable<MedicalAppointmentToDoctor> GetAllEager() => GetAll();
        public MedicalAppointmentToDoctor GetEager(long id) => GetById(id);
        public List<MedicalAppointmentToDoctor> GetAllByDoctorId(long id)
            => GetAll().Where(item => item.DoctorId == id).ToList();
        public List<MedicalAppointmentToDoctor> GetAllByMedicalAppointmentId(long id) 
            => GetAll().Where(item => item.MedicalAppointmentId == id).ToList();
        public new MedicalAppointmentToDoctor Save(MedicalAppointmentToDoctor entity)
        {
                return base.Save(entity);
        }

        IEnumerable<MedicalAppointmentToDoctor> IEagerCSVRepository<MedicalAppointmentToDoctor, long>.GetAllEager()
        {
            throw new NotImplementedException();
        }

        MedicalAppointmentToDoctor IEagerCSVRepository<MedicalAppointmentToDoctor, long>.GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
