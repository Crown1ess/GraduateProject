using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees.Views
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
        }

        private void ButtonShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonShowMenu.Visibility = Visibility.Collapsed;
            ButtonHideMenu.Visibility = Visibility.Visible;
        }

        private void ButtonHideMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonShowMenu.Visibility = Visibility.Visible;
            ButtonHideMenu.Visibility = Visibility.Collapsed;
        }
    }
}
