using DataBase;
using Employees.Services;
using Employees.Services.ChangeContent;
using Employees.ViewModels.Base;
using Models;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;

namespace Employees.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        #region fields
        private IChangeContent changeContent;
        private readonly ConnectionString connectionString;
        public ObservableCollection<Employee> Employees { get; private set; }
        #endregion

        #region properties
        private int selectedEmployee;
        public int SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }
        #endregion

        #region commands

        private readonly RelayCommand openEmployeeDetailedInformation;
        public RelayCommand OpenEmployeeDetailedInformation => openEmployeeDetailedInformation;
        #endregion

        #region constructor

        public EmployeeListViewModel(ChangeContent changeContent)
        {
            connectionString = new ConnectionString();

            Employees = new ObservableCollection<Employee>();

            getEmployees();

            this.changeContent = changeContent;


            openEmployeeDetailedInformation = new RelayCommand(OnOpenEmployeeDetailedInformation, p => true);  
        }
        #endregion

        #region methods
        private void OnOpenEmployeeDetailedInformation(object parameter)
        {
            changeContent.ChangeViewModel(new EmployeeDetailedInformationViewModel(), SelectedEmployee);
        }

        /// <summary>
        /// getting employees from db then showing it
        /// </summary>
        private void getEmployees()
        {
            string sqlInquiryString = "get_employees_main_information";
            using (MySqlConnection connection = new MySqlConnection(connectionString.StringOfConnection))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
 
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees.Add(new Employee
                        {
                            LastName = reader["last_name"].ToString(),
                            FirstName = reader["first_name"].ToString(),
                            Patronymic = reader["patronymic"].ToString(),
                            PhoneNumber = reader["phone_number"].ToString(),
                            PassportData = reader["passport"].ToString(),
                            ImagePath = reader["image_path"].ToString()
                        });
                    }
                }
            }
            
        }
        #endregion
    }
}
