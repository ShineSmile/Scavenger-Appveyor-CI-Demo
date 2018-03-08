using System.Windows;

namespace Scavenger
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ((App) Application.Current).MainViewModel;
        }
    }
}