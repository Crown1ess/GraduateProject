using Employees.Views.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace Employees.Commands
{
    internal class OpenManageEmployeeWindowCommand : ICommand
    {
        private ManageEmployeeWindow window;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => this.window == null;

        public void Execute(object parameter)
        {
            var window = new ManageEmployeeWindow
            {
                Owner = Application.Current.MainWindow
            };

            this.window = window;
            window.Closed += OnWindowClosed;

            window.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            this.window = null;
        }
    }
}
