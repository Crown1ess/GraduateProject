using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    public class SecondCheckEventArgs : EventArgs
    {
        public bool IsChecked;

        public SecondCheckEventArgs(bool isChecked)
        {
            this.IsChecked = isChecked;
        }
    }
}
