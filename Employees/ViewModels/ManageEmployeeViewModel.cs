using Employees.ViewModels.Base;
using System;

namespace Employees.ViewModels
{
    public class ManageEmployeeViewModel : BaseViewModel
    {
        public event EventHandler OnAdd;

        #region commands
        #endregion

        #region constructor
        public ManageEmployeeViewModel()
        {
            
        }
        #endregion
    }
}
