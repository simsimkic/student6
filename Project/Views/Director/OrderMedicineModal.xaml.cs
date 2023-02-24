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
    /// Interaction logic for OrderMedicineModal.xaml
    /// </summary>
    public partial class OrderMedicineModal : Window
    {
        public HomeWindow Home { get; set; }

        public MedicineDTO Medicine{ get; set; }

        public int Quantity { get; set; }

        public OrderMedicineModal(HomeWindow home,MedicineDTO medicine)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Home = home;
            this.Medicine = medicine;
        }

        private void CloseMedicineOrder(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveMedicineOrder(object sender, RoutedEventArgs e)
        {
            string str = NewMedicineQuantity.Text;
            if (Int32.TryParse(str, out int Quantity))
            {
                Medicine.Quantity += Quantity;
                App app = App.Current as App;
                app.MedicineController.Update(Medicine);
                Home.MedicineList.ItemsSource = app.MedicineController.GetAll();
                /* MedicineDTO newMedicine = new MedicineDTO();
                 newMedicine.Name = Medicine.Name;
                 newMedicine.Type = Medicine.Type;
                 newMedicine.Id = Medicine.Id;
                 newMedicine.Description = Medicine.Description;
                 newMedicine.Quantity = Medicine.Quantity + Quantity;
                 Home.Medicine.Add(newMedicine);
                 Home.Medicine.Remove(Medicine);*/

            }
            this.Close();
        }


    }
}
