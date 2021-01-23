using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Employees.Services.WindowService
{
    public class WindowService : IWindowService
    {
        public void ShowWindow<T>(object viewModel) where T : Window, new()
        {
            var window = new T()
            {
                DataContext = viewModel
            };
            window.Show();
        }
    }
}
