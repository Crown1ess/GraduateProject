using Employees.ViewModels.Base;

namespace Employees.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel
    {
        #region fields

        private EmployeeListViewModel employeeListViewModel;
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

        #region constructor
        public EmployeeViewModel()
        {
            employeeListViewModel = new EmployeeListViewModel();
            currentContent = employeeListViewModel;
        }
        #endregion

    }
}
