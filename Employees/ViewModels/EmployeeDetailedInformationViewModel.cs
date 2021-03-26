using Employees.Services;
using Employees.ViewModels.Base;
using Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DataBase;
using System.Windows;

namespace Employees.ViewModels
{
    public class EmployeeDetailedInformationViewModel : BaseViewModel
    {
        #region fields
        private int selectedEmployee;
        private ConnectionString connectionString;
        #endregion

        #region properties

        //private ObservableCollection<Employee> employees;
        //public ObservableCollection<Employee> Employees
        //{
        //    get => employees;
        //    set
        //    {
        //        employees = value;
        //        OnPropertyChanged(nameof(Employees));
        //    }
        //}
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
        #endregion

        #region constructor
        public EmployeeDetailedInformationViewModel(int selectedEmployee)
        {
            this.selectedEmployee = selectedEmployee;
            MessageBox.Show(selectedEmployee.ToString());

            gettingEmployeeInformation();
            //создаем метод для выборки данных о работнике из базы данных и сравнивая его с
        }
        #endregion

        #region methods
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
                        
                    }
                }
            }
        }
        #endregion
    }
}
