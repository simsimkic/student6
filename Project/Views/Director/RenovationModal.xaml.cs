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
    /// Interaction logic for RenovationModal.xaml
    /// </summary>
    public partial class RenovationModal : Window
    {
        public HomeWindow Home { get; set; }

        public RenovationDTO Renovation { get; set; }


        public List<AppointmentDTO> AppointmentList { get; set; }
           
        public RenovationModal(HomeWindow home, List<AppointmentDTO> list)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Home = home;
            this.AppointmentList = list;
            DateTime date;
            if (list == null || list.Count==0)
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
            endDate=endDate.AddDays(1);
            RenBegin.SelectedDate = date;
            RenEnd.SelectedDate = endDate;
            Renovation = new RenovationDTO();
        }

        private void AdjustRenovationModal(object sender, SelectionChangedEventArgs e)
        {

            var item = ((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content; 
            if(item != null)
            {
                string text = item.ToString();

            if (text != null && RoomType!=null && NewRoomType!=null) { 
                if (text.Equals("Promena funkcije"))
                {
                    RoomType.IsEnabled = true;
                    NewRoomType.IsEnabled = false;
                }
                else if (text.Equals("Pregradjivanje"))
                {
                    RoomType.IsEnabled = false;
                    NewRoomType.IsEnabled = true;
                } 
                else
                {
                    RoomType.IsEnabled = false;
                    NewRoomType.IsEnabled = false;

                }
           
             }
            }
        }



        private void CloseRenovationAppointment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private RoomType GetRoomTypeFromString(string s)
        {
            if (s.Equals("Operaciona sala"))
                return Project.Model.RoomType.operationHall;
            else if (s.Equals("Soba za preglede"))
                return Project.Model.RoomType.medicalRoom;
            else
                return Project.Model.RoomType.hospitalRoom;
        }


        private void SaveRenovationAppointment(object sender, RoutedEventArgs e)
        {
            var item = RenType.SelectedValue.ToString();
            if (item != null )
            {
                string text = item.ToString();
                if (text != null)
                {
                    Renovation.Beginning = RenBegin.SelectedDate.Value.Date;
                    Renovation.End = RenEnd.SelectedDate.Value.Date;
                    Renovation.Type = RenType.SelectedValue.ToString();
                    Renovation.Room = Home.SelectedRoom;
                    if(text.Equals("Promena funkcije"))
                    {
                        string type = RoomType.SelectedValue.ToString();
                        Renovation.NewType = GetRoomTypeFromString(type);
                    }
                    else if (text.Equals("Pregradjivanje"))
                    {
                        string type = NewRoomType.SelectedValue.ToString();
                        Renovation.NewType = GetRoomTypeFromString(type);
                    }
                    else
                    {
                        Renovation.NewType = Home.SelectedRoom.Type;
                    }
                    App app = App.Current as App;
                    app.RenovationController.Save(Renovation);
                    
                }
            } 

            this.Close();
        }
        
    }
}