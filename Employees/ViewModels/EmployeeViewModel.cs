using Employees.Services;
using Employees.Services.ChangeContent;
using Employees.ViewModels.Base;
using System;
using System.Windows;

namespace Employees.ViewModels
{
    internal class EmployeeViewModel : BaseViewModel
    {
        #region fields
        private EmployeeListViewModel employeeListViewModel;
        private IChangeContent changeContent;
        #endregion

        #region properties

        private BaseViewModel currentContent;
        public BaseViewModel CurrentContent
        {
            get => currentContent;
            set
            {
                currentContent = value;
                OnPropertyChanged(nameof(CurrentContent));
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
        public EmployeeViewModel(ChangeContent changeContent)
        {
            this.changeContent = changeContent;
            currentContent = new EmployeeListViewModel(changeContent);

            jumpToManageEmployeeView = new RelayCommand(p => changeViewModel(new ManageEmployeeViewModel()));
            jumpToMainView = new RelayCommand(p => changeViewModel(new EmployeeListViewModel(changeContent)));

            employeeListViewModel = new EmployeeListViewModel(changeContent);

            changeContent.OnSelectedEmployee += OnJumpToEmployeeDetailedInformation;



        }
        #endregion

        #region methods
        private void ExecuteLogOut()
        {
            //вызов popup или же можно будет обойтись messagebox
            //проверка результатов выбора
        }
        private void OnJumpToEmployeeDetailedInformation(object sender, CheckEmployeeSelected e)
        {
            if (e.IsSelected)
            {
                CurrentContent = e.ViewModel;
            }
            MessageBox.Show("you're good", "letter for mAn");
        }
        private void changeViewModel(BaseViewModel viewModel)
        {
            CurrentContent = viewModel;
        }
        #endregion

    }
}
