using System.Configuration;
using Project.Repositories;
using System.Windows;
using Project.Repositories.CSV.Converter;
using Project.Repositories.CSV.Stream;
using Project.Model;
using Project.Repositories.Sequencer;
using Project.Services;
using Project.Controllers;
using Project.Views.Model;
using Controller;
using Project.Views.Converters;
using iTextSharp.text;
using System.Collections.Generic;
using Project.Views.Secretary;
using System.Xml.Schema;
using System;
using System.ComponentModel;
using Project.Services.Generators;
using Project.Repositories.ManyToMany.Repositories;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.ManyToMany.Converter;
//using Syncfusion.Windows.Shared;
using Project.Repositories.CSV;
using Project.Controllers.Abstract;
using Project.Repositories.Referral;
using Project.Model.Referrals;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {


        // HCI
        public ResourceDictionary ThemeDictionary
        {
            get { return Resources.MergedDictionaries[0]; }
        }

        public ResourceDictionary LanguageDictionary
        {
            get { return Resources.MergedDictionaries[1]; }
        }

        public void ChangeLanguage(Uri uri)
        {
            LanguageDictionary.MergedDictionaries.Clear();
            LanguageDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public void ChangeTheme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public void AddTheme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }


        public List<DoctorDTO> doctors { get; set; }
        public List<QuestionDTO> questions { get; set; }
        public List<PatientDTO> patients { get; set; }
        public List<DirectorDTO> directors { get; set; }
        public DirectorDTO director { get; set; }
        public List<SecretaryDTO> secretaries { get; set; }
        public List<EmployeeDTO> employees { get; set; }
        public List<RoomDTO> rooms { get; set; }
        private DoctorDTO selectedDoctor;
        public DoctorDTO SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                if (value != selectedDoctor)
                {
                    selectedDoctor = value;
                    OnPropertyChanged("SelectedDoctor");
                }
            }
        }
        private PatientDTO selectedPatient;
        public PatientDTO SelectedPatient
        {
            get
            {
                return selectedPatient;
            }
            set
            {
                if (value != selectedPatient)
                {
                    selectedPatient = value;
                    OnPropertyChanged("SelectedPatient");
                }
            }
        }
        private List<MedicalAppointmentDTO> medicalAppointments;
        public List<MedicalAppointmentDTO> MedicalAppointments
        {
            get
            {
                return medicalAppointments;
            }
            set
            {
                if (value != medicalAppointments)
                {
                    medicalAppointments = value;
                    OnPropertyChanged("MedicalAppointments");
                }
            }
        }
        private MedicalAppointmentDTO selectedAppointment;
        public MedicalAppointmentDTO SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                if (value != selectedAppointment)
                {
                    selectedAppointment = value;
                    OnPropertyChanged("SelectedAppointment");
                }
            }
        }
        public SecretaryDTO currentSecretary { get; set; }
        public UserDTO currentUser { get; set; }
        public List<string> medicalRoles { get; set; }
        public List<string> roomTypes { get; set; }
        public List<string> medicalAppointmentTypes { get; set; }
        public DateTime SelectedDate { get; set; }

        // Paths
        private static string PATIENT_FILEPATH = ConfigurationManager.AppSettings["PatientPath"].ToString();
        private static string ADDRESS_FILEPATH = ConfigurationManager.AppSettings["AddressPath"].ToString();
        private static string QUESTION_FILEPATH = ConfigurationManager.AppSettings["QuestionPath"].ToString();
        private static string MEDICINE_FILEPATH = ConfigurationManager.AppSettings["MedicinePath"].ToString();
        private static string PRESCRIPTION_FILEPATH = ConfigurationManager.AppSettings["PrescriptionPath"].ToString();
        private static string MEDICAL_CONSUMABLE_FILEPATH = ConfigurationManager.AppSettings["MedicalConsumablesPath"].ToString();
        private static string EQUIPMENT_FILEPATH = ConfigurationManager.AppSettings["EquipmentPath"].ToString();
        private static string ORDER_FILEPATH = ConfigurationManager.AppSettings["OrderPath"].ToString();
        private static string ORDER_DETAILS_FILEPATH = ConfigurationManager.AppSettings["OrderDetailsPath"].ToString();
        private static string MEDICAL_APPOINTMENT_FILEPATH = ConfigurationManager.AppSettings["MedicalAppointmentPath"].ToString();
        private static string ROOM_FILEPATH = ConfigurationManager.AppSettings["RoomPath"].ToString();
        private static string RENOVATION_FILEPATH = ConfigurationManager.AppSettings["RenovationPath"].ToString();
        private static string FEEDBACK_FILEPATH = ConfigurationManager.AppSettings["FeedbackPath"].ToString();
        private static string REVIEW_FILEPATH = ConfigurationManager.AppSettings["ReviewPath"].ToString();
        private static string ANAMNESIS_FILEPATH = ConfigurationManager.AppSettings["AnamnesisPath"].ToString();
        private static string SECRETARY_FILEPATH = ConfigurationManager.AppSettings["SecretaryPath"].ToString();
        private static string INVENTORY_FILEPATH = ConfigurationManager.AppSettings["InventoryPath"].ToString();
        private static string INVENTORY_EQUIPMENT_FILEPATH = ConfigurationManager.AppSettings["InventoryEquipmentPath"].ToString();
        private static string DOCTOR_FILEPATH = ConfigurationManager.AppSettings["DoctorPath"].ToString();
        private static string PROPOSITION_FILEPATH = ConfigurationManager.AppSettings["PropositionPath"].ToString();
        private static string APPROVAL_FILEPATH = ConfigurationManager.AppSettings["ApprovalPath"].ToString();
        // Referrals
        private static string ADMITION_REFERRAL_FILEPATH = ConfigurationManager.AppSettings["AdmitionReferralPath"].ToString();
        private static string OPERATION_REFERRAL_FILEPATH = ConfigurationManager.AppSettings["OperationReferralPath"].ToString();
        private static string EXAM_REFERRAL_FILEPATH = ConfigurationManager.AppSettings["ExamReferralPath"].ToString();

        // Many to many
        private static string MEDICAL_APPOINTMENT_TO_DOCTOR_FILEPATH = ConfigurationManager.AppSettings["MedicalAppointmentToDoctorPath"].ToString();

        // Report paths
        private static string REPORT_ROOM_FILEPATH = ConfigurationManager.AppSettings["ReportRoomPath"].ToString();
        private static string REPORT_APPOINTMENT_FILEPATH = ConfigurationManager.AppSettings["ReportAppointmentPath"].ToString();
        private static string REPORT_PRESCRIPTION_FILEPATH = ConfigurationManager.AppSettings["ReportPrescriptionPath"].ToString();
        private static string REPORT_DOCTOR_APPOINTMENTS_FILEPATH = ConfigurationManager.AppSettings["DoctorsAppointmentsPath"].ToString();
        private static string REPORT_MEDICINE_FILEPATH = ConfigurationManager.AppSettings["ReportMedicinePath"].ToString();
        

        // Constants
        private static string DELIMITER = ConfigurationManager.AppSettings["DelimiterValue"].ToString();
        private static string DATETIME_FORMAT = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();
        private static string DATETIME_DETAIL_FORMAT = ConfigurationManager.AppSettings["DateTimeDetailFormat"].ToString();
        private static string TIME_FORMAT = ConfigurationManager.AppSettings["TimeFormat"].ToString();
        private static string APPOINTMENT_LENGTH_IN_MINUTES = ConfigurationManager.AppSettings["AppointmentLengthInMinutes"].ToString();
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        // public PatientDTO a;
        // public DoctorDTO b;
        // public SecretaryDTO c;

        public App()
        {

            // HCI

            medicalRoles = new List<string> { "Svi", "Opšte Prakse", "Hirurg", "Dermatolog", "Očni lekar", "Stomatolog" };
            roomTypes = new List<string> { "Bolnička Soba", "Operaciona Sala", "Soba za preglede" };
            medicalAppointmentTypes = new List<string> { "Pregled", "Operacija", "Ležanje" };
            AddressDTO address = new AddressDTO("1", "Bulevar despota Stefan 7A", "Novi Sad", "Srbija", "21000");

            director = new DirectorDTO(address, "Dusan", "Urosevic", "1231231231231", "021021", "Male", new DateTime(1990, 5, 5), 123, new TimeInterval(new DateTime(2020, 12, 12), new DateTime(2020, 12, 12)), new TimeInterval(new DateTime(2020, 12, 12), new DateTime(2020, 12, 12)), "d@g.c", "pass","Klinicki Centar Vojvodina");
            SelectedDate = DateTime.Now;


            // Converters
            var addressConverter = new AddressConverter();
            var patientConverter = new PatientConverter(addressConverter);
            var medicineConverter = new MedicineConverter();
            var questionConverter = new QuestionConverter(patientConverter);
            var prescriptionConverter = new PrescriptionConverter(patientConverter, medicineConverter);
            var medicalConsumableConverter = new MedicalConsumableConverter();
            var roomConverter = new RoomConverter();
            var equipmentConverter = new EquipmentConverter(roomConverter);
            var guestConverter = new GuestConverter(addressConverter);
            var hospitalConverter = new HospitalConverter();
            var doctorConverter = new DoctorConverter(addressConverter);
            var medicalAppointmentConverter = new MedicalAppointmentConverter(roomConverter, guestConverter, doctorConverter);
            var renovationConverter = new RenovationConverter(roomConverter);
            var feedbackConverter = new FeedbackConverter();
            var reviewConverter = new ReviewConverter(doctorConverter);
            var anamnesisConvertor = new AnamnesisConvertor();
            var secretaryConverter = new SecretaryConverter(questionConverter, addressConverter);
            var inventoryManagementConverter = new InventoryManagementConverter(equipmentConverter, roomConverter);
            var orderConverter = new OrderConverter(medicalConsumableConverter, medicineConverter, equipmentConverter);
            var reportConverter = new ReportConverter();
            var approvalConverter = new ApprovalConverter(doctorConverter);
            var propositionConverter = new PropositionConverter(medicineConverter, approvalConverter, doctorConverter);


            var referralConverter = new ReferralConverter(medicalAppointmentConverter);


            // Repositories
            // Many to Many
            var medicalAppointmentToDoctorRepository = new MedicalAppointmentToDoctorRepository(
                new CSVStream<MedicalAppointmentToDoctor>(
                    MEDICAL_APPOINTMENT_TO_DOCTOR_FILEPATH,
                    new MedicalAppointmentToDoctorCSVConverter(DELIMITER)),
                new LongSequencer()
            );
            var inventoryManagementToEquipmentRepository = new InventoryManagementToEquipmentRepository(
                new CSVStream<InventoryManagementToEquipment>(
                    INVENTORY_EQUIPMENT_FILEPATH,
                    new InventoryManagementToEquipmentCSVConverter(DELIMITER)),
                new LongSequencer()
            );

            var addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILEPATH, new AddressCSVConverter(DELIMITER)), new LongSequencer());
            var patientRepository = new PatientRepository(
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT,TIME_FORMAT)),
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                addressRepository, new LongSequencer());
            var doctorRepository = new DoctorRepository(
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                addressRepository,
                new LongSequencer());
            var secretaryRepository = new SecretaryRepository(
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT, TIME_FORMAT)),
                addressRepository,
                new LongSequencer());


            var inventoryManagementRepository = new InventoryManagementRepository(new CSVStream<InventoryManagement>(INVENTORY_FILEPATH, new InventoryManagementCSVConverter(DELIMITER, DATETIME_FORMAT)), inventoryManagementToEquipmentRepository, new LongSequencer());
            var orderDetailsRepository = new OrderDetailsRepository(new CSVStream<OrderDetails>(ORDER_DETAILS_FILEPATH, new OrderDetailsCSVConverter(DELIMITER)), new LongSequencer());
            var questionRepository = new QuestionRepository(new CSVStream<Question>(QUESTION_FILEPATH, new QuestionCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());


            var medicalConsumableRepository = new MedicalConsumableRepository(
                new CSVStream<MedicalConsumables>(MEDICAL_CONSUMABLE_FILEPATH, new MedicalConsumableCSVConverter(DELIMITER)), 
                new CSVStream<Equipment>(EQUIPMENT_FILEPATH, new EquipmentCSVConverter(DELIMITER)), 
                new CSVStream<MedicalConsumables>(MEDICAL_CONSUMABLE_FILEPATH, new MedicalConsumableCSVConverter(DELIMITER)), 
                new CSVStream<Medicine>(MEDICINE_FILEPATH, new MedicineCSVConverter(DELIMITER)), 
                new LongSequencer());

            var equipmentRepository = new EquipmentRepository(
                new CSVStream<Equipment>(EQUIPMENT_FILEPATH, new EquipmentCSVConverter(DELIMITER)), 
                new CSVStream<Equipment>(EQUIPMENT_FILEPATH, new EquipmentCSVConverter(DELIMITER)), 
                new CSVStream<MedicalConsumables>(MEDICAL_CONSUMABLE_FILEPATH, new MedicalConsumableCSVConverter(DELIMITER)), 
                new CSVStream<Medicine>(MEDICINE_FILEPATH, new MedicineCSVConverter(DELIMITER)), 
                new LongSequencer());
            var medicineRepository = new MedicineRepository(
                new CSVStream<Medicine>(MEDICINE_FILEPATH, new MedicineCSVConverter(DELIMITER)), 
                new CSVStream<Equipment>(EQUIPMENT_FILEPATH, new EquipmentCSVConverter(DELIMITER)), 
                new CSVStream<MedicalConsumables>(MEDICAL_CONSUMABLE_FILEPATH, new MedicalConsumableCSVConverter(DELIMITER)), 
                new CSVStream<Medicine>(MEDICINE_FILEPATH, new MedicineCSVConverter(DELIMITER)), 
                new LongSequencer());

            var prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILEPATH, new PrescriptionCSVConverter(DELIMITER, DATETIME_FORMAT)), medicineRepository, patientRepository, new LongSequencer());


            var medicalAppointmentRepository = new MedicalAppointmentRepository(
                new CSVStream<MedicalAppointment>(MEDICAL_APPOINTMENT_FILEPATH,
                new MedicalAppointmentCSVConverter(DELIMITER, DATETIME_DETAIL_FORMAT)),
                medicalAppointmentToDoctorRepository,
                patientRepository,
                doctorRepository,
                new LongSequencer());
            var roomRepository = new RoomRepository(new CSVStream<Room>(ROOM_FILEPATH, new RoomCSVConverter(DELIMITER)), new LongSequencer(), equipmentRepository);

            var orderRepository = new OrderRepository(new CSVStream<Order>(ORDER_FILEPATH, new OrderCSVConverter(DELIMITER, DATETIME_FORMAT)), medicineRepository, equipmentRepository, medicalConsumableRepository, orderDetailsRepository, new LongSequencer());

            var renovationRepository = new RenovationRepository(new CSVStream<Renovation>(RENOVATION_FILEPATH, new RenovationCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var feedbackRepository = new FeedbackRepository(new CSVStream<Feedback>(FEEDBACK_FILEPATH, new FeedbackCSVConverter(DELIMITER)), new LongSequencer());
            var reviewRepository = new ReviewRepository(new CSVStream<Review>(REVIEW_FILEPATH, new ReviewCSVConverter(DELIMITER)), new LongSequencer());
            var anamnesisRepository = new AnamnesisRepository(new CSVStream<Anamnesis>(ANAMNESIS_FILEPATH, new AnamnesisCSVConverter(DELIMITER)), new LongSequencer());
            var propositionRepository = new PropositionRepository(new CSVStream<Proposition>(PROPOSITION_FILEPATH, new PropositionCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer(),medicineRepository);

            // Referral
            var admitionReferralRepository = new AdmitionReferralRepository(
               new CSVStream<Referral>(ADMITION_REFERRAL_FILEPATH, new ReferralCSVConventer(DELIMITER, DATETIME_FORMAT)), 
               new LongSequencer()
            );
            var operationReferralRepository = new OperationReferralRepository(
               new CSVStream<Referral>(OPERATION_REFERRAL_FILEPATH, new ReferralCSVConventer(DELIMITER, DATETIME_FORMAT)),
               new LongSequencer());

            var examReferralRepository = new ExamReferralRepository(
               new CSVStream<Referral>(EXAM_REFERRAL_FILEPATH, new ReferralCSVConventer(DELIMITER, DATETIME_FORMAT)),
               new LongSequencer());

            var approvalRepository = new ApprovalRepository(new CSVStream<Approval>(APPROVAL_FILEPATH, new ApprovalCSVConverter(DELIMITER)), new LongSequencer());

            // Services
            
            var patientService = new PatientService(patientRepository);
            var questionService = new QuestionService(questionRepository);
            var addressService = new AddressService(addressRepository);
            var medicineService = new MedicineService(medicineRepository);
            var medicalConsumableService = new MedicalConsumableService(medicalConsumableRepository);
            var prescriptionService = new PrescriptionService(prescriptionRepository, medicineService, patientService);
            var reportService = new ReportService();
            var guestService = new GuestService(patientRepository);
            var equipmentService = new EquipmentService(equipmentRepository);
            var doctorService = new DoctorService(doctorRepository);
            var medicalAppointmentService = new MedicalAppointmentService(medicalAppointmentRepository, doctorService);
            var roomService = new RoomService(roomRepository);
            var renovationService = new RenovationService(renovationRepository,roomRepository);
            var feedbackService = new FeedbackService(feedbackRepository);
            var reviewService = new ReviewService(reviewRepository);
            var employeeService = new EmployeeService(secretaryRepository, doctorRepository);
            var authenticationService = new AuthenticationService(employeeService, patientService);
            var secretaryService = new SecretaryService(secretaryRepository);
            var inventoryManagementService = new InventoryManagementService(inventoryManagementRepository);
            var orderService = new OrderService(orderRepository);
            var anamnesisService = new AnamnesisService(anamnesisRepository);
            var propositionService = new PropositionService(propositionRepository);
            var approvalService = new ApprovalService(approvalRepository);

            // Controllers
            PatientController = new PatientController(patientService, patientConverter, guestConverter);
            GuestController = new GuestController(guestService, guestConverter);
            AddressController = new AddressController(addressService, addressConverter);
            MedicineController = new MedicineController(medicineService, medicineConverter);
            QuestionController = new QuestionController(questionService, questionConverter, patientConverter);
            MedicalConsumableController = new MedicalConsumableController(medicalConsumableService, medicalConsumableConverter);
            AuthenticationController = new AuthenticationController();
            ReportController = new ReportController(reportConverter);
            PrescriptionController = new PrescriptionController(prescriptionService, prescriptionConverter);
            EquipmentController = new EquipmentController(equipmentService, equipmentConverter);

            MedicalAppointmentController = new MedicalAppointmentController(
                medicalAppointmentService, 
                medicalAppointmentConverter,
                doctorConverter,
                roomConverter
            );

            RoomController = new RoomController(roomService, roomConverter);
            RenovationController = new RenovationController(renovationService, renovationConverter);
            FeedbackController = new FeedbackController(feedbackService, feedbackConverter);
            ReviewController = new ReviewController(reviewService, reviewConverter);
            SecretaryController = new SecretaryController(secretaryService, secretaryConverter);
            InventoryManagementController = new InventoryManagementController(inventoryManagementService, inventoryManagementConverter);
            OrderController = new OrderController(orderService, orderConverter);
            DoctorController = new DoctorController(doctorService, doctorConverter);
            AnamnesisController = new AnamnesisController(anamnesisService, anamnesisConvertor);
            PropositionController = new PropositionController(propositionService, propositionConverter);

            // Generators
            SecretaryAppointmentReportGenerator = new SecretaryAppointmentReportGenerator(REPORT_APPOINTMENT_FILEPATH);
            PatientAppointmentReportGenerator = new PatientAppointmentReportGenerator(REPORT_APPOINTMENT_FILEPATH);
            PrescriptionReportGenerator = new PrescriptionReportGenerator(REPORT_PRESCRIPTION_FILEPATH);
            DoctorsAppointmentReport = new DirectorReportGenerator(REPORT_DOCTOR_APPOINTMENTS_FILEPATH,doctorRepository,medicalAppointmentRepository);
            MedicineReportGenerator = new MedicineReportGenerator(REPORT_MEDICINE_FILEPATH,medicineRepository);


            Synchronise(RenovationController);
        }

        // Generators
        public IReportGenerator<TimeInterval> SecretaryAppointmentReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> PatientAppointmentReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> PrescriptionReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> DoctorsAppointmentReport { get; private set; }
        public IReportGenerator<TimeInterval> MedicineReportGenerator { get; private set; }

        // Users
        public IDoctorController DoctorController { get; private set; }
        public IPatientController PatientController { get; private set; }
        public ISecretaryController SecretaryController { get; private set; }


        // Controllers
        public AuthenticationController AuthenticationController { get; private set; }
        public ReportController ReportController { get; private set; }
        public IController<AddressDTO, long> AddressController { get; private set; }
        public IController<MedicineDTO, long> MedicineController { get; private set; }
        public IController<MedicalConsumableDTO, long> MedicalConsumableController { get; private set; }

        public IController<EquipmentDTO, long> EquipmentController { get; private set; }
        public IController<RoomDTO, long> RoomController { get; private set; }
        public RenovationController RenovationController { get; private set; }
        public IController<InventoryManagementDTO, long> InventoryManagementController { get; private set; }
        public IController<OrderDTO, long> OrderController { get; private set; }
        public IController<GuestDTO, long> GuestController { get; private set; }


        public MedicalAppointmentController MedicalAppointmentController { get; private set; }

        public IController<QuestionDTO, long> QuestionController { get; private set; }
        public IController<FeedbackDTO, long> FeedbackController { get; private set; }

        public IController<ReviewDTO, long> ReviewController { get; private set; }
        public IController<PrescriptionDTO, long> PrescriptionController { get; private set; }
        public IController<ApprovalDTO, long> ApprovalController { get; set; }

        public IController<AnamnesisDTO, long> AnamnesisController { get; set; }
    
        public IController<PropositionDTO, long> PropositionController { get; set; }

        private void Synchronise(RenovationController renovationController)
        {
            List<RenovationDTO> renovations= (List<RenovationDTO>)renovationController.GetAll();
            DateTime currentTime = DateTime.Now;
            DateTime currentDate = new DateTime(currentTime.Year, currentTime.Month,currentTime.Day);
           
            foreach (RenovationDTO ren in renovations)
                if (DateTime.Compare(currentDate, ren.Beginning) >= 0)
                   renovationController.RealiseRenovation(ren);
        }
    }
}
