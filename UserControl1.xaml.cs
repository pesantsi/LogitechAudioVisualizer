﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LogitechAudioVisualizer
{
    public class UserControl1 : UserControl
    {
        public UserControl1()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
