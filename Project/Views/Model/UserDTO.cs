using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class UserDTO:INotifyPropertyChanged
    {
        private long id;
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string jmbg;
        public string Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }

        public string TelephoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public AddressDTO Address { get; set; }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public UserDTO() { }

        public UserDTO(long id, AddressDTO address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
        {
            Id = id;
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
        public UserDTO(AddressDTO address,string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth)
        {
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

    }
}
