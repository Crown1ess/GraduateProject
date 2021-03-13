using DataBase;
using Employees.Services;
using Employees.Services.DialogService;
using Employees.ViewModels.Base;
using Models;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Employees.ViewModels
{
    public class AddEmployeeWindowViewModel : BaseViewModel
    {
        #region fields
        
        IDialogService dialogService;
        IFileService fileService;
        private string imagePath;
        public event EventHandler<CheckEventArgs> OnCheckedDriveLicense;
        private ConnectionString connectionString;
        private string drivingLicense;
        #endregion

        #region properties
        private string lastName;

        public string LastName
        {
            get => lastName;
            set 
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        private string _SNILS;
        public string SNILS
        {
            get => _SNILS;
            set
            {
                _SNILS = value;
                OnPropertyChanged("SNILS");
            }
        }

        private string _INN;
        public string INN
        {
            get => _INN;
            set
            {
                _INN = value;
                OnPropertyChanged("INN");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string address;
        public string Address 
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string passport;
        public string Passport
        {
            get => passport;
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }

        private string gettingPlace;
        public string GettingPlace
        {
            get => gettingPlace;
            set
            {
                gettingPlace = value;
                OnPropertyChanged("GettingPlace");
            }
        }
        
        private DateTime gettingDate = DateTime.Now;
        public DateTime GettingDate 
        {
            get => gettingDate;
            set
            {
                gettingDate = value;
                OnPropertyChanged("GettingDate");
                //if (value <= DateTime.Now)
                //{
                   
                //}
                //else
                //{
                //    //some event
                //}
                
            }
        }
        public ObservableCollection<string> Professions { get; private set; }

        private string selectedProfession;
        public string SelectedProfession
        {
            get => selectedProfession;
            set
            {
                selectedProfession = value;
                OnPropertyChanged("SelectedProfession");
            }
        }
        private DateTime birthDate = DateTime.Now;
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
                //if (value < DateTime.Now)
                //{
                   
                //}
                //else
                //{
                //    //some event
                //}
                
            }
        }
        
        private ObservableCollection<DrivingLicense> drivingLicenses;
        public ObservableCollection<DrivingLicense> DrivingLicenses
        {
            get => drivingLicenses;
            set
            {
                drivingLicenses = value;
                OnPropertyChanged("DrivingLicense");
            }
        }
        private ObservableCollection<string> maritalStatuses;
        public ObservableCollection<string> MaritalStatuses
        {
            get => maritalStatuses;
            set
            {
                maritalStatuses = value;
                OnPropertyChanged("MaritalStatuses");
            }
        }

        private string selectedMaritalStatus;
        public string SelectedMaritalStatus
        {
            get => selectedMaritalStatus;
            set
            {
                selectedMaritalStatus = value;
                OnPropertyChanged("SelectedMaritalStatus");
            }
        }

        private int selectedWorkYearExperience;
        public int SelectedWorkYearExperience
        {
            get => selectedWorkYearExperience;
            set
            {
                selectedWorkYearExperience = value;
                OnPropertyChanged("SelectedWorkYearExperience");
            }
        }

        private int selectedWorkMonthExperience;
        public int SelectedWorkMonthExperience
        {
            get => selectedWorkMonthExperience;
            set
            {
                selectedWorkMonthExperience = value;
                OnPropertyChanged("SelectedWorkMonthExperience");
            }
        }
        public ObservableCollection<int> WorkYears { get; private set; }
        public ObservableCollection<int> WorkMonths { get; private set; }
        #endregion

        #region commands
        private readonly RelayCommand openFileCommand;
        public RelayCommand OpenFileCommand => openFileCommand;

        private readonly RelayCommand radioButtonCommand;
        public RelayCommand RadioButtonCommand => radioButtonCommand;

        private readonly RelayCommand registrateCommand;
        public RelayCommand RegistrateCommand => registrateCommand;

        #endregion

        #region constructor
        public AddEmployeeWindowViewModel()
        {

            openFileCommand = new RelayCommand(c => openFile(), c => true);

            setWorkYears();
            setWorkMonths();

            setProfessions();

            //-------must change 
            MaritalStatuses = new ObservableCollection<string>();
            addMaritalStatuses();

            DrivingLicenses = new ObservableCollection<DrivingLicense>();

            radioButtonCommand = new RelayCommand(radioButtonChosen, p => true);

            registrateCommand = new RelayCommand(p => executeEmployeeRegistration());
        }
        #endregion

        #region methods
        /// <summary>
        /// add marital statuses to combobox for choice
        /// </summary>
        private void addMaritalStatuses()
        {
            if(maritalStatuses.Count < 1)
            {
                maritalStatuses.Add("Не замужем/Не женат");
                maritalStatuses.Add("Разведена/Разведен");
                maritalStatuses.Add("Замужем/Женат");
                maritalStatuses.Add("Гражданский брак");
            }
        }
    
        /// <summary>
        /// add options of driving licenses after chosen "I have driving license" and "I don't have"
        /// </summary>
        /// <param name="parameter"></param>
        private void radioButtonChosen(object parameter)
        {
            if((string)parameter == "DoNotHaveLicense")
            {
                if(drivingLicenses.Count < 1)
                {
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "Нет",
                        IsSelected = false
                    });
                }
                else if(drivingLicenses.Count > 1)
                {
                    drivingLicenses.Clear();

                    drivingLicenses.Add(new DrivingLicense
                    {
                        Text = "Нет",
                        IsSelected = false
                    });
                }
                OnCheckedDriveLicense?.Invoke(this, new CheckEventArgs(true));
            }
            else if((string)parameter == "HaveLicense")
            {
                if (drivingLicenses.Count < 1)
                {
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "B",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "BE",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "C",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "CE",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "D",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "DE",
                        IsSelected = false
                    });
                }
                else if (drivingLicenses.Count == 1)
                {
                    drivingLicenses.Clear();

                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "B",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "BE",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "C",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "CE",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "D",
                        IsSelected = false
                    });
                    DrivingLicenses.Add(new DrivingLicense
                    {
                        Text = "DE",
                        IsSelected = false
                    });
                }

                OnCheckedDriveLicense?.Invoke(this, new CheckEventArgs(true));
            }
        }

        /// <summary>
        /// get open file path for employees' image
        /// </summary>
        private void openFile()
        {
            dialogService = new DefaultDialogService();
            fileService = new StringFileService();

            try
            {
                if (dialogService.OpenFileDialog())
                {
                    imagePath = Path.GetFullPath(fileService.Open(dialogService.FilePath));
                    dialogService.ShowMessage("Image selected");
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
        private void getDrivingLicenses()
        {
            for(int i = 0; i < DrivingLicenses.Count; i++)
            {
                if(DrivingLicenses[i].IsSelected)
                {
                    drivingLicense += DrivingLicenses[i].Text;
                }
            }
        }
        private void setProfessions()
        {
            connectionString = new ConnectionString();

            Professions = new ObservableCollection<string>();

            string sqlInquiryString = "SELECT name FROM professions";

            using (MySqlConnection connection = new MySqlConnection(connectionString.StringOfConnection))
            {
                connection.Open();

                using(MySqlCommand command = new MySqlCommand(sqlInquiryString,connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Professions.Add(reader["name"].ToString());
                        }
                    }
                }
            }
        }
        private void setWorkYears()
        {
            WorkYears = new ObservableCollection<int>();
            for(int i = 1; i <= 100; i++)
            {
                WorkYears.Add(i);
            }
        }
        private void setWorkMonths()
        {
            WorkMonths = new ObservableCollection<int>();

            for(int i = 1; i <= 12; i++)
            {
                WorkMonths.Add(i);
            }
        }
        /// <summary>
        /// insert all data to database
        /// </summary>
        private void executeEmployeeRegistration()
        {
            getDrivingLicenses();

            connectionString = new ConnectionString();

            string sqlInquiryString = "insert_employee_data";
            //string sqlInquiryString = $"INSERT INTO employees VALUES" +
            //    $"({LastName}, {FirstName}, {SecondName}, {PhoneNumber};" +
            //                         $"INSERT INTO employees_detailed_information VALUES" +
            //    $"({INN},{SNILS},{Address},{Passport}, {GettingPlace}, {GettingDate}, {SelectedMaritalStatus}," +
            //    $"{imagePath}, {BirthDate}, {SelectedWorkYearExperience},{SelectedWorkMonthExperience}, {drivingLicense};" ;
            
            using(MySqlConnection connection = new MySqlConnection(connectionString.StringOfConnection))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = LastName;
                command.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = FirstName;
                command.Parameters.Add("@second_name", MySqlDbType.VarChar).Value = SecondName;
                command.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = PhoneNumber;
                command.Parameters.Add("@inn", MySqlDbType.VarChar).Value = INN;
                command.Parameters.Add("@snils", MySqlDbType.VarChar).Value = SNILS;
                command.Parameters.Add("@address", MySqlDbType.VarChar).Value = Address;
                command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = Passport;
                command.Parameters.Add("@getting_place", MySqlDbType.VarChar).Value = GettingPlace;
                command.Parameters.Add("@getting_date", MySqlDbType.Date).Value = GettingDate;
                command.Parameters.Add("@marital_status", MySqlDbType.VarChar).Value = SelectedMaritalStatus;
                command.Parameters.Add("@image_path", MySqlDbType.VarChar).Value = imagePath;
                command.Parameters.Add("@birth_date", MySqlDbType.Date).Value = BirthDate;
                command.Parameters.Add("@work_year_experience", MySqlDbType.Int32).Value = SelectedWorkYearExperience;
                command.Parameters.Add("@work_month_experience", MySqlDbType.Int32).Value = SelectedWorkMonthExperience;
                command.Parameters.Add("@driving_license", MySqlDbType.VarChar).Value = drivingLicense;

                command.ExecuteNonQuery();

                dialogService.ShowMessage("Сотрудник был внесен в базу данных");
                //MessageBox.Show("Data has inserted");
            }
        }
        #endregion
    }
}
