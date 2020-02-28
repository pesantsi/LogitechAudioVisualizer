using LogitechAudioVisualizer.ViewModels;
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows;

namespace LogitechAudioVisualizer.Views
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = MainWindowViewModel.Instance;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;

            this.Hide();

            base.OnClosing(e);
        }
    }
}