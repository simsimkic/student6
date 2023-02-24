using Controller;
using iTextSharp.text.pdf;
using Project.Controllers;
using Project.Model;
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
using Project.Views.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using Xceed.Wpf.AvalonDock.Controls;

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    /// 

    public partial class HomeWindow : Window, INotifyPropertyChanged
    {
        private ReportController _reportController;
        public AddressDTO DirectorAddress { get; set; }
        public DirectorDTO Director { get; set; }

        
        public ObservableCollection<PropositionDTO> Propositions {get; set;}

        private ObservableCollection<EmployeeDTO> visibleEmployees;

        public ObservableCollection<EmployeeDTO> VisibleEmployees
        {
            get
            {
                return visibleEmployees;
            }
            set
            {
                if (value != visibleEmployees)
                {
                    visibleEmployees = value;
                    OnPropertyChanged("VisibleEmployees");
                }
            }
        }
        public ObservableCollection<EmployeeDTO> Employees { get; set; }

        public ObservableCollection<DoctorDTO> Doctors { get; set; }

        public ObservableCollection<SecretaryDTO> Secretaries { get; set; }

        private ObservableCollection<EquipmentDTO> visibleEquipment;
        public ObservableCollection<EquipmentDTO> VisibleEquipment
        {
            get
            {
                return visibleEquipment;
            }
            set
            {
                if (value != visibleEquipment)
                {
                    visibleEquipment = value;
                    OnPropertyChanged("VisibleEquipment");
                }
            }
        }

        public ObservableCollection<EquipmentDTO> Equipment { get; set; }

        private ObservableCollection<MedicalConsumableDTO> visibleMedicalConsumables;

        public ObservableCollection<MedicalConsumableDTO> VisibleMedicalConsumables
        {
            get
            {
                return visibleMedicalConsumables;
            }
            set
            {
                if (value != visibleMedicalConsumables)
                {
                    visibleMedicalConsumables = value;
                    OnPropertyChanged("VisibleMedicalConsumables");
                }
            }
        }
        public ObservableCollection<MedicalConsumableDTO> MedicalConsumables { get; set; }

        private ObservableCollection<MedicineDTO> visibleMedicine;

        public ObservableCollection<MedicineDTO> VisibleMedicine
        {
            get
            {
                return visibleMedicine;
            }
            set
            {
                if (value != visibleMedicine)
                {
                    visibleMedicine = value;
                    OnPropertyChanged("VisibleMedicine");
                }
            }
        }


        public ObservableCollection<MedicineDTO> Medicine { get; set; }

        private ObservableCollection<RoomDTO> visibleRoomList;
        public ObservableCollection<RoomDTO> VisibleRoomList
        {
            get
            {
                return visibleRoomList;
            }
            set
            {
                if (value != visibleRoomList)
                {
                    visibleRoomList = value;
                    OnPropertyChanged("VisibleRoomList");
                }
            }
        }

        public ObservableCollection<RoomDTO> RoomList { get; set; }

        public RoomDTO Magacin { get; set; }

        // public EmployeeDTO SelectedEmployee { get; set; }
        private RoomDTO selectedRoom;
        public RoomDTO SelectedRoom
        {
            get
            {
                return selectedRoom;
            }
            set
            {
                if (value != selectedRoom)
                {
                    selectedRoom = value;
                    OnPropertyChanged("SelectedRoom");
                }
            }
        }

        private ObservableCollection<AppointmentDTO> selectedRoomAppointments;

        public ObservableCollection<AppointmentDTO> SelectedRoomAppointments
            {
                get
                {
                    return selectedRoomAppointments;
                }
                set
                {
                    if (value != selectedRoomAppointments)
                    {
                        selectedRoomAppointments = value;
                        OnPropertyChanged("SelectedRoomAppointments");
                    }
                }
            }
        
        public int EquipmentListID { get; set; }

        public string EquipmentListType { get; set; }

        public string EquipmentListName  {get; set; }

        public string EmployeeListFirstName { get; set; }

        public string EmployeeListLastName { get; set; }

        public string EmployeeListSpecialisation { get; set; }

        public int ConsumableListID { get; set; }

        public string ConsumableListType {get; set; }

        public string ConsumableListName { get; set; }

        public int MedicineListID { get; set; }

        public string MedicineListType { get; set; }

        public string MedicineListName { get; set; }

        public int RoomListID { get; set; }

        public string RoomListDepartman { get; set; }

        public int RoomListFloor { get; set; }


        public HomeWindow()
        {
            
           
            InitializeComponent();
            this.DataContext = this;
            var app = System.Windows.Application.Current as App;

            _reportController = app.ReportController;
            AddressDTO address = new AddressDTO("15", "Bulevar Cara Lazara", "Skoplje", "Severna Makedonija", "17954");
            UserDTO c = app.currentUser;
            Director = new DirectorDTO(c.Address, c.FirstName, c.LastName, c.Jmbg, c.TelephoneNumber, c.Gender, c.DateOfBirth, 13000, null, null, app.director.Email, app.director.Password, "Klinicki Centar Vojvodina");
                // new DirectorDTO(address,"Pera", "Peric", "0102031234567", "012/173212", "Male", new DateTime(1985, 11, 5), 13000, null, null, "pera@makedonac.nmac", "pass", "Klinicki Centar Vojvodina");
         
            Propositions = new ObservableCollection<PropositionDTO>();
            //Propositions.Add(new PropositionDTO(1,"Berodual","Berodual je ...", "Odobren",5,2));
            //Propositions.Add(new PropositionDTO(2,"Promazepam", "Promazepam sluzi za ...", "Odbijen",3,7));
            //Propositions.Add(new PropositionDTO(3,"Febricet", "Febricet je valjda za temperaturu, Dr. Kon aj proveri", "Odobren",3,0));
            //Propositions.Add(new PropositionDTO(4,"Strepsils", "Tablete za upalu grla", "Odobren",6,2));
            //Propositions.Add(new PropositionDTO(5,"Venospas", "Revolucionarno lecenje ozoniranjem krvi", "U razmatranju",1,1));
            //Propositions.Add(new PropositionDTO(5, "ZdravkoHerbiko", "Sirup za grlo", "Odbijen", 1, 8));

            SecretaryDTO newSecretary;
            DoctorDTO newDoctor;
            RoomDTO newRoom;
      
            Employees = new ObservableCollection<EmployeeDTO>();
            Doctors = new ObservableCollection<DoctorDTO>();
            Secretaries = new ObservableCollection<SecretaryDTO>();

            newSecretary= new SecretaryDTO(address, "Sikola", "Nelic", "0412994232567", "022/353452", "Male", new DateTime(1994, 6, 24), 50000, new TimeInterval(new DateTime(2020, 12, 5), new DateTime(2020, 12, 27)), new TimeInterval(new DateTime(2020, 12, 5, 7, 0, 0), new DateTime(2020, 12, 27, 15, 0, 0)), "simo@gmail.com", "sifria1", "Klinicko Centar Vojvodina");
            Employees.Add(newSecretary);
            Secretaries.Add(newSecretary);

            newRoom = new RoomDTO(70, RoomType.hospitalRoom, "Kardio", "3");
            newDoctor = new DoctorDTO(address, "Sima", "Paroski", "0412631232567", "022/353452", "Male", new DateTime(1969, 6, 24), 24000, new TimeInterval(new DateTime(2020,12,5),new DateTime(2020, 12, 27)), new TimeInterval(new DateTime(2020, 12, 5,7,0,0), new DateTime(2020, 12, 27,15,0,0)), "simo@gmail.com", "sifria1","Klinicko Centar Vojvodina","Hirurg");
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 15, 12, 40, 0), new DateTime(2020, 6, 15, 13, 50, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 15, 14, 00, 0), new DateTime(2020, 6, 15, 17, 20, 0), newRoom, MedicalAppointmentType.operation, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 15, 17, 35, 0), new DateTime(2020, 6, 15, 18, 25, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 16, 12, 38, 0), new DateTime(2020, 6, 16, 14, 59, 0), newRoom, MedicalAppointmentType.operation, null, null));
            Employees.Add(newDoctor);
            Doctors.Add(newDoctor);

            newRoom = new RoomDTO(120, RoomType.hospitalRoom, "Kardio", "2");
            newDoctor =new DoctorDTO(address, "Humus", "Dumus", "05553331232567", "028/352352", "Female", new DateTime(1969, 6, 24), 23000, null, null, "simo@gmail.com", "sifria1","Klinicko Centar Vojvodina", "Opsta praksa");
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 17, 12, 40, 0), new DateTime(2020, 6, 17, 13, 59, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 17, 14, 00, 0), new DateTime(2020, 6, 17, 16, 37, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 18, 17, 35, 0), new DateTime(2020, 6, 18, 18, 40, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 18, 18, 50, 0), new DateTime(2020, 6, 18, 19, 35, 0), newRoom, MedicalAppointmentType.operation, null, null));
            Employees.Add(newDoctor);
            Doctors.Add(newDoctor);

            newRoom = new RoomDTO(120, RoomType.hospitalRoom, "Kardio", "4");
            newDoctor = new DoctorDTO(address, "Petar", "Gringovic", "0412631232567", "022/353652", "Male", new DateTime(1969, 6, 24), 28000, null, null, "simo@gmail.com", "sifria1", "Klinicko Centar Vojvodina", "Egzekutor");
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 13, 12, 40, 0), new DateTime(2020, 6, 13, 13, 50, 0), newRoom, MedicalAppointmentType.operation, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 13, 14, 00, 0), new DateTime(2020, 6, 13, 14, 50, 0), newRoom, MedicalAppointmentType.operation, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 20, 17, 35, 0), new DateTime(2020, 6, 20, 18, 40, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 20, 19, 0, 0), new DateTime(2020, 6, 20, 22, 25, 0), newRoom, MedicalAppointmentType.operation, null, null));
            Employees.Add(newDoctor);
            Doctors.Add(newDoctor);

            newRoom = new RoomDTO(115, RoomType.hospitalRoom, "Kardio", "1");
            newDoctor = new DoctorDTO(address, "Slavica", "Bubregovic", "0412631232567", "022/253452", "Female", new DateTime(1980, 6, 24), 2200, null, null, "simo@gmail.com", "sifria1","Klinicko Centar Vojvodina", "Hirurg");
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 1, 8, 40, 0), new DateTime(2020, 6, 1, 9, 50, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 1, 14, 15, 0), new DateTime(2020, 6, 1, 15, 20, 0), newRoom, MedicalAppointmentType.operation, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 24, 17, 00, 0), new DateTime(2020, 6, 24, 18, 40, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 24, 19, 15, 0), new DateTime(2020, 6, 24, 19, 16, 0), newRoom, MedicalAppointmentType.examination, null, null));
            Employees.Add(newDoctor);
            Doctors.Add(newDoctor);

            newRoom = new RoomDTO(313, RoomType.hospitalRoom, "Kardio", "5");
            newDoctor =new DoctorDTO(address, "Dusan", "Urosevic", "0405999999999", "021/321785", "Male", new DateTime(1998, 5, 4), 100000, new TimeInterval(new DateTime(2020, 5, 10), new DateTime(2020, 7, 29)), new TimeInterval(new DateTime(2020, 12, 5,12,30,0), new DateTime(2020, 12, 27,12,35,0)), "simo@gmail.com", "sifria1", "Klinicko Centar Vojvodina", "Hirurg");
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 25, 12, 20, 0), new DateTime(2020, 6, 25, 12, 22, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 26, 12, 25, 0), new DateTime(2020, 6, 26, 12, 30, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 27, 13, 40, 0), new DateTime(2020, 6, 27, 13, 42, 0), newRoom, MedicalAppointmentType.examination, null, null));
            Employees.Add(newDoctor);
            Doctors.Add(newDoctor);

            newRoom = new RoomDTO(1914, RoomType.hospitalRoom, "Kardio", "3");
            newDoctor=new DoctorDTO(address, "Zilip", "Felar", "0102999999999", "021/555-333", "Male", new DateTime(1998, 12, 12), 70000, new TimeInterval(new DateTime(2020, 5, 12), new DateTime(2020, 7, 12)), new TimeInterval(new DateTime(2020, 12, 31, 12, 30, 0), new DateTime(2020, 12, 31, 12, 35, 0)), "simo@gmail.com", "sifria1", "Klinicko Centar Vojvodina", "Hirurg");
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 15, 8, 40, 0), new DateTime(2020, 6, 15, 15, 50, 0), newRoom, MedicalAppointmentType.operation, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 15, 15, 25, 0), new DateTime(2020, 6, 15, 15, 35, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 17, 15, 40, 0), new DateTime(2020, 6, 17, 18, 11, 0), newRoom, MedicalAppointmentType.examination, null, null));
            newDoctor.Appointments.Add(new MedicalAppointmentDTO(new DateTime(2020, 6, 17, 18, 15, 0), new DateTime(2020, 6, 17, 19, 14, 0), newRoom, MedicalAppointmentType.examination, null, null));
            Employees.Add(newDoctor);
            Doctors.Add(newDoctor);


            VisibleEmployees = new ObservableCollection<EmployeeDTO>(Employees);
            //(_secretaryRepository.GetAll() as List<Employee>)
            //.Concat(_doctorRepository.GetAll() as List<Employee>);
            //Popunjava listu sa svim zaposlenima
            RefreshEmployeeList();


            Equipment = new ObservableCollection<EquipmentDTO>();
            Magacin = new RoomDTO(0,RoomType.hospitalRoom,"magacin","");
            EquipmentDTO novaOprema= new EquipmentDTO(1, "Sto", "Namestaj", "Ovo je sto ima cetiri noge i na njega se stavljaju stvari", Magacin);
            Magacin.Equipment.Add(novaOprema);
            Equipment.Add(novaOprema);
            novaOprema = new EquipmentDTO(2, "Stolica", "Namestaj", "Ovo je stolica, ima cetiri noge i na njoj se sedi", Magacin);
            Magacin.Equipment.Add(novaOprema);
            Equipment.Add(novaOprema);
            novaOprema = new EquipmentDTO(3,"Operacioni sto", "Oprema", "Model XYZ,...", Magacin);
            Magacin.Equipment.Add(novaOprema);
            Equipment.Add(novaOprema);
            novaOprema = new EquipmentDTO(4,"Vrata", "Infrastuktura", "Open Sesame", Magacin);
            Magacin.Equipment.Add(novaOprema);
            Equipment.Add(novaOprema);
            novaOprema = new EquipmentDTO(5,"Respirator", "Donacija", "Mehanicko disanje???", Magacin);
            Magacin.Equipment.Add(novaOprema);
            Equipment.Add(novaOprema);
            VisibleEquipment = new ObservableCollection<EquipmentDTO>(Equipment);
            EquipmentList.ItemsSource= new ObservableCollection<EquipmentDTO>(app.EquipmentController.GetAll());

            MedicalConsumables = new ObservableCollection<MedicalConsumableDTO>();
            MedicalConsumables.Add(new MedicalConsumableDTO(1, "Gaza", "zavoj", "zavoj je izmislio Vasko Popa...", 23));
            MedicalConsumables.Add(new MedicalConsumableDTO(2, "Hanzaplast", "zavoj", "zavoj je izmislio Vasko Popa...", 16));
            MedicalConsumables.Add(new MedicalConsumableDTO(3, "Hidrogen", "rastvor", "zavoj je izmislio Vasko Popa...", 18));
            MedicalConsumables.Add(new MedicalConsumableDTO(4, "Fizioloski rastvor", "rastvor", "zavoj je izmislio Vasko Popa...", 5));
            VisibleMedicalConsumables = new ObservableCollection<MedicalConsumableDTO>(MedicalConsumables);
            MedicalConsumablesList.ItemsSource = new ObservableCollection<MedicalConsumableDTO>(app.MedicalConsumableController.GetAll());

            Medicine = new ObservableCollection<MedicineDTO>();
            Medicine.Add(new MedicineDTO(5, "Berodual", "kortikosteroid", "zavoj je izmislio Vasko Popa...", 23,"","intravenozno",false));
            Medicine.Add(new MedicineDTO(6, "Probiotik Ivancic&sons", "probiotik", "zavoj je izmislio Vasko Popa...", 16, "", "oralno", false));
            Medicine.Add(new MedicineDTO(7, "Fervex", "prasak", "zavoj je izmislio Vasko Popa...", 18, "", "", true));
            Medicine.Add(new MedicineDTO(8, "Zufiofilum", "antibiotik", "zavoj je izmislio Vasko Popa...", 5, "", "", true));
            VisibleMedicine = new ObservableCollection<MedicineDTO>(Medicine);
            MedicineList.ItemsSource = new ObservableCollection<MedicineDTO>(app.MedicineController.GetAll());


            RoomList = new ObservableCollection<RoomDTO>();
            RoomDTO tester = new RoomDTO(12, RoomType.hospitalRoom, "Intenzivna nega", "4");
            AppointmentDTO testapp = new AppointmentDTO(1,new DateTime(2020,6,12,7,45,0), new DateTime(2020, 6, 12, 8, 20, 0),tester);
            tester.Appointments.Add(testapp);
            RoomList.Add(tester);
            RoomList.Add(new RoomDTO(24, RoomType.operationHall, "Kardiovaskularna", "2"));
            RoomList.Add(new RoomDTO(17, RoomType.medicalRoom, "Pregledi", "1"));
            RoomList.Add(new RoomDTO(5, RoomType.hospitalRoom, "Intenzivna nega", "3"));
            VisibleRoomList = new ObservableCollection<RoomDTO>(RoomList);
            VisibleRooms.ItemsSource = new ObservableCollection<RoomDTO>(app.RoomController.GetAll());
            
        }

        private void OpenSettingsModal(object sender, RoutedEventArgs e)
        {
            SettingsModal modal = new SettingsModal();
            modal.ShowDialog();
        }

        private void OpenBugReportModal(object sender, RoutedEventArgs e)
        {
            BugReportModal modal = new BugReportModal();
            modal.ShowDialog();
        }

        private void ChangeProfile(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Visible; ;
           // Cancel_btn.Visibility = Visibility.Visible; -Dugme vise ne postoji
            Change_btn.Visibility = Visibility.Hidden;
            email.IsEnabled = true;
            adress.IsEnabled = true;
            dateofbirth.IsEnabled = true;
            hospital.IsEnabled = true;
            jmbg.IsEnabled = true;
        }

        private void CancelProfileChanges(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Hidden; ;
           // Cancel_btn.Visibility = Visibility.Hidden; 
            Change_btn.Visibility = Visibility.Visible;
            email.IsEnabled = false;
            adress.IsEnabled = false;
            dateofbirth.IsEnabled = false;
            hospital.IsEnabled = false;
            jmbg.IsEnabled = false;
        }

        private void ConfirmProfileChanges(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Hidden; ;
        //  Cancel_btn.Visibility = Visibility.Hidden; ;
            Change_btn.Visibility = Visibility.Visible;
            email.IsEnabled = false;
            adress.IsEnabled = false;
            dateofbirth.IsEnabled = false;
            hospital.IsEnabled = false;
            jmbg.IsEnabled = false;
        }

        private void OpenEmployeeDataModal(object sender, RoutedEventArgs e)
        {
            
            EmployeeDataModal modal = new EmployeeDataModal(this); //prosledjujemo home window da bi mogli novog zaposlenog da dodamo u listu Employees
            modal.ShowDialog();
        }

        private void OpenEmployeeDetails(object sender, RoutedEventArgs e)
        {
            // SelectedEmployee = (EmployeeDTO)EmployeeList.SelectedItem;
            var btn = sender as System.Windows.Controls.Button;
            EmployeeList.SelectedItem = btn.DataContext;
            EmployeesGrid.Visibility = Visibility.Collapsed;
            EmployeeDetailsGrid.Visibility = Visibility.Visible;
        }

        private void OpenEmplyees(object sender, RoutedEventArgs e)
        {
            EmployeeDetailsGrid.Visibility = Visibility.Collapsed;
            EmployeesGrid.Visibility = Visibility.Visible;
        }

       
        private void OpenRooms(object sender, RoutedEventArgs e)
        {
           
            RoomDetails.Visibility = Visibility.Collapsed;
            Rooms.Visibility = Visibility.Visible;
        }

        private void OpenRoomDetails(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            //RoomsList.SelectedItem = btn.DataContext;
            SelectedRoomAppointments = null;
            SelectedRoom = btn.DataContext as RoomDTO;
            Rooms.Visibility = Visibility.Collapsed;
            RoomDetails.Visibility = Visibility.Visible;
        }

        private void OpenEquipmentOrder(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            //EquipmentList.SelectedItem = btn.DataContext;
            OrderEquipmentModal modal = new OrderEquipmentModal(this,(EquipmentDTO)btn.DataContext);
            modal.Show();
        }

        private void OpenMedicineOrder(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            OrderMedicineModal modal = new OrderMedicineModal(this, (MedicineDTO)btn.DataContext);
            modal.Show();
        }

        private void OpenMedicineRegistration(object sender, RoutedEventArgs e)
        {

            RegisterMedicine modal = new RegisterMedicine(this);
            modal.Show();
        }

        private void OpenMedicalConsumableOrder(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;     
            OrderMedicalConsumableModal modal = new OrderMedicalConsumableModal(this, (MedicalConsumableDTO)btn.DataContext);
            modal.Show();
        }

        private void OpenRenovationAppointment(object sender, RoutedEventArgs e)
        {
            RenovationModal modal = new RenovationModal(this,SelectedRoom.Appointments);
            modal.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenInventoryManagment(object sender, RoutedEventArgs e)
        {
            InventoryManagmentModal modal = new InventoryManagmentModal(this,SelectedRoom.Appointments,SelectedRoom.Equipment);
            modal.Show();
        }

        private void ChangeEmployeeProfile(object sender, RoutedEventArgs e)
        {
            foreach (System.Windows.Controls.TextBox textBox in employeeData.Children)
            textBox.IsEnabled = true;
            Save_employee.Visibility = Visibility.Visible;
        //   Cancel_employee.Visibility = Visibility.Visible;
            Change_employee.Visibility = Visibility.Collapsed;
        }

       

        private void Generate_Room_Report(object sender, RoutedEventArgs e)
        {



        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GenerateAppointmentsForDate(object sender, SelectionChangedEventArgs e)
        {
            if (RoomCalendar.SelectedDate.HasValue && SelectedRoom!=null)
            {
                DateTime date = (DateTime)RoomCalendar.SelectedDate;
              
                SelectedRoomAppointments= new ObservableCollection<AppointmentDTO>();
                List<AppointmentDTO> list = SelectedRoom.Appointments;
                if (list!=null) {
                    foreach (AppointmentDTO app in list)
                        if (app.Beginning.Date.Day == date.Date.Day && app.Beginning.Date.Month == date.Date.Month && app.Beginning.Year == date.Date.Year) //verovatno moze samo .Date=.Date
                        {
                            SelectedRoomAppointments.Add(app);
                        } 
                }
            }

        }

        

        private void EmpoyeeFilter(object sender, RoutedEventArgs e)
        {
            string firstName = EmployeeListFirstName;
            string lastName = EmployeeListLastName;
        
            ObservableCollection<EmployeeDTO> helper = new ObservableCollection<EmployeeDTO>(Employees);
            ObservableCollection<EmployeeDTO> helper2 = new ObservableCollection<EmployeeDTO>();
            if (firstName!=null && !firstName.Equals(""))
            {
                foreach (EmployeeDTO emp in helper)
                    if (emp.FirstName.Equals(firstName))
                        helper2.Add(emp);
                helper = helper2;
                helper2 = new ObservableCollection<EmployeeDTO>();
            }
            
            if (lastName != null && !lastName.Equals(""))
            {
                foreach (EmployeeDTO emp in helper)
                    if (emp.FirstName.Equals(firstName))
                        helper2.Add(emp);
                helper = helper2;
                helper2 = new ObservableCollection<EmployeeDTO>();
            }

            VisibleEmployees = helper;

        }

        private void EmployeeSort(object sender, RoutedEventArgs e)
        {
            EmployeeDTO helper;
            string sort = EmployeeListSort.SelectedValue.ToString();
            if (sort.Equals("Ime(A-Z)"))
            {
                for(int i=0;i<VisibleEmployees.Count;i++)
                    for(int j=i+1;j<VisibleEmployees.Count;j++)
                        if (string.Compare(VisibleEmployees[i].FirstName, VisibleEmployees[j].FirstName) > 0)
                        {
                            helper = VisibleEmployees[i];
                            VisibleEmployees[i] = VisibleEmployees[j];
                            VisibleEmployees[j] = helper;
                        }

            }
            else if (sort.Equals("Prezime(A-Z)"))
            {
                for (int i = 0; i < VisibleEmployees.Count; i++)
                    for (int j = i + 1; j < VisibleEmployees.Count; j++)
                        if (string.Compare(VisibleEmployees[i].LastName, VisibleEmployees[j].LastName) > 0)
                        {
                            helper = VisibleEmployees[i];
                            VisibleEmployees[i] = VisibleEmployees[j];
                            VisibleEmployees[j] = helper;
                        }
            }
            else return;     

        }
        private void FilterEquipment(object sender, RoutedEventArgs e)
        {
            string Name = EquipmentListName;
            string Type = EquipmentListType;

            ObservableCollection<EquipmentDTO> helper = new ObservableCollection<EquipmentDTO>(Equipment);
            ObservableCollection<EquipmentDTO> helper2 = new ObservableCollection<EquipmentDTO>();
            if (Name != null && !Name.Equals(""))
            {
                foreach (EquipmentDTO equ in helper)
                    if (equ.Name.Equals(Name))
                        helper2.Add(equ);
                helper = helper2;
                helper2 = new ObservableCollection<EquipmentDTO>();
            }

            if (Type != null && !Type.Equals(""))
            {
                foreach (EquipmentDTO equ in helper)
                    if (equ.Type.Equals(Type))
                        helper2.Add(equ);
                helper = helper2;
                helper2 = new ObservableCollection<EquipmentDTO>();
            }

            VisibleEquipment = helper;
        }

        private void EquipmentSort(object sender, RoutedEventArgs e)
        {
            EquipmentDTO helper;
            string sort = EquipmentListSort.SelectedValue.ToString();
            if (sort.Equals("Naziv(A-Z)"))
            {
                for (int i = 0; i < VisibleEquipment.Count; i++)
                    for (int j = i + 1; j < VisibleEquipment.Count; j++)
                        if (string.Compare(VisibleEquipment[i].Name, VisibleEquipment[j].Name) > 0)
                        {
                            helper = VisibleEquipment[i];
                            VisibleEquipment[i] = VisibleEquipment[j];
                            VisibleEquipment[j] = helper;
                        }

            }
            else if (sort.Equals("Tip(A-Z)"))
            {
                for (int i = 0; i < VisibleEquipment.Count; i++)
                    for (int j = i + 1; j < VisibleEquipment.Count; j++)
                        if (string.Compare(VisibleEquipment[i].Type, VisibleEquipment[j].Type) > 0)
                        {
                            helper = VisibleEquipment[i];
                            VisibleEquipment[i] = VisibleEquipment[j];
                            VisibleEquipment[j] = helper;
                        }
            }
            else return;
        }

        private void FilterMedicalConsumables(object sender, RoutedEventArgs e)
        {
            string Name = ConsumableListName;
            string Type = ConsumableListType;

            ObservableCollection<MedicalConsumableDTO> helper = new ObservableCollection<MedicalConsumableDTO>(MedicalConsumables);
            ObservableCollection<MedicalConsumableDTO> helper2 = new ObservableCollection<MedicalConsumableDTO>();
            if (Name != null && !Name.Equals(""))
            {
                foreach (MedicalConsumableDTO med in helper)
                    if (med.Name.Equals(Name))
                        helper2.Add(med);
                helper = helper2;
                helper2 = new ObservableCollection<MedicalConsumableDTO>();
            }

            if (Type != null && !Type.Equals(""))
            {
                foreach (MedicalConsumableDTO med in helper)
                    if (med.Type.Equals(Type))
                        helper2.Add(med);
                helper = helper2;
                helper2 = new ObservableCollection<MedicalConsumableDTO>();
            }

            VisibleMedicalConsumables = helper;
        }

        private void MedicalConsumablesSort(object sender, RoutedEventArgs e)
        {
            MedicalConsumableDTO helper;
            string sort = ConsumableListSort.SelectedValue.ToString();
            if (sort.Equals("Naziv(A-Z)"))
            {
                for (int i = 0; i < VisibleMedicalConsumables.Count; i++)
                    for (int j = i + 1; j < VisibleMedicalConsumables.Count; j++)
                        if (string.Compare(VisibleMedicalConsumables[i].Name, VisibleMedicalConsumables[j].Name) > 0)
                        {
                            helper = VisibleMedicalConsumables[i];
                            VisibleMedicalConsumables[i] = VisibleMedicalConsumables[j];
                            VisibleMedicalConsumables[j] = helper;
                        }

            }
            else if (sort.Equals("Tip(A-Z)"))
            {
                for (int i = 0; i < VisibleMedicalConsumables.Count; i++)
                    for (int j = i + 1; j < VisibleMedicalConsumables.Count; j++)
                        if (string.Compare(VisibleMedicalConsumables[i].Type, VisibleMedicalConsumables[j].Type) > 0)
                        {
                            helper = VisibleMedicalConsumables[i];
                            VisibleMedicalConsumables[i] = VisibleMedicalConsumables[j];
                            VisibleMedicalConsumables[j] = helper;
                        }
            }
            else return;
        }

        private void FilterMedicine(object sender, RoutedEventArgs e)
        {
            string Name = MedicineListName;
            string Type = MedicineListType;

            ObservableCollection<MedicineDTO> helper = new ObservableCollection<MedicineDTO>(Medicine);
            ObservableCollection<MedicineDTO> helper2 = new ObservableCollection<MedicineDTO>();
            if (Name != null && !Name.Equals(""))
            {
                foreach (MedicineDTO med in helper)
                    if (med.Name.Equals(Name))
                        helper2.Add(med);
                helper = helper2;
                helper2 = new ObservableCollection<MedicineDTO>();
            }

            if (Type != null && !Type.Equals(""))
            {
                foreach (MedicineDTO med in helper)
                    if (med.Type.Equals(Type))
                        helper2.Add(med);
                helper = helper2;
                helper2 = new ObservableCollection<MedicineDTO>();
            }

            VisibleMedicine = helper;
        }

        private void MedicineSort(object sender, RoutedEventArgs e)
        {
            MedicineDTO helper;
            string sort = MedicineListSort.SelectedValue.ToString();
            if (sort.Equals("Naziv(A-Z)"))
            {
                for (int i = 0; i < VisibleMedicine.Count; i++)
                    for (int j = i + 1; j < VisibleMedicine.Count; j++)
                        if (string.Compare(VisibleMedicine[i].Name, VisibleMedicine[j].Name) > 0)
                        {
                            helper = VisibleMedicine[i];
                            VisibleMedicine[i] = VisibleMedicine[j];
                            VisibleMedicine[j] = helper;
                        }

            }
            else if (sort.Equals("Tip(A-Z)"))
            {
                for (int i = 0; i < VisibleMedicine.Count; i++)
                    for (int j = i + 1; j < VisibleMedicine.Count; j++)
                        if (string.Compare(VisibleMedicine[i].Type, VisibleMedicine[j].Type) > 0)
                        {
                            helper = VisibleMedicine[i];
                            VisibleMedicine[i] = VisibleMedicine[j];
                            VisibleMedicine[j] = helper;
                        }
            }
            else return;
        }

        private void FilterRooms(object sender, RoutedEventArgs e)
        {
            string Ward = RoomListDepartman;
            int Floor = RoomListFloor;
            int Id = RoomListID;

            ObservableCollection<RoomDTO> helper = new ObservableCollection<RoomDTO>(RoomList);
            ObservableCollection<RoomDTO> helper2 = new ObservableCollection<RoomDTO>();
            if (Ward != null && !Ward.Equals(""))
            {
                foreach (RoomDTO room in helper)
                    if (room.Ward.Equals(Ward))
                        helper2.Add(room);
                helper = helper2;
                helper2 = new ObservableCollection<RoomDTO>();
            }

            if (Floor!=0)
            {
                foreach (RoomDTO room in helper)
                    if (Int32.Parse(room.Floor)==Floor)
                        helper2.Add(room);
                helper = helper2;
                helper2 = new ObservableCollection<RoomDTO>();
            }

            if (Id != 0)
            {
                foreach (RoomDTO room in helper)
                    if (room.Id == Id)
                        helper2.Add(room);
                helper = helper2;
                helper2 = new ObservableCollection<RoomDTO>();
            }

            VisibleRoomList = helper;
        }


        private void FilterRoomByType(object sender, RoutedEventArgs e)
        {
            string type = RoomListType.SelectedValue.ToString();
            RoomType roomType;
            ObservableCollection<RoomDTO> helper = new ObservableCollection<RoomDTO>();
            if (type.Equals("Operaciona sala"))
            {
                roomType = RoomType.operationHall;
            }
            else if (type.Equals("Intenzivna nega"))
            {
                roomType = RoomType.hospitalRoom;
            }
            else if (type.Equals("Soba za preglede"))
            {
                roomType = RoomType.medicalRoom;
            }
            else if (type.Equals("Sve prostorije"))
            {
                VisibleRoomList = new ObservableCollection<RoomDTO>(RoomList);
                return;
            }
            else 
                return;

                foreach (RoomDTO room in RoomList)
                if (room.Type == roomType)
                    helper.Add(room);

            VisibleRoomList = helper;
        }

        private void FilterEmployeesByType(object sender, RoutedEventArgs e)
        {
            string type = EmployeeListType.SelectedValue.ToString();
            if (type.Equals("Sekretari"))
            {
                VisibleEmployees = new ObservableCollection<EmployeeDTO>(Secretaries);
            }
            else if (type.Equals("Lekari"))
            {
                VisibleEmployees = new ObservableCollection<EmployeeDTO>(Doctors);
            }
            else
                VisibleEmployees = new ObservableCollection<EmployeeDTO>(Employees);
        }

        private void RoomSort(object sender, RoutedEventArgs e)
        {
            RoomDTO helper;
            string sort = RoomListSort.SelectedValue.ToString();
            if (sort.Equals("Broj sobe(rastuce)"))
            {
                for (int i = 0; i < VisibleRoomList.Count; i++)
                    for (int j = i + 1; j < VisibleRoomList.Count; j++)
                        if (VisibleRoomList[i].Id > VisibleRoomList[j].Id)
                        {
                            helper = VisibleRoomList[i];
                            VisibleRoomList[i] = VisibleRoomList[j];
                            VisibleRoomList[j] = helper;
                        }

            }
            else if (sort.Equals("Departman(A-Z)"))
            {
                for (int i = 0; i < VisibleRoomList.Count; i++)
                    for (int j = i + 1; j < VisibleRoomList.Count; j++)
                        if (string.Compare(VisibleRoomList[i].Ward, VisibleRoomList[j].Ward) > 0)
                        {
                            helper = VisibleRoomList[i];
                            VisibleRoomList[i] = VisibleRoomList[j];
                            VisibleRoomList[j] = helper;
                        }
            }
            else return;
        }


        private void ResetEmployeeList(object sender, RoutedEventArgs e)
        {
            VisibleEmployees = new ObservableCollection<EmployeeDTO>(Employees);
        }

        private void ResetRoomList(object sender, RoutedEventArgs e)
        {
            VisibleRoomList = new ObservableCollection<RoomDTO>(RoomList);
        }

        private void ResetEquipmentList(object sender, RoutedEventArgs e)
        {
            VisibleEquipment = new ObservableCollection<EquipmentDTO>(Equipment);
        }

        private void ResetMedicalConsumablesList(object sender, RoutedEventArgs e)
        {
            VisibleMedicalConsumables = new ObservableCollection<MedicalConsumableDTO>(MedicalConsumables);
        }

        private void ResetMedicineList(object sender, RoutedEventArgs e)
        {
            VisibleMedicine = new ObservableCollection<MedicineDTO>(Medicine);
        }
        private void GenerateMedicineReport(object sender, RoutedEventArgs e)
        {
            App app = App.Current as App;
            app.MedicineReportGenerator.Generate(new TimeInterval(new DateTime(),new DateTime()));
        }

        private void GenerateDoctorReport(object sender, RoutedEventArgs e)
        {
            
            if (EmployeeReportStartDate.SelectedDate == null || EmployeeReportEndDate.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Neki od datuma je null");
                return;
            }
            DateTime Start = EmployeeReportStartDate.SelectedDate.Value.Date;
            DateTime End = EmployeeReportEndDate.SelectedDate.Value.Date;
            if (DateTime.Compare(Start,End)>=0)
            {
                System.Windows.MessageBox.Show("Datumi moraju biti razliciti i u prirodnom redosledu");
                return;
            }
            App app = App.Current as App;
            app.DoctorsAppointmentReport.Generate(new TimeInterval(Start, End));
                  
           /* Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Lenovo_NB\\Desktop\\Izvestaj.pdf",FileMode.Create));
            doc.Open();

            doc.Add(new iTextSharp.text.Paragraph($"Bolnica: {Director.Hospital}"));
            doc.Add(new iTextSharp.text.Paragraph($"Datum: {CurrentTime.Day}/{CurrentTime.Month}/{CurrentTime.Year} "));

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("IZVESTAJ O ZAUZETOSTI LEKARA \n");
            paragraph.Alignment = 1;
            doc.Add(paragraph);

            doc.Add(new iTextSharp.text.Paragraph($"Na zahtevu upravnika: {Director.FirstName} {Director.LastName} iz {Director.Address.City} " +
               $"formiran je sledeci izvestaj o zauzetosti lekara u periodu od {Start.Day}.{Start.Month}.{Start.Year} do {End.Day}.{End.Month}.{End.Year}. \n " +
               $"Lekari koji su zaposleni u bolnici {Director.Hospital} su sledeci: \n"));

           for(int i=0; i<Doctors.Count;i++)
                doc.Add(new iTextSharp.text.Paragraph($"Dr.{Doctors[i].FirstName} {Doctors[i].LastName}"));

            doc.Add(new iTextSharp.text.Paragraph($"\n Termini lekara u periodu od {Start.Day}.{Start.Month}.{Start.Year} do {End.Day}.{End.Month}.{End.Year}. su sledeci: \n"));
            
            for (int i = 0; i < Doctors.Count; i++)
            {
                List<MedicalAppointmentDTO> appointments = Doctors[i].Appointments;
                if(appointments==null)
                    doc.Add(new iTextSharp.text.Paragraph($"Dr.{Doctors[i].FirstName} {Doctors[i].LastName} nema termina u ovom periodu."));
                else
                {
                    doc.Add(new iTextSharp.text.Paragraph($"Dr.{Doctors[i].FirstName} {Doctors[i].LastName}: \n"));
                    PdfPTable table = new PdfPTable(7);
                    table.WidthPercentage = 90;
                    table.AddCell(new Phrase("Red. br"));
                    table.AddCell(new Phrase("Dan"));
                    table.AddCell(new Phrase("Pocetak"));
                    table.AddCell(new Phrase("Kraj"));
                    table.AddCell(new Phrase("Br. Sobe"));
                    table.AddCell(new Phrase("Sprat"));
                    table.AddCell(new Phrase("Tip termina"));
                    int br = 0;
                    for (int j = 0; j <appointments.Count; j++)
                    {
                        if (DateTime.Compare(appointments[j].Beginning,Start)>0 && DateTime.Compare(appointments[j].End,End)<0) {
                            br++;
                            DateTime start=appointments[j].Beginning;
                            DateTime end = appointments[j].End;
                            table.AddCell(new Phrase($"{br}."));
                            table.AddCell(new Phrase($"{start.Day}/{start.Month}/{start.Year}"));
                            table.AddCell(new Phrase($"{start.Hour}:{start.Minute}"));
                            table.AddCell(new Phrase($"{end.Hour}:{end.Minute}"));
                            table.AddCell(new Phrase($"{appointments[j].Room.Id}"));
                            table.AddCell(new Phrase($"{appointments[j].Room.Floor}"));
                            if (appointments[j].Type == MedicalAppointmentType.examination)
                                table.AddCell(new Phrase("Pregled"));
                            else
                                table.AddCell(new Phrase($"Operacija"));
                        }
                    }
                    doc.Add(table);
                }


            }            

             doc.Close();*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateEmployeeWorkingHours(object sender, RoutedEventArgs e)
        {
            int s;
            if (!Int32.TryParse(WHStartHour.Text, out s) || !Int32.TryParse(WHStartMinute.Text, out s) || !Int32.TryParse(WHEndHour.Text, out s) || !Int32.TryParse(WHEndMinute.Text, out s))
            {
                System.Windows.MessageBox.Show("Samo brojevi u polja za vreme");
                return;
            }

            int startHour = Int32.Parse(WHStartHour.Text);
            int startMinute = Int32.Parse(WHStartMinute.Text);
            int endHour = Int32.Parse(WHEndHour.Text);
            int endMinute = Int32.Parse(WHEndMinute.Text);

            if (startHour < 0 || startHour > 23 || endHour < 0 || endHour > 23)
            {
                System.Windows.MessageBox.Show("Nevalidna vrednost za sat (0-23)");
                return;
            }

            if (startMinute < 0 || startMinute > 59 || endMinute < 0 || endMinute > 59)
            {
                System.Windows.MessageBox.Show("Nevalidna vrednost za minut (0-59)");
                return;
            }

            EmployeeDTO employee = EmployeeList.SelectedItem as EmployeeDTO;
            App app = App.Current as App;
            DateTime begin = new DateTime(2000, 1, 1, startHour, startMinute, 0);
            DateTime end = new DateTime(2000, 1, 1, endHour, endMinute, 0);
            TimeInterval interval = new TimeInterval(begin, end);
            foreach (SecretaryDTO sec in Secretaries)
            {
                if (employee.Id == sec.Id)
                {
                    sec.WorkingHours = interval;
                    app.SecretaryController.Update(sec);
                    RefreshEmployeeList();
                    return;
                }
            }
            
            foreach (DoctorDTO doc in Doctors)
            {
                if (employee.Id == doc.Id)
                {
                    doc.WorkingHours = interval;
                    app.DoctorController.Update(doc);
                    RefreshEmployeeList();
                    return;
                }
            }
            return; 
        }


        private void ChangeHoliday(object sender, RoutedEventArgs e)
        {
            DateTime Start = HolidayBeginning.SelectedDate.Value.Date;
            DateTime End = HolidayEnd.SelectedDate.Value.Date;
            EmployeeDTO employee = EmployeeList.SelectedItem as EmployeeDTO;
            App app = App.Current as App;
            foreach (SecretaryDTO sec in Secretaries)
            {
                if (employee.Id == sec.Id)
                {
                    sec.AnnualLeave.Start = Start;
                    sec.AnnualLeave.End = End;
                    app.SecretaryController.Update(sec);
                    RefreshEmployeeList();
                    return;
                }
            }
            
            foreach (DoctorDTO doc in Doctors)
            {
                if (employee.Id == doc.Id)
                {
                    doc.AnnualLeave.Start = Start;
                    doc.AnnualLeave.End = End;
                    app.DoctorController.Update(doc);
                    RefreshEmployeeList();
                    return;
                }
            }
            return; 
        }

        private void CloseEmpoyeeProfileChanges(object sender, RoutedEventArgs e)
        {
            foreach (System.Windows.Controls.TextBox textBox in employeeData.Children)
                textBox.IsEnabled = false;
            Save_employee.Visibility = Visibility.Collapsed;
            Change_employee.Visibility = Visibility.Visible;
            EmployeeDTO employee = EmployeeList.SelectedItem as EmployeeDTO;
            App app = App.Current as App;
            foreach (SecretaryDTO sec in Secretaries)
            {
                if (employee.Id == sec.Id)
                {
                    sec.FirstName = employee.FirstName;
                    sec.LastName = employee.LastName;
                    sec.Email = employee.Email;
                    sec.Jmbg = employee.Jmbg;
                    app.SecretaryController.Update(sec);
                    RefreshEmployeeList();
                    return;
                }
            }

            foreach (DoctorDTO doc in Doctors)
            {
                if (employee.Id == doc.Id)
                {
                    doc.FirstName = employee.FirstName;
                    doc.LastName = employee.LastName;
                    doc.Email = employee.Email;
                    doc.Jmbg = employee.Jmbg;
                    app.DoctorController.Update(doc);
                    RefreshEmployeeList();         
                    return;
                }
            }
         
        }

        public void RefreshEmployeeList()
        {
            App app = App.Current as App;
            Employees = new ObservableCollection<EmployeeDTO>();
            Doctors = new ObservableCollection<DoctorDTO>(app.DoctorController.GetAll());
            Secretaries = new ObservableCollection<SecretaryDTO>(app.SecretaryController.GetAll());
            foreach (SecretaryDTO sec in Secretaries)
                Employees.Add(sec as EmployeeDTO);
            foreach (DoctorDTO doc in Doctors)
                Employees.Add(doc as EmployeeDTO);
            EmployeeList.ItemsSource = Employees;
        }

        
    }
}

