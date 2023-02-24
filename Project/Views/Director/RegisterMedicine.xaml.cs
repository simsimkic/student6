using Project.Model;
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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for RegisterMedicine.xaml
    /// </summary>
    public partial class RegisterMedicine : Window
    {
        //public static long newMedicineID=100; ?????
        public HomeWindow Home { get; set; }

        public string MedicineName { get; set; }
        
        public RegisterMedicine(HomeWindow home)
        {
            InitializeComponent();
            this.DataContext = this;
            Home = home;
        }

        private void CloseMedicineRegistration(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveMedicineRegistration(object sender, RoutedEventArgs e)
        {
            App app = App.Current as App;
            string Type = NewMedicineType.SelectedValue.ToString();
            string Name = NewMedicineName.Text;
            string Description = NewMedicineDescription.Text;
            PropositionDTO newProposition = new PropositionDTO();
            newProposition.State = "inReview";
            newProposition.Medicine = new MedicineDTO(Name, Type, Description, 0, "placeholder", "administration_placeholder", false);
            newProposition.Approvals = new List<ApprovalDTO>();
            app.PropositionController.Save(newProposition);
            
            this.Close();
        }
    }

}
