using DataBase;
using Employees.Services;
using Employees.ViewModels.Base;
using MySqlConnector;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Controls;

namespace Employees.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region fields

        public event EventHandler<LoginEventArgs> OnAuthorize;

        private ConnectionString connectionString;

        #endregion

        #region Converter to unsecure string
        /// <summary>
        /// Convering secure password from password box
        /// to unsecure string
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>

        private string convertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        #endregion

        #region properties
        /// <summary>
        /// phone number property
        /// </summary>
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        #endregion

        #region constructor
        public LoginViewModel()
        {
            openEmployeeWindowCommand = new RelayCommand(Authorize, p => true);
        }
        #endregion

        #region Open manage employee window
        /// <summary>
        /// To open window where we can manage and see more information about employee
        /// </summary>
        /// 
        private readonly RelayCommand openEmployeeWindowCommand;
        public RelayCommand OpenEmployeeWindowCommand => openEmployeeWindowCommand;



        /// <summary>
        /// Checking authorization data
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private void Authorize(object parameter)
        {
            connectionString = new ConnectionString();

            string password = null;
            var passwordContainer = (parameter as PasswordBox).SecurePassword;
            password = passwordContainer != null ? convertToUnsecureString(passwordContainer) : password = null;

            string sqlInquiryString = $"SELECT * FROM users WHERE phone_number = '{PhoneNumber}' AND password = '{password}'";
            using var connection = new MySqlConnection(connectionString.StringOfConnection);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    OnAuthorize?.Invoke(this, new LoginEventArgs(PhoneNumber, true));
                }
                else
                {
                    OnAuthorize?.Invoke(this, new LoginEventArgs(PhoneNumber, false));
                }
            }

        }

        #endregion
    }
}
