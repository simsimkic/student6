using Project.Model;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.Abstract;
using Project.Repositories.ManyToMany.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Services.Abstract;

namespace Project.Services
{
    class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private int _appointmentLength;
        IDoctorService _doctorService;

        public MedicalAppointmentService(
            IMedicalAppointmentRepository medicalAppointmentRepository,
            IDoctorService doctorService
        )
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _doctorService = doctorService;
        }
        public IEnumerable<MedicalAppointment> GetAll()
            => _medicalAppointmentRepository.GetAll();

        public IEnumerable<MedicalAppointment> GetAllByPatientId(long id)
            => _medicalAppointmentRepository.GetAllByPatientId(id);

        public MedicalAppointment GetById(long id)
            => _medicalAppointmentRepository.GetById(id);

        public MedicalAppointment Remove(MedicalAppointment entity)
            => _medicalAppointmentRepository.Remove(entity);

        public MedicalAppointment Save(MedicalAppointment entity)
            => _medicalAppointmentRepository.Save(entity);

        public MedicalAppointment Update(MedicalAppointment entity)
            => _medicalAppointmentRepository.Update(entity);

        public IEnumerable<MedicalAppointment> GetAllByDoctorID(long id)
            => _medicalAppointmentRepository.GetAllByDoctorId(id);

        public bool IsAvailableAtTimeInterval(MedicalAppointment medicalAppointment, TimeInterval timeInterval)
            => medicalAppointment.Beginning >= timeInterval.Start && medicalAppointment.End <= timeInterval.End;

        private IEnumerable<MedicalAppointment> GenerateAppointments(TimeInterval interval)
        {
            List<MedicalAppointment> list = new List<MedicalAppointment>();
            for (DateTime iter = interval.Start; iter <= interval.End; iter.AddMinutes(_appointmentLength))
                list.Add(new MedicalAppointment(iter, iter.AddMinutes(_appointmentLength), null, MedicalAppointmentType.examination, null));
            return list;
        }

        public IEnumerable<MedicalAppointment> GetAvailableAppoitments(Doctor doctor, Room room, TimeInterval timeInterval)
        {
            var dif = (timeInterval.End - timeInterval.Start).TotalDays;

            List<MedicalAppointment> listFreeApp = GenerateAppointments(timeInterval).ToList();
            if(doctor == null) return listFreeApp;
            else
            {
                // Doctor working hours
                for (int i = 0; i < dif; i++)
                {
                    // var day = doctor.WorkingHours.Start.AddDays(i);
                    var startHours = doctor.WorkingHours.Start.Hour;
                    var startMinutes = doctor.WorkingHours.Start.Minute;
                    var endHours = doctor.WorkingHours.Start.Hour;
                    var endMinutes = doctor.WorkingHours.Start.Minute;
                    var currDay = timeInterval.Start.AddDays(i);
                    DateTime startWH = new DateTime(currDay.Year, currDay.Month, currDay.Day, startHours, startMinutes, 0);
                    DateTime endWH = new DateTime(currDay.Year, currDay.Month, currDay.Day, endHours, endMinutes, 0);
                    listFreeApp.AddRange(GenerateAppointments(new TimeInterval(startWH, endWH)));
                }


                // Filter free by doctorsApp
                doctor.Appointments.ForEach(app => listFreeApp.Remove(listFreeApp.Where(item => item.Beginning == app.Beginning && item.End == app.End).SingleOrDefault()));
            }
            if (room != null) listFreeApp = listFreeApp.Where(item => item.Room == room).ToList();


            return listFreeApp;

        }
        public IEnumerable<MedicalAppointment> SuggestAvailableAppoitments(string priority, Doctor doctor, TimeInterval timeInterval)
        {
            var list = (List<MedicalAppointment>)_medicalAppointmentRepository.GetAllByDoctorId(doctor.Id);
            var doctorList = new List<Doctor>();

            doctor = _doctorService.GetByEmail(doctor.Email);
            doctorList.Add(doctor);

            list = TrimListToTimeInterval(list, timeInterval);

            return GenerateAndPopulateForTimeInterval(list, new TimeSpan(0, 30, 0), new TimeSpan(16, 0, 0),timeInterval,doctorList);
        }

        public List<MedicalAppointment> TrimListToTimeInterval(List<MedicalAppointment> list, TimeInterval timeInterval)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].Beginning < timeInterval.Start) || (list[i].Beginning > timeInterval.End)){
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }

        public List<MedicalAppointment> GenerateAndPopulateForTimeInterval(List<MedicalAppointment> list , TimeSpan termDuration, TimeSpan offDuration, TimeInterval timeInterval, List<Doctor> doctorList)
        {
            var returnList = new List<MedicalAppointment>();
            DateTime date = timeInterval.Start.Add(new TimeSpan(8, 0, 0));
            DateTime termStart, termEnd;

            while (date <= timeInterval.End)
            {
                for (int i = 0; i < 16; i++)
                {
                    termStart = date;
                    termEnd = date.Add(termDuration);
                    date = date.Add(termDuration);
                    bool valid = true;
                    foreach (MedicalAppointment item in list){
                        if ((item.Beginning >= termStart) && (item.Beginning <= termEnd)){
                            valid = false;
                        }
                    }
                    if (valid){
                        returnList.Add(new MedicalAppointment(termStart, termEnd, new Room(1), MedicalAppointmentType.examination, new Guest(), doctorList));
                    }
                }

                date = date.Add(offDuration);
            }

            return returnList;
        }

        private IEnumerable<MedicalAppointment> GetAvailableAppoitmentsByDoctor(Doctor doctor)
        {
            return new List<MedicalAppointment>();
        }

        private IEnumerable<MedicalAppointment> GetAvailableAppoitmentsByTimeInterval(TimeInterval timeinterval)
        {
            return new List<MedicalAppointment>();
        }

    }

}

