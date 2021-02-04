using Employees.ViewModels.Base;

namespace Employees.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel
    {

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
        //{
        //    get
        //    {
        //        return jumpToManageEmployeeView ??
        //            (jumpToManageEmployeeView = new RelayCommand(p => changeViewMode(new ManageEmployeeViewModel())));
        //    }
        //}

        #endregion

        #region constructor
        public EmployeeViewModel()
        {
            currentContent = new EmployeeListViewModel();

            jumpToManageEmployeeView = new RelayCommand(p => changeViewMode(new ManageEmployeeViewModel()));
            jumpToMainView = new RelayCommand(p => changeViewMode(new EmployeeListViewModel()));
        }
        #endregion

        #region methods
        private void changeViewMode(BaseViewModel viewModel)
        {
            CurrentContent = viewModel;
        }
        #endregion

    }
}
