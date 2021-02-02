using System.Windows;

namespace Employees
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }
        private void DraggableWindow(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }
    }
}
