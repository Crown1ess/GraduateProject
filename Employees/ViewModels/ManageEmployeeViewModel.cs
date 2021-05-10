﻿using Employees.ViewModels.Base;
using System.Windows.Input;
using DataBase;
using MySqlConnector;
using Employees.Services.DialogService;

namespace Employees.ViewModels
{
    public class ManageEmployeeViewModel : BaseViewModel
    {
        #region fields
        private ConnectionString connectionString;
        private DefaultDialogService dialogService;
        #endregion

        #region properties

        private string fullName;
        public string FullName
        {
            get => fullName;
            set
            {
                if (!value.Equals(string.Empty))
                    fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                if (value != null)
                    imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
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

        private string workingHours;
        public string WorkingHours
        {
            get => workingHours;
            set
            {
                workingHours = value + " часов";
                OnPropertyChanged(nameof(workingHours));
            }
        }
        #endregion

        #region commands

        private readonly ICommand aboutCommand;
        public ICommand AboutCommand => aboutCommand;

        #endregion

        #region constructor
        public ManageEmployeeViewModel(object user)
        {
            aboutCommand = new RelayCommand(p => showAboutInformation());
            getUserInformation(user);
            dialogService = new DefaultDialogService();
        }

        #endregion

        #region methods
        
        
        /// <summary>
        /// getting user information for application settings.
        /// </summary>
        /// <param name="user"></param>
        private void getUserInformation(object user)
        {
            connectionString = new ConnectionString();
            

            using (MySqlConnection connection = new MySqlConnection(connectionString.StringOfConnection))
            {
                connection.Open();
                string sqlInquiryString = "get_user";

                MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = (string)user;

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        this.FullName = reader["last_name"].ToString() + " " 
                            + reader["first_name"].ToString() + " " 
                            + reader["patronymic"].ToString();

                        this.ImagePath = reader["image_path"].ToString();
                        this.PhoneNumber = reader["phone_number"].ToString();
                        this.Profession = reader["name"].ToString();
                        this.WorkingHours = reader["working_hours"].ToString();
                    }
                }
            }
        }
        private void showAboutInformation()
        {
            dialogService.ShowMessage("This is Johny!!!", "About");
        }

        #endregion
    }
}
