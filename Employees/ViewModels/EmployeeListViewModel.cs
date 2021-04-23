using DataBase;
using Employees.Services.ChangeContent;
using Employees.ViewModels.Base;
using Models;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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
                selectedEmployee = value + 1;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        #endregion

        #region commands

        private readonly RelayCommand openEmployeeDetailedInformation;
        public RelayCommand OpenEmployeeDetailedInformation => openEmployeeDetailedInformation;

        private readonly ICommand removeEmployeeCommand;
        public ICommand RemoveEmployeeCommand => removeEmployeeCommand;

        #endregion

        #region constructor

        public EmployeeListViewModel(ChangeContent changeContent)
        {
            connectionString = new ConnectionString();

            Employees = new ObservableCollection<Employee>();

            getEmployees();

            this.changeContent = changeContent;

            openEmployeeDetailedInformation = new RelayCommand(OnOpenEmployeeDetailedInformation, p => true);

            removeEmployeeCommand = new RelayCommand(p=>removeEmployee());
        }
        #endregion

        #region methods

        /// <summary>
        /// remove employee data after fired
        /// </summary>
        private void removeEmployee()
        {
            var removeChoice = MessageBox.Show("Вы точно хотите удалить данные", "Предупреждение", MessageBoxButton.YesNo);

            if(removeChoice == MessageBoxResult.Yes)
            {
               
                string sqlInquiryString = "remove_employee";

                using (MySqlConnection connection = new MySqlConnection(connectionString.StringOfConnection))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = SelectedEmployee;
                    
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            if((bool)reader[0])
                                MessageBox.Show("Данные о сотруднике были удалены!", "Уведомление");
                            else
                                MessageBox.Show("Невозможно удалить данные о директоре!", "Ошибка");
                        }

                    }
                }   
            }
        }

        private void OnOpenEmployeeDetailedInformation(object parameter)
        {
            changeContent.ChangeViewModel(new EmployeeDetailedInformationViewModel(SelectedEmployee + 1));
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
