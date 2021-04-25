using Employees.Services;
using Employees.Services.ChangeContent;
using Employees.ViewModels;
using Employees.Views.Windows;
using System;
using System.Windows;

namespace Employees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region fields
        private EmployeeViewModel employeeViewModel;
        private ChangeContent changeContent;
        private MainWindow mainWindow;
        private Main employeeWindow;
        private MainWindowViewModel mainWindowViewModel;
        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel();  
            mainWindowViewModel.OnAuthorize += LoginViewModelOnOnAuthorize;
            mainWindow = new MainWindow() { DataContext = mainWindowViewModel };
            mainWindow.Show();

            changeContent = new ChangeContent();

        }

        #region methods
        /// <summary>
        /// method checks user authorized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginViewModelOnOnAuthorize(object sender, LoginEventArgs e)
        {
            if(e.IsAuthorized)
            {
                employeeViewModel = new EmployeeViewModel(e.User, changeContent, e.IsAuthorized);
                employeeWindow = new Main()
                {
                    DataContext = employeeViewModel
                };
                employeeViewModel.OnLogOut += LogingOut;
                employeeWindow.Show();
                mainWindow.Close();
                return;
            }
        }

        private void LogingOut(object sender, CheckEventArgs e)
        {
            if(e.IsChecked)
            {
                mainWindow = new MainWindow() { DataContext = mainWindowViewModel };
                mainWindow.Show();
                employeeWindow.Close();
                return;
            }
            
        }
        
        #endregion
    }
}
