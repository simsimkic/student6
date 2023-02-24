using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class GuestDTO : UserDTO
    {
        public string InsurenceNumber { get; set; }
        public string Profession { get; set; }
        public string BloodType { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }


        public GuestDTO() { }

        public GuestDTO(long id, AddressDTO address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth,string insurenceNumber, string profession, string bloodType, float height, float weight) 
         : base(id, address, firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth)
        {
            InsurenceNumber = insurenceNumber;
            Profession = profession;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
        }
        public GuestDTO(AddressDTO address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth,string insurenceNumber, string profession, string bloodType, float height, float weight) 
         : base(address, firstName,  lastName,  jmbg,  telephoneNumber,  gender,  dateOfBirth)
        {
            InsurenceNumber = insurenceNumber;
            Profession = profession;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
        }
    }
}
