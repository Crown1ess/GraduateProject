﻿using System.Windows;


namespace Employees.Views.Windows
{
    /// <summary>
    /// Interaction logic for ManageEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }
        private void DraggableWindow(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }
    }
}
