using Project.Controllers;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for CreatePatientModal.xaml
    /// </summary>
    public partial class CreatePatientModal : Window
    {
        private readonly IController<PatientDTO, long> _patientController;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Profession { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InsurenceNumber { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public string Weight { get; set; }
        public new string Height { get; set; }
        public CreatePatientModal()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _patientController = app.PatientController;
        }
        private bool isValidInputLength(string input) => (input.Length == 0) ? false : true;

        private void CreatePatient_Click(object sender, RoutedEventArgs e)
        {
            FirstName = Profile_FirstName.Text;
            LastName = Profile_LastName.Text;
            JMBG = Profile_JMBG.Text;
            TelephoneNumber = Profile_TelephoneNumber.Text;
            Gender = Profile_Gender.Text;
            DateOfBirth = Profile_DateOfBirth.SelectedDate.GetValueOrDefault();
            InsurenceNumber = Profile_InsurenceNumber.Text;
            BloodType = Profile_BloodType.SelectedItem.ToString();
            //Height = Profile_Height.Text;
            //Weight = Profile_Weight.Text;

//TODO: Add telephone number parser
            _patientController.Save(new PatientDTO(
                new AddressDTO(),
                FirstName,
                LastName,
                JMBG,
                TelephoneNumber,
                Gender,
                DateOfBirth,
                InsurenceNumber,
                Profession,
                BloodType,
                float.Parse(Height),
                float.Parse(Weight),
                Email,
                ""
                ));

        }

    }
}
