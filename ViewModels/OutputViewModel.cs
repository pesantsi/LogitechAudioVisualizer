using Avalonia.Media;
using System;

namespace LogitechAudioVisualizer.ViewModels
{
    public class ImageUpdatedEventArgs : EventArgs
    {
        public byte[] FftData { get; }
        public int[,] Settings { get; }
        public int OsVerticalScale { get; }
        public bool OsHighQuality { get; }
        public Color BackgroundColor { get; }
        public Color ForegroundColor { get; }
        
        public ImageUpdatedEventArgs(byte[] fftData, int[,] settings, int osVerticalScale, bool osHighQuality, Color backgroundColor, Color foregroundColor)
        {
            FftData = fftData;
            Settings = settings;
            OsVerticalScale = osVerticalScale;
            OsHighQuality = osHighQuality;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
        }
    }

    public class OutputViewModel : ViewModelBase
    {
        public event EventHandler<ImageUpdatedEventArgs> ImageUpdated;

        //public WriteableBitmap WriteableBitmap
        //{
        //    get => Get<WriteableBitmap>();
        //    set => Set(value);
        //}

        //public Action Invalidate
        //{
        //    get => Get<Action>();
        //    set => Set(value);
        //}



        public OutputViewModel()
        {


            // Bgra8888 is device-native and much faster.
            //WriteableBitmap = new WriteableBitmap(new Avalonia.PixelSize(640, 480), new Avalonia.Vector(96, 96), PixelFormat.Bgra8888);
            //Reset();
            //Task.Run(MoveFlakes);

        }

        public void UpdateImage(byte[] fftData, int[,] settings, int osVerticalScale, bool osHighQuality, Color backgroundColor, Color foregroundColor)
        {
            ImageUpdated?.Invoke(this, new ImageUpdatedEventArgs(fftData, settings, osVerticalScale, osHighQuality, backgroundColor, foregroundColor));
            //if (WriteableBitmap == null)
            //{
            //    WriteableBitmap = new WriteableBitmap(new Avalonia.PixelSize(500, 500), new Avalonia.Vector(96, 96), PixelFormat.Bgra8888);
            //}

            // Reserve the back buffer for updates.
            //using (var buffer = WriteableBitmap.Lock())
            //{
            //    using (Graphics graphics = Graphics.FromImage((Image)WriteableBitmap.PlatformImpl))
            //    { 
            //        Avalonia.gr
            //    }

            //        var pBackBuffer = (uint*)buffer.Address;

            //    int width = WriteableBitmap.PixelSize.Width;
            //    int x = 100;
            //    int y = 100;
               

            //        // Erase old flake.
            //        var oldPtr = pBackBuffer + width * y + x;
            //        *oldPtr = 0;

            //        // New position.
            //        y++;
            //        var newPtr = oldPtr + width;
            //        var newAlphaPtr = (byte*)newPtr + 3;

            //    if (*newAlphaPtr == byte.MaxValue)
            //    {
            //        // Check pixels to the left or to the right: we might be on a slope.
            //        if (x > 0 && *(newAlphaPtr - 4) != byte.MaxValue)
            //        {
            //            x--;
            //            newPtr--;
            //        }
            //        else if (x + 1 < width && *(newAlphaPtr + 4) != byte.MaxValue)
            //        {
            //            x++;
            //            newPtr++;
            //        }
            //        else
            //        {
            //            // Not on a slope, stop here and preserve the pixel.
            //            //InitFlake(ref f);
            //            newPtr = pBackBuffer + width * y + x;

            //            // Mark as static by setting alpha to 255.
            //            // Make persistent color lighter.
            //            //var clr = MaxSpeed * 0.8 + f.Speed * 0.2;
            //            //*oldPtr = GetGray((byte)clr) | 0xFF000000;
            //        }
            //    }

            //    *newPtr = GetGray((byte)_rnd.Next(MaxSpeed));

                //pBackBuffer += row;
                //pBackBuffer += column * 4;

                //// Compute the pixel's color.
                //int color_data = 255 << 16; // R
                //color_data |= 128 << 255;   // G
                //color_data |= 255 << 0;   // B

                //// Assign the color data to the pixel.
                //*((int*)pBackBuffer) = color_data;

                //var bit = WriteableBitmap.PlatformImpl as Avalonia.Media.Imaging.Bitmap;

                // Get a pointer to the back buffer.
                //    IntPtr pBackBuffer = WriteableBitmap.PlatformImpl.Item

                //    // Find the address of the pixel to draw.
                //    pBackBuffer += row * WriteableBitmap.BackBufferStride;
                //    pBackBuffer += column * 4;

                //    // Compute the pixel's color.
                //    int color_data = 255 << 16; // R
                //    color_data |= 128 << 8;   // G
                //    color_data |= 255 << 0;   // B

                //    // Assign the color data to the pixel.
                //    *((int*)pBackBuffer) = color_data;

                // Specify the area of the bitmap that changed.
                // WriteableBitmap.AddDirtyRect(new Int32Rect(column, row, 1, 1));
            //}

            //Invalidate?.Invoke();


            ////int maxValue = (int)byte.MaxValue;
            ////   Bitmap newImage = new Bitmap(this.pictureBox_Output.Width, this.pictureBox_Output.Height);
            ////   float heightScale = (float)this.pictureBox_Output.Height / (float)maxValue;
            ////   using (Graphics graphics = Graphics.FromImage((Image)newImage))
            ////   {
            ////       this.PrepareGraphics(graphics, highQuality);
            ////       using (Pen pen = new Pen(Color.Red, (float)(this.pictureBox_Output.Width / 128)))
            ////       {
            ////           if (settings[0, 1] == 1)
            ////           {
            ////               switch (settings[0, 0])
            ////               {
            ////                   case 0:
            ////                       this.pictureBox_Output.BackColor = Color.FromArgb(settings[1, 0], settings[1, 1], settings[1, 2]);
            ////                       pen.Color = Color.FromArgb(settings[2, 0], settings[2, 1], settings[2, 2]);
            ////                       this.DrawBars(graphics, pen, this.pictureBox_Output.Width, this.pictureBox_Output.Height, fftData, heightScale, verticalScale);
            ////                       break;
            ////                   case 1:
            ////                       this.pictureBox_Output.BackColor = Color.Black;
            ////                       using (LinearGradientBrush gradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, newImage.Height), Color.Red, Color.Red))
            ////                       {
            ////                           int numColors = 6;
            ////                           Color[] clrArray = new Color[numColors];
            ////                           for (int index = 0; index < 6; ++index)
            ////                               clrArray[index] = Color.FromArgb(settings[index + 2, 0], settings[index + 2, 1], settings[index + 2, 2]);
            ////                           this.PrepareGradientBrush(gradientBrush, pen, clrArray, numColors);
            ////                           this.DrawBars(graphics, pen, newImage.Width, newImage.Height, fftData, heightScale, verticalScale);
            ////                           break;
            ////                       }
            ////                   case 2:
            ////                       this.pictureBox_Output.BackColor = Color.Black;
            ////                       for (int i = 0; i < fftData.Length; ++i)
            ////                       {
            ////                           int index = (int)(2.0 + (double)i * 0.180000007152557);
            ////                           pen.Color = Color.FromArgb(settings[index, 0], settings[index, 1], settings[index, 2]);
            ////                           this.DrawBar(graphics, pen, newImage.Width, newImage.Height, fftData, heightScale, verticalScale, i);
            ////                       }
            ////                       break;
            ////               }
            ////           }
            ////           else
            ////           {
            ////               this.pictureBox_Output.BackColor = bgColor;
            ////               pen.Color = fgColor;
            ////               this.DrawBars(graphics, pen, this.pictureBox_Output.Width, this.pictureBox_Output.Height, fftData, heightScale, verticalScale);
            ////           }
            ////       }
            ////   }
            ////   if (newImage == null)
            ////       return;
            ////   try
            ////   {


            ////       //this.Invoke((Action)(() =>
            ////       //      {
            ////       //          this.pictureBox_Output.Image = (Image)newImage;
            ////       //          image?.Dispose();
            ////       //          this.readyForUpdate = true;
            ////       //      }));
            ////   }
            ////   catch (ObjectDisposedException ex)
            ////   {
            ////   }
        }

        //private const byte MaxSpeed = 200;

        //private int _flakeCount = 3000;

        //private Flake[] _flakes;

        //private readonly Random _rnd = new Random();

        //private readonly Action _invalidate;

        //private int _delayMs = 10;

        //public SnowViewModel(Action invalidate)
        //{
        //    _invalidate = invalidate;

        //    ResetCommand = new DelegateCommand(Reset);

        //    // Bgra8888 is device-native and much faster.
        //    Bitmap = new WriteableBitmap(new PixelSize(640, 480), new Vector(96, 96), PixelFormat.Bgra8888);
        //    Reset();
        //    Task.Run(MoveFlakes);
        //}

        //public WriteableBitmap Bitmap { get; }

        //public int FlakeCount
        //{
        //    get => _flakeCount;
        //    set => ResizeFlakes(value);
        //}

        //public int DelayMsInverted
        //{
        //    get => MaxDelay - _delayMs;
        //    set => _delayMs = MaxDelay - value;
        //}

        //public int MaxDelay => 16;

        //public unsafe void PutPixel(double x, double y, int size)
        //{
        //    // Convert relative to absolute.
        //    var width = WriteableBitmap.PixelSize.Width;
        //    var height = WriteableBitmap.PixelSize.Height;

        //    var px = (int)(x * width);
        //    var py = (int)(y * height);

        //    var c = Color.FromArgb(16, 255, 0);
        //    var pixel = c.B + ((uint)c.G << 8) + ((uint)c.R << 16) + ((uint)c.A << 24);

        //    using var buf = WriteableBitmap.Lock();
        //    for (var x0 = px - size; x0 <= px + size; x0++)
        //        for (var y0 = py - size; y0 <= py + size; y0++)
        //        {
        //            if (x0 >= 0 && x0 < width && y0 >= 0 && y0 < height)
        //            {
        //                var ptr = (uint*)buf.Address;
        //                ptr += (uint)(width * y0 + x0);

        //                *ptr = pixel;
        //            }
        //        }
        //}

        //private void Reset()
        //{
        //    InitFlakes();
        //    //ResetBitmap();
        //}

        //private void InitFlakes()
        //{
        //    _flakes = new Flake[_flakeCount];

        //    for (var i = 0; i < _flakes.Length; i++)
        //    {
        //        ref var f = ref _flakes[i];
        //        InitFlake(ref f);
        //        f.Y = (short)_rnd.Next(40);
        //        f.Y2 = 0;
        //    }
        //}

        //private void InitFlake(ref Flake f)
        //{
        //    var tone = (byte)_rnd.Next(MaxSpeed);
        //    f.X = (short)_rnd.Next(WriteableBitmap.PixelSize.Width);
        //    f.Speed = tone;
        //    f.Y = 0;
        //    f.Y2 = 0;
        //}

        //private unsafe void ResizeFlakes(int newCount)
        //{
        //    using var buf = WriteableBitmap.Lock();
        //    var ptr = (uint*)buf.Address;

        //    var old = _flakes;
        //    var oldCount = _flakeCount;
        //    _flakes = new Flake[newCount];

        //    if (newCount < oldCount)
        //    {
        //        // Remove extra flakes, trim array.
        //        for (var i = newCount; i < oldCount; i++)
        //        {
        //            *(ptr + old[i].X + old[i].Y * WriteableBitmap.PixelSize.Width) = 0;
        //        }

        //        Array.Copy(old, _flakes, newCount);
        //    }
        //    else
        //    {
        //        // Add more flakes.
        //        Array.Copy(old, _flakes, oldCount);

        //        for (var i = oldCount; i < newCount; i++)
        //        {
        //            InitFlake(ref _flakes[i]);
        //        }
        //    }

        //    _flakeCount = newCount;
        //}

        //private unsafe void ResetBitmap()
        //{
        //    using var buf = WriteableBitmap.Lock();

        //    var ptr = (uint*)buf.Address;

        //    var w = WriteableBitmap.PixelSize.Width;
        //    var h = WriteableBitmap.PixelSize.Height;

        //    // Clear.
        //    for (var i = 0; i < w * (h - 1); i++)
        //    {
        //        *(ptr + i) = 0;
        //    }

        //    // Draw bottom line.
        //    for (var i = w * (h - 1); i < w * h; i++)
        //    {
        //        *(ptr + i) = uint.MaxValue;
        //    }
        //}

        //private unsafe void MoveFlakes()
        //{
        //    while (true)
        //    {
        //        // MaxDelay means pause.
        //        if (_delayMs < MaxDelay)
        //        {
        //            var bmp = WriteableBitmap;
        //            var w = bmp.PixelSize.Width;

        //            using var buf = bmp.Lock();
        //            var ptr = (uint*)buf.Address;

        //            var flakes = _flakes;

        //            for (var i = 0; i < flakes.Length; i++)
        //            {
        //                MoveFlake(ref flakes[i], ptr, w);
        //            }
        //        }

        //        Invalidate?.Invoke();

        //        Thread.Sleep(_delayMs);
        //    }
        //    // ReSharper disable once FunctionNeverReturns
        //}

        //private unsafe void MoveFlake(ref Flake f, uint* ptr, int width)
        //{
        //    f.Y2 += f.Speed;

        //    const short slowdown = 200;
        //    if (f.Y2 < slowdown)
        //    {
        //        return;
        //    }

        //    // Erase old flake.
        //    var oldPtr = ptr + width * f.Y + f.X;
        //    *oldPtr = 0;

        //    // New position.
        //    f.Y2 = (short)(f.Y2 % slowdown);
        //    f.Y++;
        //    var newPtr = oldPtr + width;
        //    var newAlphaPtr = (byte*)newPtr + 3;

        //    // Check snow below us.
        //    if (*newAlphaPtr == byte.MaxValue)
        //    {
        //        // Check pixels to the left or to the right: we might be on a slope.
        //        if (f.X > 0 && *(newAlphaPtr - 4) != byte.MaxValue)
        //        {
        //            f.X--;
        //            newPtr--;
        //        }
        //        else if (f.X + 1 < width && *(newAlphaPtr + 4) != byte.MaxValue)
        //        {
        //            f.X++;
        //            newPtr++;
        //        }
        //        else
        //        {
        //            // Not on a slope, stop here and preserve the pixel.
        //            InitFlake(ref f);
        //            newPtr = ptr + width * f.Y + f.X;

        //            // Mark as static by setting alpha to 255.
        //            // Make persistent color lighter.
        //            var clr = MaxSpeed * 0.8 + f.Speed * 0.2;
        //            *oldPtr = GetGray((byte)clr) | 0xFF000000;
        //        }
        //    }

        //    *newPtr = GetGray(f.Speed);
        //}

        //private static uint GetGray(byte tone)
        //{
        //    var c = (byte)(byte.MaxValue - MaxSpeed + tone);

        //    // Non-max alpha indicates moving pixel.
        //    return (uint)(c | c << 8 | c << 16 | 0xFE000000);
        //}

        //private struct Flake
        //{
        //    public short X;
        //    public short Y;
        //    public short Y2;
        //    public byte Speed;
        //}
    }
}
