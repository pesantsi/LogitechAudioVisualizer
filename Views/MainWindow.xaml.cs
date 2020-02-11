using LogitechAudioVisualizer.ViewModels;
using System.Windows;

namespace LogitechAudioVisualizer.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }
    }
}