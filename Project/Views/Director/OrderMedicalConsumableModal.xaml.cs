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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for OrderMedicalConsumableModal.xaml
    /// </summary>
    public partial class OrderMedicalConsumableModal : Window
    {
        public HomeWindow Home { get; set; }

        public int Quantity { get; set; }

        public MedicalConsumableDTO MedicalConsumable { get; set; }
        public OrderMedicalConsumableModal(HomeWindow home,MedicalConsumableDTO medicalConsumable)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Home = home;
            this.MedicalConsumable = medicalConsumable;
        }

        private void CloseMedicalConsumableOrder(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveMedicalConsumableOrder(object sender, RoutedEventArgs e)
        {
            string str = NewMedicalConsumableQuantity.Text;
            if (Int32.TryParse(str, out int Quantity))
            {
                MedicalConsumable.Quantity += Quantity;
                App app = App.Current as App;
                app.MedicalConsumableController.Update(MedicalConsumable);
                Home.MedicalConsumablesList.ItemsSource = app.MedicalConsumableController.GetAll();
               // ObservableCollection<MedicalConsumableDTO> newList = new ObservableCollection<MedicalConsumableDTO>(Home.VisibleMedicalConsumables);
                //                                                                              Korisceno pre INotifyPropertyChanged
             //   Home.VisibleMedicalConsumables
             /*    MedicalConsumableDTO newMedicalConsumable = new MedicalConsumableDTO();
                 newMedicalConsumable.Name = MedicalConsumable.Name;
                 newMedicalConsumable.Type = MedicalConsumable.Type;
                 newMedicalConsumable.Id = MedicalConsumable.Id;
                 newMedicalConsumable.Description = MedicalConsumable.Description;
                 newMedicalConsumable.Quantity = MedicalConsumable.Quantity+Quantity;
                 Home.MedicalConsumables.Add(newMedicalConsumable);
                 Home.MedicalConsumables.Remove(MedicalConsumable);*/
                
            }
            this.Close();
        }
    }
}
