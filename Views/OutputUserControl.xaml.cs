using LogitechAudioVisualizer.Helpers;
using LogitechAudioVisualizer.Settings;
using LogitechAudioVisualizer.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LogitechAudioVisualizer.Views
{
    public partial class OutputUserControl : UserControl
    {
        private OutputViewModel OutputViewModel { get; set; }

        private byte[] FftData { get; set; }
        private int OsVerticalScale { get; set; }
        private Color BackgroundColor { get; set; }
        private Color ForegroundColor { get; set; }

        static OutputUserControl()
        {
            DataContextProperty.OverrideMetadata(typeof(OutputUserControl), new FrameworkPropertyMetadata(null, OnDataContextPropertyChanged));
        }

        public OutputUserControl()
        {
            InitializeComponent();
        }

        private static void OnDataContextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var outputUserControl = d as OutputUserControl;
            outputUserControl?.SetDataContext(e.NewValue);
        }

        private void SetDataContext(object dataContext)
        {
            if (OutputViewModel != null)
                OutputViewModel.ImageUpdated -= OnOutputViewModelImageUpdated;

            OutputViewModel = dataContext as OutputViewModel;
            if (OutputViewModel != null)
                OutputViewModel.ImageUpdated += OnOutputViewModelImageUpdated;
        }

        private void OnOutputViewModelImageUpdated(object sender, ImageUpdatedEventArgs e)
        {
            FftData = e.FftData;
            OsVerticalScale = e.OsVerticalScale;
            BackgroundColor = e.BackgroundColor;
            ForegroundColor = e.ForegroundColor;

            DispatcherHelper.InvokeIfRequired(() => InvalidateVisual());
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (FftData != null)
            {
                int maxValue = byte.MaxValue;
                float heightScale = (float)ActualHeight / maxValue;

                Pen pen;
                if (UserSettingsManager.Instance.UserSettings.OsKeyboardColors.Value)
                {
                    switch (UserSettingsManager.Instance.UserSettings.ColorMode.Value)
                    {
                        case 0:
                            DrawRectangle(drawingContext, ActualWidth, ActualHeight, BackgroundColor);
                            pen = new Pen() { Thickness = (float)(ActualWidth / 128) };
                            pen.Brush = new SolidColorBrush(ForegroundColor);
                            DrawBars(drawingContext, pen, ActualWidth, ActualHeight, FftData, heightScale, OsVerticalScale);
                            break;
                        case 1:
                            pen = new Pen() { Thickness = (float)(ActualWidth / 128) };
                            DrawRectangle(drawingContext, ActualWidth, ActualHeight, BackgroundColor);
                            PrepareGradientBrush(pen);
                            DrawBars(drawingContext, pen, ActualWidth, ActualHeight, FftData, heightScale, OsVerticalScale);
                            break;
                        case 2:
                            DrawRectangle(drawingContext, ActualWidth, ActualHeight, BackgroundColor);
                            for (int i = 0; i < FftData.Length; ++i)
                            {
                                int index = (int)(i * 0.180000007152557);
                                pen = new Pen() { Thickness = (float)(ActualWidth / 128) };
                                pen.Brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[index]));
                                DrawBar(drawingContext, pen, ActualWidth, ActualHeight, FftData, heightScale, OsVerticalScale, i);
                            }
                            break;
                    }
                }
                else
                {
                    DrawRectangle(drawingContext, ActualWidth, ActualHeight, BackgroundColor);
                    pen = new Pen() { Thickness = (float)(ActualWidth / 128) };
                    pen.Brush = new SolidColorBrush(ForegroundColor);
                    DrawBars(drawingContext, pen, ActualWidth, ActualHeight, FftData, heightScale, OsVerticalScale);
                }
            }

            base.OnRender(drawingContext);
        }

        private void PrepareGradientBrush(Pen pen)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.MappingMode = BrushMappingMode.Absolute;
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(0, ActualHeight);

            int numColors = UserSettingsManager.Instance.UserSettings.GradientColor.Value.Count;
            for (int index = 0; index < numColors; ++index)
            {
                gradientBrush.GradientStops.Add
                    (
                        new GradientStop
                        (
                            (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.GradientColor.Value[index]),
                            (double)index / (numColors - 1)
                        )
                    );
            }

            pen.Brush = gradientBrush;
        }

        private void DrawRectangle(DrawingContext drawingContext, double width, double height, Color color)
        {
            drawingContext.DrawRectangle(new SolidColorBrush(color), null, new Rect(0, 0, width, height));
        }

        private void DrawBar(DrawingContext drawingContext, Pen pen, double width, double height, byte[] fftData, float heightScale, float verticalScale, int i)
        {
            var x = ((float)i * pen.Thickness) + (pen.Thickness / 2);

            var from = new Point(x, (float)height - fftData[i] * heightScale * verticalScale);
            var to = new Point(x, (float)height);

            drawingContext.DrawLine(pen, from, to);
        }

        private void DrawBars(DrawingContext drawingContext, Pen pen, double width, double height, byte[] fftData, float heightScale, float verticalScale)
        {
            for (int i = 0; i < fftData.Length; ++i)
                DrawBar(drawingContext, pen, width, height, fftData, heightScale, verticalScale, i);
        }
    }
}
