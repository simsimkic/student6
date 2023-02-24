using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public DoctorDTO SelectedDoctor { get; set; }
        public AnamnesisDTO SelectedAnamneza { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> PastAppoitments
        {
            get;
            set;
        }

        public History(List<MedicalAppointmentDTO> medicalAppointmentDTOs)
        {
            InitializeComponent();
            this.DataContext = this;
            PastAppoitments = new ObservableCollection<MedicalAppointmentDTO>();
            int i = 0;
            foreach (MedicalAppointmentDTO item in medicalAppointmentDTOs){
                item.Id = i++;
                PastAppoitments.Add(item);
            }

            SelectedDoctor = PastAppoitments[0].Doctors.First();
            SelectedAnamneza = PastAppoitments[0].Anamnesis.First();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            string id = ((Button)sender).Tag.ToString();
            int i = int.Parse(id);
            SelectedDoctor = PastAppoitments[i].Doctors.First();
            SelectedAnamneza = PastAppoitments[i].Anamnesis.First();

            Amnezablok.Text = SelectedAnamneza.Description;
        }
    }
}
