using DataBase;
using Employees.ViewModels.Base;
using Models;
using MySqlConnector;
using System.Collections.ObjectModel;

namespace Employees.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        #region fields

        private readonly ConnectionString connectionString;
        public ObservableCollection<Employee> Employees { get; private set; }
        #endregion

        #region commands
        #endregion

        #region constructor

        public EmployeeListViewModel()
        {
            connectionString = new ConnectionString();
            Employees = new ObservableCollection<Employee>();

            getEmployees();
        }
        #endregion

        #region methods
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
