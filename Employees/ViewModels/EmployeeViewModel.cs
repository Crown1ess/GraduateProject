using Models;
using DataBase;
using MySqlConnector;
using System.Collections.ObjectModel;
using Employees.ViewModels.Base;

namespace Employees.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel
    {

        #region fields
        private readonly ConnectionString connectionString;

        public ObservableCollection<Employee> Employees { get; private set; }
        #endregion

        #region constructor
        public EmployeeViewModel()
        {
            connectionString = new ConnectionString();

            Employees = new ObservableCollection<Employee>();

            getEmployees();
        }
        #endregion

        #region getting employees from db
        /// <summary>
        /// getting employees from db then showing it
        /// </summary>
        private void getEmployees()
        {
            string sqlInquiryString = $"SELECT * FROM employees";
            using var connection = new MySqlConnection(connectionString.StringOfConnection);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);

            using(MySqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Employees.Add(new Employee
                    {
                        LastName = reader["first_name"].ToString(),
                        FirstName = reader["last_name"].ToString(),
                        Patronymic = reader["patronymic"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        PassportData = reader["passport_data"].ToString()
                    });
                }
            }
        }
        #endregion
    }
}
