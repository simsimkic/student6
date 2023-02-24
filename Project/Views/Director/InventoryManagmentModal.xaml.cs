using iTextSharp.xmp.impl;
using Project.Model;
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
    /// Interaction logic for InventoryManagmentModal.xaml
    /// </summary>
    public partial class InventoryManagmentModal : Window
    {
        Point startPoint = new Point();

        public HomeWindow Home { get; set; }


        public ObservableCollection<EquipmentDTO> RoomEquipment
        {
            get;
            set;
        }

        public ObservableCollection<EquipmentDTO> Inventory
        {
            get;
            set;
        }

        private App app;

        public List<EquipmentDTO> Moved { get; set; }

        public InventoryManagementDTO InventoryManagment { get; set; }

        public List<AppointmentDTO> AppointmentList { get; set; }

        public InventoryManagmentModal(HomeWindow home,List<AppointmentDTO> list,List<EquipmentDTO> roomEquipment)
        {
            
            InitializeComponent();
            app = App.Current as App;
            this.DataContext = this;
            this.Home = home;   
            this.AppointmentList = list;
            DateTime date;
            if (list == null || list.Count == 0)
            {
                date = DateTime.Now;
            }
            else
            {
                date = list.First().End;
                foreach (AppointmentDTO appointment in list)
                    if (DateTime.Compare(appointment.End, date) > 0)
                        date = appointment.End;
                date = date.AddDays(3);
            }
            DateTime endDate = date;
            endDate = endDate.AddDays(1);
            ManBegin.SelectedDate = date;
            ManEnd.SelectedDate = endDate;
            InventoryManagment = new InventoryManagementDTO();
            /* ObservableCollection<EquipmentDTO> l1 = new ObservableCollection<EquipmentDTO>();
             l1.Add(new EquipmentDTO() { Name = "Sto", Type = "namestaj" });
             l1.Add(new EquipmentDTO() { Name = "Stolica", Type = "namestaj" });
             l1.Add(new EquipmentDTO() { Name="Cekic", Type = "alat/oruzje"});

             ObservableCollection<EquipmentDTO> l2 = new ObservableCollection<EquipmentDTO>();
             l2.Add(new EquipmentDTO() { Name = "Makaze", Type = "alat" });
             l2.Add(new EquipmentDTO() { Name = "Cekic", Type = "alat" });
             l2.Add(new EquipmentDTO() { Name = "Cekic", Type = "alat/oruzje" });*/


            //if(roomEquipment==null) 
              //  RoomEquipment=new ObservableCollection<EquipmentDTO>(); 
            //else
            RoomEquipment = new ObservableCollection<EquipmentDTO>(); 
            Inventory = new ObservableCollection<EquipmentDTO>(app.EquipmentController.GetAll().Where(eq=>eq.Room.Id==0));   
            Moved = new List<EquipmentDTO>();
            

        }

        private void CloseInventoryManagment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveInventoryManagment(object sender, RoutedEventArgs e)
        {
            InventoryManagment.Beginning = ManBegin.SelectedDate.Value.Date;
            InventoryManagment.End = ManEnd.SelectedDate.Value.Date;
            InventoryManagment.Equipment = new List<EquipmentDTO>();
            foreach (EquipmentDTO eq in RoomEquipment)
                InventoryManagment.Equipment.Add(eq);
            
            InventoryManagment.Room = new RoomDTO(0);
            InventoryManagment.RoomTo = new RoomDTO(Home.SelectedRoom.Id);
            app.InventoryManagementController.Save(InventoryManagment);
            this.Close();
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                DataGrid dgrid = sender as DataGrid;
                DataGridRow item =
                    FindAncestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (item == null) return;

                // Find the data behind the ListViewItem
                EquipmentDTO equip = (EquipmentDTO)dgrid.ItemContainerGenerator.
                    ItemFromContainer(item);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", equip);
                DragDrop.DoDragDrop(item, dragData, DragDropEffects.Move);
            }
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                EquipmentDTO equip = e.Data.GetData("myFormat") as EquipmentDTO;
                Inventory.Remove(equip);
                RoomEquipment.Add(equip);
                Moved.Add(equip);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

    }
}
