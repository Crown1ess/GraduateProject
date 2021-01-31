using System;
using Models;
using DataBase;
using MySqlConnector;
using System.Windows.Controls;
using Employees.ViewModels.Base;

namespace Employees.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region fields
        public LoginViewModel LoginViewModel { get; private set; }

        #endregion

        #region properties

        private BaseViewModel currentContent;

        public BaseViewModel CurrentContent
        {
            get => currentContent;
            set 
            {
                currentContent = value;
                OnPropertyChanged("CurrentContent");
            }
        }

        #endregion

        #region Constructor
        public MainWindowViewModel(LoginViewModel loginViewModel)
        {
            this.LoginViewModel = loginViewModel;
            CurrentContent = LoginViewModel;  
        }
        
        #endregion
    }
}
