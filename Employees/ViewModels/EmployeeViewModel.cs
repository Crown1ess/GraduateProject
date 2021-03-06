using Employees.Services;
using Employees.ViewModels.Base;
using System.Windows;

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

        #region commands
        private readonly RelayCommand jumpToManageEmployeeView;
        public RelayCommand JumpToManageEmployeeView => jumpToManageEmployeeView;

        private readonly RelayCommand jumpToMainView;
        public RelayCommand JumpToMainView => jumpToMainView;

        private readonly RelayCommand logOut;
        public RelayCommand LogOut => logOut;
        #endregion

        #region constructor
        public EmployeeViewModel()
        {
            currentContent = new EmployeeListViewModel();

            jumpToManageEmployeeView = new RelayCommand(p => changeViewModel(new ManageEmployeeViewModel()));
            jumpToMainView = new RelayCommand(p => changeViewModel(new EmployeeListViewModel()));

            employeeListViewModel = new EmployeeListViewModel();

            //logOut = new RelayCommand(p => changeViewModel(new EmployeeDetailedInformationViewModel()));

            employeeListViewModel.OnOpenDetailedInformation += OnJumpToEmployeeDetailedInformation;

        }
        #endregion

        #region methods
        private void OnJumpToEmployeeDetailedInformation(object sender, CheckEmployeeSelected e)
        {
            if (e.IsSelected)
            {
                //почему-то не работает, надо разобраться с событиями
                MessageBox.Show("you're good", "letter for mAn");
            }
        }
        private void changeViewModel(BaseViewModel viewModel)
        {
            CurrentContent = viewModel;
        }
        #endregion

    }
}
