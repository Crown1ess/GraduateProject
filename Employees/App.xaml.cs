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
        private ChangeContent changeContent;
        private MainWindow mainWindow;
        private Main employeeWindow;
        private MainWindowViewModel mainWindowViewModel;
        private AddEmployeeWindow addEmployeeWindow;
        private AddEmployeeWindowViewModel addEmployeeWindowViewModel;

        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            addEmployeeWindowViewModel = new AddEmployeeWindowViewModel();
            addEmployeeWindowViewModel.OnCheckedDriveLicense += EnableDrivingLicenseCombobox;

            mainWindowViewModel = new MainWindowViewModel();  
            mainWindowViewModel.OnAuthorize += LoginViewModelOnOnAuthorize;
            mainWindow = new MainWindow() { DataContext = mainWindowViewModel };
            mainWindow.Show();

            
            

        }

        #region methods
        /// <summary>
        /// method checks user authorized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginViewModelOnOnAuthorize(object sender, LoginEventArgs e)
        {
            changeContent = new ChangeContent();
            if (e.IsAuthorized)
            {
                employeeWindow = new Main() { DataContext = new EmployeeViewModel(changeContent) };
                employeeWindow.Show();
                mainWindow.Close();
                return;
            }
        }
        //не работает
        private void EnableDrivingLicenseCombobox(object sender, CheckEventArgs e)
        {
            addEmployeeWindow = new AddEmployeeWindow();
            if (e.IsChecked)
            {
                addEmployeeWindow.DrivingLicensesComboBox.IsEnabled = true;
                MessageBox.Show("you fucked up, looser", "for looser");
            }
            MessageBox.Show("You are looser", "letter for looser");   
        }

        #endregion
    }
}
