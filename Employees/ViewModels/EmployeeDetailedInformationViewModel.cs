using Employees.ViewModels.Base;
using Models;
using MySqlConnector;
using DataBase;
using System.Collections.ObjectModel;
using System;

namespace Employees.ViewModels
{
    public class EmployeeDetailedInformationViewModel : BaseViewModel
    {
        #region fields
        private int selectedEmployee;
        private ConnectionString connectionString;
        #endregion

        #region properties

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(secondName));
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string passport;
        public string Passport
        {
            get => passport;
            set
            {
                passport = value;
                OnPropertyChanged(nameof(Passport));
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        private string month;
        public string Month
        {
            get => month;
            set
            {
                month = value;
                OnPropertyChanged(nameof(month));
            }
        }

        private string profession;
        public string Profession 
        {
            get => profession;
            set
            {
                profession = value;
                OnPropertyChanged(nameof(Profession));
            }
        }

        private int businessTravelDays;
        public int BusinessTravelDays 
        {
            get => businessTravelDays;
            set
            {
                businessTravelDays = value;
                OnPropertyChanged(nameof(BusinessTravelDays));
            }
        }

        private int workingHours;
        public int WorkingHours
        {
            get => workingHours;
            set
            {
                workingHours = value;
                OnPropertyChanged(nameof(WorkingHours));
            }
        }

        private int sickLeave;
        public int SickLeave
        {
            get => sickLeave;
            set
            {
                sickLeave = value;
                OnPropertyChanged(nameof(SickLeave));
            }
        }

        private int vacationLeave;
        public int VacationLeave
        {
            get => vacationLeave;
            set
            {
                vacationLeave = value;
                OnPropertyChanged(nameof(vacationLeave));
            }
        }

        private ObservableCollection<EmployeeSchedule> employeeSchedules;
        public ObservableCollection<EmployeeSchedule> EmployeeSchedules
        {
            get => employeeSchedules;
            set
            {
                employeeSchedules = value;
                OnPropertyChanged(nameof(EmployeeSchedules));
            }
        }
        #endregion

        #region constructor
        public EmployeeDetailedInformationViewModel(int selectedEmployee)
        {
            this.selectedEmployee = selectedEmployee;

            gettingEmployeeInformation();

            fillSchedule();

            //Days = new List<int>(Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToList());

            Month = DateTime.Now.ToString("MMM");
        }
        #endregion

        #region methods
        private void fillSchedule()
        {
            EmployeeSchedules = new ObservableCollection<EmployeeSchedule>();

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                EmployeeSchedules.Add(new EmployeeSchedule
                {
                    Days = i,
                    ActionOnDay = i.ToString()
                });
            }
        }

        private void gettingEmployeeInformation()
        {
            connectionString = new ConnectionString();

            string sqlInquiryString = "get_employee_information";
            using (MySqlConnection connection = new MySqlConnection(connectionString.StringOfConnection))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = selectedEmployee;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LastName = reader["last_name"].ToString();
                        FirstName = reader["first_name"].ToString();
                        SecondName = reader["patronymic"].ToString();
                        PhoneNumber = reader["phone_number"].ToString();
                        Passport = reader["passport"].ToString();
                        ImagePath = reader["image_path"].ToString();
                        Profession = reader["name"].ToString();
                        BusinessTravelDays = (int)reader["business_travel_days"];
                        WorkingHours = (int)reader["working_hours"];
                        SickLeave = (int)reader["sick_leave"];
                        VacationLeave = (int)reader["vacation_leave"];
                    }
                }
            }
        }
        #endregion
    }
}
