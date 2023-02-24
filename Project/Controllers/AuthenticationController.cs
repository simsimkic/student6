using System;
using Project.Services;
using Project.Model;
using System.Collections.Generic;
using Project.Views.Model;
using System.Windows;

namespace Project.Controllers
{
    public class AuthenticationController
    {
        App app;
        public AuthenticationController()
        {
            app = Application.Current as App;


        }
        public System.Tuple<UserDTO, string> Login(string email, string password)
        {
            // DirectorDTO director = app.director;
            // if (director.Email == email && director.Password == password) return Tuple.Create(director as UserDTO, "Director");
            // PatientDTO patient = app.PatientController.GetByEmail(email);
            // if(patient.Email == email && patient.Password == password) return Tuple.Create(patient as UserDTO, "Patient");
            // SecretaryDTO secretary = app.SecretaryController.GetByEmail(email);
            // if(secretary.Email == email && secretary.Password == password) return Tuple.Create(secretary as UserDTO, "Secretary");
            // DoctorDTO doctor = app.DoctorController.GetByEmail(email);
            // if(doctor.Email == email && doctor.Password == password) return Tuple.Create(doctor as UserDTO, "Doctor");
            // return null; 
            return Tuple.Create(new SecretaryDTO() as UserDTO, "Secretary");
        }
    }
}