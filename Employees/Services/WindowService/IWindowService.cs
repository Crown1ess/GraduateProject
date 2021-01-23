using System.Windows;

namespace Employees.Services.WindowService
{
    public interface IWindowService
    {
        public void ShowWindow<T>(object viewModel) where T : Window, new();
    }
}
