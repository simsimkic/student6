using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Views.Model
{
    public class DoctorDTO : EmployeeDTO
    {
        public string MedicalRole { get; set; }
        public float AverageReviewScore { get; set; }
        public List<ApprovalDTO> Approval { get; set; }
        public List<MedicalAppointmentDTO> Appointments { get; set; }

        public DoctorDTO() { }
        public DoctorDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password,string hospital,string medicalRole):
            base( id,  address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password, hospital)
        {
            MedicalRole = medicalRole;
            Appointments = new List<MedicalAppointmentDTO>();
        }
        public DoctorDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password,string hospital, string medicalRole):
            base(address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password,hospital)
        {
            MedicalRole = medicalRole;
            Appointments = new List<MedicalAppointmentDTO>();
        }
        public DoctorDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password,string medicalRole):
            base( id,  address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password)
        {
            MedicalRole = medicalRole;
            Appointments = new List<MedicalAppointmentDTO>();
        }
        public DoctorDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password,string medicalRole):
            base(address,  firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth,  salary,  annualLeave,  workingHours,  email,  password)
        {
            MedicalRole = medicalRole;
            Appointments = new List<MedicalAppointmentDTO>(); 
        }

    }
}

