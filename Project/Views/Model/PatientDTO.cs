using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class PatientDTO : GuestDTO { 
        public string Email { get; set; }
        public string Password { get; set; }

        public PatientDTO() { }

        public PatientDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth,string insurenceNumber, string profession, string bloodType, float height, float weight, string email, string password)
            : base( id, address, firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth, insurenceNumber,  profession,  bloodType,  height,  weight)
        {
            Email = email;
            Password = password;
        }
        public PatientDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth,string insurenceNumber, string profession, string bloodType, float height, float weight, string email, string password)
            : base(address, firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth, insurenceNumber,  profession,  bloodType,  height,  weight)
        {
            Email = email;
            Password = password;
        }

    }
}
