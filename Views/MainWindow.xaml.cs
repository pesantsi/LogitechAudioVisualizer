using LogitechAudioVisualizer.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace LogitechAudioVisualizer.Views
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }
    }
}