//// Decompiled with JetBrains decompiler
//// Type: LogitechSpectrogram.UpdateForm
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using System;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Drawing;
//using System.Windows.Forms;

//namespace LogitechSpectrogram
//{
//  public class UpdateForm : Form
//  {
//    private IContainer components;
//    private Label label_Message;
//    private Label label_CurrentVersion;
//    private Label label_LatestVersion;
//    private Label label_DownloadLink;
//    private WebBrowser webBrowser_Changelog;
//    private Button button_Close;
//    private Button button_Download;
//    private Label label_Changelog;
//    private CheckBox checkBox_UpdateCheck;
//    private Label label_MessageInput;
//    private Label label_CurrentVersionInput;
//    private Label label_LatestVersionInput;
//    private LinkLabel linkLabel_DownloadLinkInput;

//    public UpdateForm(
//      string message,
//      string currentVersion,
//      string latestVersion,
//      string downloadURL,
//      string changelogURL,
//      bool checkUpdatesCurrent)
//    {
//      this.InitializeComponent();
//      this.label_MessageInput.Text = message;
//      this.label_CurrentVersionInput.Text = currentVersion;
//      this.label_LatestVersionInput.Text = latestVersion;
//      this.linkLabel_DownloadLinkInput.Text = downloadURL;
//      this.linkLabel_DownloadLinkInput.Links.Add(0, this.linkLabel_DownloadLinkInput.Text.Length, (object) downloadURL);
//      this.webBrowser_Changelog.Url = new Uri(changelogURL);
//      this.checkUpdatesOnStartup = checkUpdatesCurrent;
//      this.checkBox_UpdateCheck.Checked = checkUpdatesCurrent;
//    }

//    public bool checkUpdatesOnStartup { get; set; }

//    private void linkLabel_DownloadLinkInput_LinkClicked(
//      object sender,
//      LinkLabelLinkClickedEventArgs e)
//    {
//      Process.Start(e.Link.LinkData.ToString());
//    }

//    private void button_Close_Click(object sender, EventArgs e)
//    {
//      this.DialogResult = DialogResult.OK;
//      this.Close();
//    }

//    private void button_Download_Click(object sender, EventArgs e)
//    {
//      Process.Start(this.linkLabel_DownloadLinkInput.Text);
//    }

//    private void checkBox_UpdateCheck_CheckedChanged(object sender, EventArgs e)
//    {
//      if (this.checkBox_UpdateCheck.Checked)
//        this.checkUpdatesOnStartup = true;
//      else
//        this.checkUpdatesOnStartup = false;
//    }

//    protected override void Dispose(bool disposing)
//    {
//      if (disposing && this.components != null)
//        this.components.Dispose();
//      base.Dispose(disposing);
//    }

//    private void InitializeComponent()
//    {
//      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UpdateForm));
//      this.label_Message = new Label();
//      this.label_CurrentVersion = new Label();
//      this.label_LatestVersion = new Label();
//      this.label_DownloadLink = new Label();
//      this.webBrowser_Changelog = new WebBrowser();
//      this.button_Close = new Button();
//      this.button_Download = new Button();
//      this.label_Changelog = new Label();
//      this.checkBox_UpdateCheck = new CheckBox();
//      this.label_MessageInput = new Label();
//      this.label_CurrentVersionInput = new Label();
//      this.label_LatestVersionInput = new Label();
//      this.linkLabel_DownloadLinkInput = new LinkLabel();
//      this.SuspendLayout();
//      this.label_Message.AutoSize = true;
//      this.label_Message.Location = new Point(9, 10);
//      this.label_Message.Name = "label_Message";
//      this.label_Message.Size = new Size(53, 13);
//      this.label_Message.TabIndex = 0;
//      this.label_Message.Text = "Message:";
//      this.label_CurrentVersion.AutoSize = true;
//      this.label_CurrentVersion.Location = new Point(9, 30);
//      this.label_CurrentVersion.Name = "label_CurrentVersion";
//      this.label_CurrentVersion.Size = new Size(124, 13);
//      this.label_CurrentVersion.TabIndex = 1;
//      this.label_CurrentVersion.Text = "Current Program Version:";
//      this.label_LatestVersion.AutoSize = true;
//      this.label_LatestVersion.Location = new Point(9, 50);
//      this.label_LatestVersion.Name = "label_LatestVersion";
//      this.label_LatestVersion.Size = new Size(119, 13);
//      this.label_LatestVersion.TabIndex = 2;
//      this.label_LatestVersion.Text = "Latest Program Version:";
//      this.label_DownloadLink.AutoSize = true;
//      this.label_DownloadLink.Location = new Point(9, 70);
//      this.label_DownloadLink.Name = "label_DownloadLink";
//      this.label_DownloadLink.Size = new Size(81, 13);
//      this.label_DownloadLink.TabIndex = 3;
//      this.label_DownloadLink.Text = "Download Link:";
//      this.webBrowser_Changelog.Location = new Point(12, 116);
//      this.webBrowser_Changelog.MinimumSize = new Size(20, 20);
//      this.webBrowser_Changelog.Name = "webBrowser_Changelog";
//      this.webBrowser_Changelog.Size = new Size(660, 304);
//      this.webBrowser_Changelog.TabIndex = 4;
//      this.button_Close.Location = new Point(597, 426);
//      this.button_Close.Name = "button_Close";
//      this.button_Close.Size = new Size(75, 23);
//      this.button_Close.TabIndex = 5;
//      this.button_Close.Text = "Close";
//      this.button_Close.UseVisualStyleBackColor = true;
//      this.button_Close.Click += new EventHandler(this.button_Close_Click);
//      this.button_Download.Location = new Point(516, 426);
//      this.button_Download.Name = "button_Download";
//      this.button_Download.Size = new Size(75, 23);
//      this.button_Download.TabIndex = 6;
//      this.button_Download.Text = "Download";
//      this.button_Download.UseVisualStyleBackColor = true;
//      this.button_Download.Click += new EventHandler(this.button_Download_Click);
//      this.label_Changelog.AutoSize = true;
//      this.label_Changelog.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
//      this.label_Changelog.Location = new Point(9, 97);
//      this.label_Changelog.Name = "label_Changelog";
//      this.label_Changelog.Size = new Size(87, 16);
//      this.label_Changelog.TabIndex = 7;
//      this.label_Changelog.Text = "Changelog:";
//      this.checkBox_UpdateCheck.AutoSize = true;
//      this.checkBox_UpdateCheck.Checked = true;
//      this.checkBox_UpdateCheck.CheckState = CheckState.Checked;
//      this.checkBox_UpdateCheck.Location = new Point(12, 430);
//      this.checkBox_UpdateCheck.Name = "checkBox_UpdateCheck";
//      this.checkBox_UpdateCheck.Size = new Size(163, 17);
//      this.checkBox_UpdateCheck.TabIndex = 8;
//      this.checkBox_UpdateCheck.Text = "Check for updates on startup";
//      this.checkBox_UpdateCheck.UseVisualStyleBackColor = true;
//      this.checkBox_UpdateCheck.CheckedChanged += new EventHandler(this.checkBox_UpdateCheck_CheckedChanged);
//      this.label_MessageInput.AutoSize = true;
//      this.label_MessageInput.Location = new Point(152, 10);
//      this.label_MessageInput.Name = "label_MessageInput";
//      this.label_MessageInput.Size = new Size(216, 13);
//      this.label_MessageInput.TabIndex = 9;
//      this.label_MessageInput.Text = "An error occurred while loading the message";
//      this.label_CurrentVersionInput.AutoSize = true;
//      this.label_CurrentVersionInput.Location = new Point(152, 30);
//      this.label_CurrentVersionInput.Name = "label_CurrentVersionInput";
//      this.label_CurrentVersionInput.Size = new Size(285, 13);
//      this.label_CurrentVersionInput.TabIndex = 10;
//      this.label_CurrentVersionInput.Text = "An error occurred while loading the current program version";
//      this.label_LatestVersionInput.AutoSize = true;
//      this.label_LatestVersionInput.Location = new Point(152, 50);
//      this.label_LatestVersionInput.Name = "label_LatestVersionInput";
//      this.label_LatestVersionInput.Size = new Size(277, 13);
//      this.label_LatestVersionInput.TabIndex = 11;
//      this.label_LatestVersionInput.Text = "An error occurred while loading the latest program version";
//      this.linkLabel_DownloadLinkInput.AutoSize = true;
//      this.linkLabel_DownloadLinkInput.Location = new Point(152, 70);
//      this.linkLabel_DownloadLinkInput.Name = "linkLabel_DownloadLinkInput";
//      this.linkLabel_DownloadLinkInput.Size = new Size(239, 13);
//      this.linkLabel_DownloadLinkInput.TabIndex = 12;
//      this.linkLabel_DownloadLinkInput.TabStop = true;
//      this.linkLabel_DownloadLinkInput.Text = "An error occurred while loading the download link";
//      this.linkLabel_DownloadLinkInput.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_DownloadLinkInput_LinkClicked);
//      this.AutoScaleDimensions = new SizeF(6f, 13f);
//      this.AutoScaleMode = AutoScaleMode.Font;
//      this.ClientSize = new Size(684, 461);
//      this.Controls.Add((Control) this.linkLabel_DownloadLinkInput);
//      this.Controls.Add((Control) this.label_LatestVersionInput);
//      this.Controls.Add((Control) this.label_CurrentVersionInput);
//      this.Controls.Add((Control) this.label_MessageInput);
//      this.Controls.Add((Control) this.checkBox_UpdateCheck);
//      this.Controls.Add((Control) this.label_Changelog);
//      this.Controls.Add((Control) this.button_Download);
//      this.Controls.Add((Control) this.button_Close);
//      this.Controls.Add((Control) this.webBrowser_Changelog);
//      this.Controls.Add((Control) this.label_DownloadLink);
//      this.Controls.Add((Control) this.label_LatestVersion);
//      this.Controls.Add((Control) this.label_CurrentVersion);
//      this.Controls.Add((Control) this.label_Message);
//      this.FormBorderStyle = FormBorderStyle.FixedDialog;
//      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
//      this.MaximizeBox = false;
//      this.MinimizeBox = false;
//      this.Name = nameof (UpdateForm);
//      this.ShowInTaskbar = false;
//      this.Text = "Program Update Available";
//      this.ResumeLayout(false);
//      this.PerformLayout();
//    }
//  }
//}
