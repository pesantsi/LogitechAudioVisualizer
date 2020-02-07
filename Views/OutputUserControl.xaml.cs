using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LogitechAudioVisualizer.ViewModels;
using System;

namespace LogitechAudioVisualizer.Views
{
    public class OutputUserControl : UserControl
    {
        private OutputViewModel OutputViewModel { get; set; }

        private byte[] FftData { get; set; }
        private int[,] Settings { get; set; }
        private int OsVerticalScale { get; set; }
        private bool OsHighQuality { get; set; }
        private Color BackgroundColor { get; set; }
        private Color ForegroundColor { get; set; }

        public OutputUserControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            if (OutputViewModel != null)
                OutputViewModel.ImageUpdated -= OnOutputViewModelImageUpdated;

            base.OnDataContextChanged(e);

            OutputViewModel = DataContext as OutputViewModel;
            if (OutputViewModel != null)
                OutputViewModel.ImageUpdated += OnOutputViewModelImageUpdated;
        }

        private void OnOutputViewModelImageUpdated(object sender, ImageUpdatedEventArgs e)
        {
            FftData = e.FftData;
            Settings = e.Settings;
            OsVerticalScale = e.OsVerticalScale;
            OsHighQuality = e.OsHighQuality;
            BackgroundColor = e.BackgroundColor;
            ForegroundColor = e.ForegroundColor;
            
            InvalidateVisual();
        }

        public override void Render(DrawingContext drawingContext)
        {
            int maxValue = byte.MaxValue;
            float heightScale = (float)Bounds.Height / maxValue;

            Pen pen = new Pen(Colors.Red.ToUint32(), (float)(Bounds.Width / 128));
            if (Settings[0, 1] == 1)
            {
                switch (Settings[0, 0])
                {
                    case 0:
                        DrawRectangle(drawingContext, Bounds.Width, Bounds.Height, Color.FromRgb((byte)Settings[1, 0], (byte)Settings[1, 1], (byte)Settings[1, 2]));
                        pen.Brush = new SolidColorBrush(Color.FromRgb((byte)Settings[2, 0], (byte)Settings[2, 1], (byte)Settings[2, 2]));

                        DrawBars(drawingContext, pen, Bounds.Width, Bounds.Height, FftData, heightScale, OsVerticalScale);
                        break;
                    case 1:
                        DrawRectangle(drawingContext, Bounds.Width, Bounds.Height, Colors.Black);
                        PrepareGradientBrush(pen);
                        DrawBars(drawingContext, pen, Bounds.Width, Bounds.Height, FftData, heightScale, OsVerticalScale);
                        break;
                    case 2:
                        DrawRectangle(drawingContext, Bounds.Width, Bounds.Height, Colors.Black);
                        for (int i = 0; i < FftData.Length; ++i)
                        {
                            int index = (int)(2.0 + i * 0.180000007152557);
                            pen.Brush = new SolidColorBrush(Color.FromRgb((byte)Settings[index, 0], (byte)Settings[index, 1], (byte)Settings[index, 2]));
                            DrawBar(drawingContext, pen, Bounds.Width, Bounds.Height, FftData, heightScale, OsVerticalScale, i);
                        }
                        break;
                }
            }
            else
            {
                DrawRectangle(drawingContext, Bounds.Width, Bounds.Height, BackgroundColor);
                pen.Brush = new SolidColorBrush(ForegroundColor);
                DrawBars(drawingContext, pen, Bounds.Width, Bounds.Height, FftData, heightScale, OsVerticalScale);
            }
        }

        private void PrepareGradientBrush(Pen pen)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new RelativePoint(0, 0, RelativeUnit.Absolute);
            gradientBrush.EndPoint = new RelativePoint(0, Bounds.Height, RelativeUnit.Absolute);

            int numColors = 6;
            Color[] clrArray = new Color[numColors];
            for (int index = 0; index < numColors; ++index)
                clrArray[index] = Color.FromRgb((byte)Settings[index + 2, 0], (byte)Settings[index + 2, 1], (byte)Settings[index + 2, 2]);


            for (int index = 0; index < numColors; ++index)
                gradientBrush.GradientStops.Add(new GradientStop(clrArray[index], (double)index / (numColors - 1)));

            pen.Brush = gradientBrush;
        }

        private void DrawRectangle(DrawingContext drawingContext, double width, double height, Color color)
        {
            drawingContext.FillRectangle(new SolidColorBrush(color), new Rect(0, 0, width, height));
        }
        
        private void DrawBar(DrawingContext drawingContext, Pen pen, double width, double height, byte[] fftData, float heightScale, float verticalScale, int i)
        {
            var from = new Point((float)i * pen.Thickness, (float)height - fftData[i] * heightScale * verticalScale);
            var to = new Point((float)i * pen.Thickness, (float)height);
            drawingContext.DrawLine(pen, from, to);
        }

        private void DrawBars(DrawingContext drawingContext, Pen pen, double width, double height, byte[] fftData, float heightScale, float verticalScale)
        {
            for (int i = 0; i < fftData.Length; ++i)
                DrawBar(drawingContext, pen, width, height, fftData, heightScale, verticalScale, i);
        }
    }
}
