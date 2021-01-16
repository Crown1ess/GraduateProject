using Models;
using DataBase;
using MySqlConnector;
using System.Collections.ObjectModel;

namespace Employees
{
    public class EmployeeViewModel : NotifyPropertyChange
    {
        private readonly ConnectionString connectionString;

        public ObservableCollection<Employee> Employees { get; private set; }

        //private RelayCommand logOut;
        //public RelayCommand LogOut
        //{
        //    get
        //    {
        //        return logOut ??
        //            (logOut = new RelayCommand(obj =>
        //            {
        //                DialogResult checkLogOut = System.Windows.Forms.MessageBox.Show("Are you want to exit from your account?", "Exit", MessageBoxButtons.YesNo);
        //                if (checkLogOut == DialogResult.Yes)
        //                {
        //                    //VM не должен запускать окна, это противоречит mvvm
        //                }
        //            }));

        //    }
        //}

        public EmployeeViewModel()
        {
            connectionString = new ConnectionString();

            Employees = new ObservableCollection<Employee>();

            getEmployees();
            

        }
         
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
    }
}
