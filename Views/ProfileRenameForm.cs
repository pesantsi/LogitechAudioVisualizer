//// Decompiled with JetBrains decompiler
//// Type: LogitechSpectrogram.ProfileRenameForm
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using System;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;

//namespace LogitechSpectrogram
//{
//  public class ProfileRenameForm : Form
//  {
//    private IContainer components;
//    private Button button_RenameProfile_Cancel;
//    private Button button_RenameProfile_OK;
//    private Label label_RenameProfile;
//    private TextBox textBox_RenameProfile;

//    public ProfileRenameForm()
//    {
//      this.InitializeComponent();
//      this.Text = "Rename Profile";
//    }

//    public string newProfileName { get; set; }

//    private void button_RenameProfile_OK_Click(object sender, EventArgs e)
//    {
//      this.newProfileName = this.textBox_RenameProfile.Text;
//      this.DialogResult = DialogResult.OK;
//      this.Close();
//    }

//    private void button_RenameProfile_Cancel_Click(object sender, EventArgs e)
//    {
//      this.Close();
//    }

//    protected override void Dispose(bool disposing)
//    {
//      if (disposing && this.components != null)
//        this.components.Dispose();
//      base.Dispose(disposing);
//    }

//    private void InitializeComponent()
//    {
//      this.button_RenameProfile_Cancel = new Button();
//      this.button_RenameProfile_OK = new Button();
//      this.label_RenameProfile = new Label();
//      this.textBox_RenameProfile = new TextBox();
//      this.SuspendLayout();
//      this.button_RenameProfile_Cancel.DialogResult = DialogResult.Cancel;
//      this.button_RenameProfile_Cancel.Location = new Point(202, 54);
//      this.button_RenameProfile_Cancel.Name = "button_RenameProfile_Cancel";
//      this.button_RenameProfile_Cancel.Size = new Size(75, 23);
//      this.button_RenameProfile_Cancel.TabIndex = 7;
//      this.button_RenameProfile_Cancel.Text = "Cancel";
//      this.button_RenameProfile_Cancel.UseVisualStyleBackColor = true;
//      this.button_RenameProfile_Cancel.Click += new EventHandler(this.button_RenameProfile_Cancel_Click);
//      this.button_RenameProfile_OK.Location = new Point(121, 54);
//      this.button_RenameProfile_OK.Name = "button_RenameProfile_OK";
//      this.button_RenameProfile_OK.Size = new Size(75, 23);
//      this.button_RenameProfile_OK.TabIndex = 6;
//      this.button_RenameProfile_OK.Text = "OK";
//      this.button_RenameProfile_OK.UseVisualStyleBackColor = true;
//      this.button_RenameProfile_OK.Click += new EventHandler(this.button_RenameProfile_OK_Click);
//      this.label_RenameProfile.AutoSize = true;
//      this.label_RenameProfile.Location = new Point(13, 19);
//      this.label_RenameProfile.Name = "label_RenameProfile";
//      this.label_RenameProfile.Size = new Size(70, 13);
//      this.label_RenameProfile.TabIndex = 5;
//      this.label_RenameProfile.Text = "Profile Name:";
//      this.textBox_RenameProfile.Location = new Point(89, 16);
//      this.textBox_RenameProfile.MaxLength = 30;
//      this.textBox_RenameProfile.Name = "textBox_RenameProfile";
//      this.textBox_RenameProfile.Size = new Size(188, 20);
//      this.textBox_RenameProfile.TabIndex = 4;
//      this.AcceptButton = (IButtonControl) this.button_RenameProfile_OK;
//      this.AutoScaleDimensions = new SizeF(6f, 13f);
//      this.AutoScaleMode = AutoScaleMode.Font;
//      this.CancelButton = (IButtonControl) this.button_RenameProfile_Cancel;
//      this.ClientSize = new Size(295, 89);
//      this.Controls.Add((Control) this.button_RenameProfile_Cancel);
//      this.Controls.Add((Control) this.button_RenameProfile_OK);
//      this.Controls.Add((Control) this.label_RenameProfile);
//      this.Controls.Add((Control) this.textBox_RenameProfile);
//      this.FormBorderStyle = FormBorderStyle.FixedDialog;
//      this.MaximizeBox = false;
//      this.MinimizeBox = false;
//      this.Name = nameof (ProfileRenameForm);
//      this.ShowIcon = false;
//      this.ShowInTaskbar = false;
//      this.StartPosition = FormStartPosition.CenterParent;
//      this.Text = nameof (ProfileRenameForm);
//      this.ResumeLayout(false);
//      this.PerformLayout();
//    }
//  }
//}
