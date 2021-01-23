using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.ViewModels.Base
{
    public abstract class ClosableViewModel
    {
        public event EventHandler ClosingRequest;

        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
    }
}
