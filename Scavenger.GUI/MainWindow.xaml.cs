using System.Windows;

namespace Scavenger.GUI
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