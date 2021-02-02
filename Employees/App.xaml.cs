using Employees.Services;
using Employees.ViewModels;
using System.Windows;

namespace Employees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region fields

        private MainWindow mainWindow { get; set; }
        private Main employeeWindow { get; set; }
        private MainWindowViewModel mainWindowViewModel { get; set; }

        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

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
            if (e.IsAuthorized)
            {
                employeeWindow = new Main() { DataContext = new EmployeeViewModel() };
                employeeWindow.Show();
                mainWindow.Close();
                return;
            }
        }
        #endregion
    }
}
