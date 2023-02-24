using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for OrderEquipmentModal.xaml
    /// </summary>
    public partial class OrderEquipmentModal : Window
    {
        public EquipmentDTO Equipment { get; set; }
        //public static long NewEquipmentID=100
        public HomeWindow Home { get; set; }

        public int Quantity { get; set; }
        public OrderEquipmentModal(HomeWindow home,EquipmentDTO equipment)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Home = home;
            this.Equipment = equipment;
        }

        private void SaveEquipmentOrder(object sender, RoutedEventArgs e)
        {
            string Description = NewEquipmentDescription.Text;
            string Name = NewEquipmentName.Text;
            string Type = NewEquipmentType.Text;
            int Quantity = Int32.Parse(NewEquipmentQuanitity.Text);
            App app = App.Current as App;

            if (Quantity > 0 && Quantity < 10)
            {
                EquipmentDTO newEquipment = new EquipmentDTO();
                newEquipment.Description = Description;
                newEquipment.Name = Name;
                newEquipment.Type = Type;
                newEquipment.Room = app.RoomController.GetById(0);
                for (int i = 0; i < Quantity; i++)
                {
                    app.EquipmentController.Save(newEquipment);
                   // Home.Equipment.Add(newEquipment);
                   // Home.VisibleEquipment.Add(newEquipment);
                   // Home.Magacin.Equipment.Add(newEquipment);
                }
                Home.EquipmentList.ItemsSource = app.EquipmentController.GetAll();
                Home.VisibleRooms.ItemsSource = app.RoomController.GetAll();
            }
            this.Close();
        }


        private void CloseEquipmentOrder(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
