using System;

namespace Employees.Services
{
    public class CheckEmployeeSelected : EventArgs
    {
        public bool IsSelected;

        public int SelectedEmployee;

        public CheckEmployeeSelected(bool isSelected, int selectedEmployee)
        {
            this.IsSelected = isSelected;
            this.SelectedEmployee = selectedEmployee;
        }
    }
}
