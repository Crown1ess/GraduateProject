using System;
using System.Windows;
using System.Windows.Input;

namespace Employees.Commands
{
    internal class CloseApplicationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
