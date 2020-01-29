//// Decompiled with JetBrains decompiler
//// Type: LogitechSpectrogram.OutputWindow
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using System;
//using System.ComponentModel;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace LogitechSpectrogram
//{
//  public class OutputWindow : Form
//  {
//    private bool readyForUpdate = true;
//    private readonly MainFormInterface ParentWindow;
//    private IContainer components;
//    private PictureBox pictureBox_Output;

//    public OutputWindow(MainFormInterface ParentWindowHook)
//    {
//      this.ParentWindow = ParentWindowHook;
//      this.InitializeComponent();
//    }

//    protected override bool ShowWithoutActivation
//    {
//      get
//      {
//        return true;
//      }
//    }

//    public void UpdateImage(
//      byte[] fftData,
//      int[,] settings,
//      float verticalScale,
//      bool highQuality,
//      Color bgColor,
//      Color fgColor)
//    {
//      if (!this.readyForUpdate)
//        return;
//      this.readyForUpdate = false;
//      if (this.WindowState == FormWindowState.Minimized)
//        return;
//      Task.Factory.StartNew((Action) (() =>
//      {
//        Image image = this.pictureBox_Output.Image;
//        int maxValue = (int) byte.MaxValue;
//        Bitmap newImage = new Bitmap(this.pictureBox_Output.Width, this.pictureBox_Output.Height);
//        float heightScale = (float) this.pictureBox_Output.Height / (float) maxValue;
//        using (Graphics graphics = Graphics.FromImage((Image) newImage))
//        {
//          this.PrepareGraphics(graphics, highQuality);
//          using (Pen pen = new Pen(Color.Red, (float) (this.pictureBox_Output.Width / 128)))
//          {
//            if (settings[0, 1] == 1)
//            {
//              switch (settings[0, 0])
//              {
//                case 0:
//                  this.pictureBox_Output.BackColor = Color.FromArgb(settings[1, 0], settings[1, 1], settings[1, 2]);
//                  pen.Color = Color.FromArgb(settings[2, 0], settings[2, 1], settings[2, 2]);
//                  this.DrawBars(graphics, pen, this.pictureBox_Output.Width, this.pictureBox_Output.Height, fftData, heightScale, verticalScale);
//                  break;
//                case 1:
//                  this.pictureBox_Output.BackColor = Color.Black;
//                  using (LinearGradientBrush gradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, newImage.Height), Color.Red, Color.Red))
//                  {
//                    int numColors = 6;
//                    Color[] clrArray = new Color[numColors];
//                    for (int index = 0; index < 6; ++index)
//                      clrArray[index] = Color.FromArgb(settings[index + 2, 0], settings[index + 2, 1], settings[index + 2, 2]);
//                    this.PrepareGradientBrush(gradientBrush, pen, clrArray, numColors);
//                    this.DrawBars(graphics, pen, newImage.Width, newImage.Height, fftData, heightScale, verticalScale);
//                    break;
//                  }
//                case 2:
//                  this.pictureBox_Output.BackColor = Color.Black;
//                  for (int i = 0; i < fftData.Length; ++i)
//                  {
//                    int index = (int) (2.0 + (double) i * 0.180000007152557);
//                    pen.Color = Color.FromArgb(settings[index, 0], settings[index, 1], settings[index, 2]);
//                    this.DrawBar(graphics, pen, newImage.Width, newImage.Height, fftData, heightScale, verticalScale, i);
//                  }
//                  break;
//              }
//            }
//            else
//            {
//              this.pictureBox_Output.BackColor = bgColor;
//              pen.Color = fgColor;
//              this.DrawBars(graphics, pen, this.pictureBox_Output.Width, this.pictureBox_Output.Height, fftData, heightScale, verticalScale);
//            }
//          }
//        }
//        if (newImage == null)
//          return;
//        try
//        {
//          this.Invoke((Action) (() =>
//          {
//            this.pictureBox_Output.Image = (Image) newImage;
//            image?.Dispose();
//            this.readyForUpdate = true;
//          }));
//        }
//        catch (ObjectDisposedException ex)
//        {
//        }
//      }));
//    }

//    private void DrawBar(
//      Graphics graphics,
//      Pen pen,
//      int width,
//      int height,
//      byte[] fftData,
//      float heightScale,
//      float verticalScale,
//      int i)
//    {
//      graphics.DrawLine(pen, (float) i * pen.Width, (float) height - (float) fftData[i] * heightScale * verticalScale, (float) i * pen.Width, (float) height);
//    }

//    private void DrawBars(
//      Graphics graphics,
//      Pen pen,
//      int width,
//      int height,
//      byte[] fftData,
//      float heightScale,
//      float verticalScale)
//    {
//      for (int i = 0; i < fftData.Length; ++i)
//        this.DrawBar(graphics, pen, width, height, fftData, heightScale, verticalScale, i);
//    }

//    private void PrepareGradientBrush(
//      LinearGradientBrush gradientBrush,
//      Pen myPen,
//      Color[] clrArray,
//      int numColors)
//    {
//      ColorBlend colorBlend = new ColorBlend();
//      colorBlend.Colors = clrArray;
//      float[] numArray = new float[numColors];
//      for (int index = 0; index < numColors; ++index)
//        numArray[index] = (float) index * 1f / (float) (numColors - 1);
//      colorBlend.Positions = numArray;
//      gradientBrush.InterpolationColors = colorBlend;
//      myPen.Brush = (Brush) gradientBrush;
//    }

//    private void PrepareGraphics(Graphics graphics, bool highQuality)
//    {
//      if (highQuality)
//      {
//        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//        graphics.SmoothingMode = SmoothingMode.AntiAlias;
//        graphics.CompositingQuality = CompositingQuality.AssumeLinear;
//        graphics.PixelOffsetMode = PixelOffsetMode.Default;
//        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
//      }
//      else
//      {
//        graphics.InterpolationMode = InterpolationMode.Low;
//        graphics.SmoothingMode = SmoothingMode.HighSpeed;
//        graphics.CompositingQuality = CompositingQuality.HighSpeed;
//        graphics.PixelOffsetMode = PixelOffsetMode.None;
//        graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
//      }
//    }

//    private void OutputWindow_Resize(object sender, EventArgs e)
//    {
//    }

//    private void OutputWindow_FormClosing(object sender, FormClosingEventArgs e)
//    {
//      this.ParentWindow.openOutputWindowText = "Open Output Window";
//    }

//    protected override void Dispose(bool disposing)
//    {
//      if (disposing && this.components != null)
//        this.components.Dispose();
//      base.Dispose(disposing);
//    }

//    private void InitializeComponent()
//    {
//      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (OutputWindow));
//      this.pictureBox_Output = new PictureBox();
//      ((ISupportInitialize) this.pictureBox_Output).BeginInit();
//      this.SuspendLayout();
//      this.pictureBox_Output.BackColor = Color.Black;
//      this.pictureBox_Output.BorderStyle = BorderStyle.FixedSingle;
//      this.pictureBox_Output.Dock = DockStyle.Fill;
//      this.pictureBox_Output.Location = new Point(0, 0);
//      this.pictureBox_Output.Name = "pictureBox_Output";
//      this.pictureBox_Output.Size = new Size(640, 361);
//      this.pictureBox_Output.TabIndex = 2;
//      this.pictureBox_Output.TabStop = false;
//      this.AutoScaleDimensions = new SizeF(6f, 13f);
//      this.AutoScaleMode = AutoScaleMode.Font;
//      this.ClientSize = new Size(640, 361);
//      this.Controls.Add((Control) this.pictureBox_Output);
//      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
//      this.MinimumSize = new Size(144, 167);
//      this.Name = nameof (OutputWindow);
//      this.Text = "On-Screen Output Window";
//      this.FormClosing += new FormClosingEventHandler(this.OutputWindow_FormClosing);
//      this.Resize += new EventHandler(this.OutputWindow_Resize);
//      ((ISupportInitialize) this.pictureBox_Output).EndInit();
//      this.ResumeLayout(false);
//    }
//  }
//}
