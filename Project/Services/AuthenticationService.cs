using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Services.Abstract;

namespace Project.Services
{
    public class AuthenticationService
    {
        // TODO: Make IEmployeeService
        private readonly EmployeeService _employeeService;
        private readonly IPatientService _patientService;

        public AuthenticationService(
            EmployeeService employeeService,
            PatientService patientService
        )
        {
            _employeeService = employeeService;
            _patientService = patientService;
        }

        public User Login(string email, string password)
        {
            var item = _patientService.GetByEmail(email);
            if(item == null)
               return _employeeService.GetByEmail(email);
            return item;
        }
    }
}
