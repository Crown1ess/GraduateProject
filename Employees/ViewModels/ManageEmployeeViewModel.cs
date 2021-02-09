using Employees.ViewModels.Base;

namespace Employees.ViewModels
{
    public class ManageEmployeeViewModel : BaseViewModel
    {
        #region commands
        private readonly RelayCommand addNewEmployeeCommand;
        public RelayCommand AddNewEmployeeCommand => addNewEmployeeCommand;
        #endregion

        #region constructor
        public ManageEmployeeViewModel()
        {
            
        }
        #endregion
    }
}
