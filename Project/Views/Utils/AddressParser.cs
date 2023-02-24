using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views
{
    public static class AddressParser
    {
        public static AddressDTO ConvertStringToAddressDTO(string addressString)
        {
            var list = addressString.Split();
            //return new AddressDTO(list[0],list[1],list[2],list[3],list[4]);
            return new AddressDTO("number","street","city","country","postCode");

        }

    }
}
