using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class AddressDTO
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public AddressDTO()
        {

        }

        public AddressDTO(long id, string number, string street, string city, string country, string postCode)
        {
            Id = id;
            Number = number;
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }
        public AddressDTO(string number, string street, string city, string country, string postCode)
        {
            Number = number;
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }


    }
}
