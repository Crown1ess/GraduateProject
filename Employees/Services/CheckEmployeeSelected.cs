using Employees.ViewModels.Base;
using System;

namespace Employees.Services
{
    public class CheckEmployeeSelected : EventArgs
    {
        public bool IsSelected;

        public int SelectedEmployee;
        public BaseViewModel ViewModel;

        public CheckEmployeeSelected(bool isSelected, int selectedEmployee, BaseViewModel viewModel)
        {
            this.IsSelected = isSelected;
            this.SelectedEmployee = selectedEmployee;
            this.ViewModel = viewModel;
        }
    }
}
