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
        public event EventHandler<CheckEventArgs> OnLogOut;
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

        public EmployeeViewModel(object user, ChangeContent changeContent, bool isAuthorized)
        {
            
            jumpToManageEmployeeView = new RelayCommand(p => changeViewModel(new ManageEmployeeViewModel(user)));

            this.changeContent = changeContent;
            currentContent = new EmployeeListViewModel(changeContent);


            jumpToMainView = new RelayCommand(p => changeViewModel(new EmployeeListViewModel(changeContent)));

            employeeListViewModel = new EmployeeListViewModel(changeContent);

            changeContent.OnSelectedEmployee += OnJumpToEmployeeDetailedInformation;

            logOut = new RelayCommand(p => executeLogOut(), p => true);
        }
        #endregion

        #region methods 

        private async void executeLogOut()
        {
            var someChoice = MessageBox.Show("Вы точно хотите выйти из аккаунта?", "Выход из учетной записи", MessageBoxButton.YesNo);//надо будет заменить

            if (someChoice == MessageBoxResult.Yes)
            {
                OnLogOut?.Invoke(this, new CheckEventArgs(true));
            }

            //вызов popup или же можно будет обойтись messagebox
            //проверка результатов выбора
        }
        private void OnJumpToEmployeeDetailedInformation(object sender, CheckEmployeeSelected e)
        {
            if (e.IsSelected)
            {
                CurrentContent = e.ViewModel;
            }
        }
        private void changeViewModel(BaseViewModel viewModel)
        {
            CurrentContent = viewModel;
        }
        #endregion

    }
}
