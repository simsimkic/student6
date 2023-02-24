using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class EmployeeDTO : UserDTO
    {
        public int Salary { get; set; }
        public TimeInterval AnnualLeave { get; set; }
        public TimeInterval WorkingHours { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hospital { get; set; }
        public EmployeeDTO() { }
        
        public EmployeeDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password,string hospital) :
              base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
            Hospital = hospital;
        }
        public EmployeeDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password,string hospital) :
              base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
            Hospital = hospital;
        }

        public EmployeeDTO(long id, AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(id, address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
        }
        public EmployeeDTO(AddressDTO address, string firstName, string lastName, string jmbg, string telephoneNumber, string gender, DateTime dateOfBirth, int salary, TimeInterval annualLeave, TimeInterval workingHours, string email, string password) :
              base(address, firstName, lastName, jmbg, telephoneNumber, gender, dateOfBirth)
        {
            Salary = salary;
            AnnualLeave = annualLeave;
            WorkingHours = workingHours;
            Email = email;
            Password = password;
        }

    }
}
