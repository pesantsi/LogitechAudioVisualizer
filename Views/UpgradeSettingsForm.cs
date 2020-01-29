//// Decompiled with JetBrains decompiler
//// Type: LogitechSpectrogram.UpgradeSettingsForm
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;

//namespace LogitechSpectrogram
//{
//  public class UpgradeSettingsForm : Form
//  {
//    private ListViewColumnSorter lvwColumnSorter;
//    private string[] globalSettingsFiles;
//    public string importPath;
//    private IContainer components;
//    private ListView listView_Main;
//    private ColumnHeader colVersion;
//    private ColumnHeader colLastModified;
//    private ColumnHeader columnNumber;
//    private Label label_Description;
//    private Button button_Import;
//    private Button button_Cancel;
//    private Button button_Delete;

//    public UpgradeSettingsForm(
//      string[] settingsFiles,
//      string[] settingsFilesVersion,
//      string[] settingsFilesLastModified)
//    {
//      this.InitializeComponent();
//      this.lvwColumnSorter = new ListViewColumnSorter();
//      this.listView_Main.ListViewItemSorter = (IComparer) this.lvwColumnSorter;
//      this.globalSettingsFiles = settingsFiles;
//      for (int index = 0; index < settingsFiles.Length; ++index)
//        this.listView_Main.Items.Add(new ListViewItem(index.ToString())
//        {
//          SubItems = {
//            settingsFilesVersion[index],
//            settingsFilesLastModified[index]
//          }
//        });
//    }

//    private bool getItemNumber(string itemNumberString, out int itemNumber)
//    {
//      return int.TryParse(itemNumberString, out itemNumber);
//    }

//    private bool getItemPath(ListViewItem item, out string itemPath)
//    {
//      itemPath = "";
//      int itemNumber;
//      if (this.getItemNumber(item.SubItems[0].Text, out itemNumber))
//      {
//        itemPath = this.globalSettingsFiles[itemNumber];
//        return true;
//      }
//      int num = (int) MessageBox.Show("An item number error occurred while attempting to get the file path.", "Could not get file path.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
//      return false;
//    }

//    private bool deleteFile(string filePath)
//    {
//      try
//      {
//        File.Delete(filePath);
//        return true;
//      }
//      catch (Exception ex)
//      {
//        int num = (int) MessageBox.Show("An error occurred while attempting to delete the file.\n\n" + ex.Message, "Could not delete file.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
//        return false;
//      }
//    }

//    private void listView_Main_ColumnClick(object sender, ColumnClickEventArgs e)
//    {
//      if (e.Column == this.lvwColumnSorter.SortColumn)
//      {
//        this.lvwColumnSorter.Order = this.lvwColumnSorter.Order != SortOrder.Ascending ? SortOrder.Ascending : SortOrder.Descending;
//      }
//      else
//      {
//        this.lvwColumnSorter.SortColumn = e.Column;
//        this.lvwColumnSorter.Order = SortOrder.Descending;
//      }
//      this.listView_Main.Sort();
//    }

//    private void button_Delete_Click(object sender, EventArgs e)
//    {
//      if (this.listView_Main.SelectedItems.Count > 0)
//      {
//        if (MessageBox.Show("Are you sure you want to delete " + this.listView_Main.SelectedItems.Count.ToString() + " settings file(s)?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//          return;
//        foreach (ListViewItem selectedItem in this.listView_Main.SelectedItems)
//        {
//          string itemPath;
//          if (this.getItemPath(selectedItem, out itemPath) && this.deleteFile(itemPath))
//            selectedItem.Remove();
//        }
//      }
//      else
//      {
//        int num = (int) MessageBox.Show("Please select a settings file to delete.", "No settings file selected");
//      }
//    }

//    private void button_Cancel_Click(object sender, EventArgs e)
//    {
//      this.DialogResult = DialogResult.Cancel;
//      this.Close();
//    }

//    private void button_Import_Click(object sender, EventArgs e)
//    {
//      if (this.listView_Main.SelectedItems.Count > 1)
//      {
//        int num1 = (int) MessageBox.Show("Only one settings file can be imported.", "Too many settings files selected");
//      }
//      else if (this.listView_Main.SelectedItems.Count < 1)
//      {
//        int num2 = (int) MessageBox.Show("Please select a settings file to import.", "No settings file selected");
//      }
//      else
//      {
//        string itemPath;
//        if (!this.getItemPath(this.listView_Main.SelectedItems[0], out itemPath))
//          return;
//        this.importPath = itemPath;
//        this.DialogResult = DialogResult.OK;
//        this.Close();
//      }
//    }

//    protected override void Dispose(bool disposing)
//    {
//      if (disposing && this.components != null)
//        this.components.Dispose();
//      base.Dispose(disposing);
//    }

//    private void InitializeComponent()
//    {
//      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UpgradeSettingsForm));
//      this.listView_Main = new ListView();
//      this.columnNumber = new ColumnHeader();
//      this.colVersion = new ColumnHeader();
//      this.colLastModified = new ColumnHeader();
//      this.label_Description = new Label();
//      this.button_Import = new Button();
//      this.button_Cancel = new Button();
//      this.button_Delete = new Button();
//      this.SuspendLayout();
//      this.listView_Main.Columns.AddRange(new ColumnHeader[3]
//      {
//        this.columnNumber,
//        this.colVersion,
//        this.colLastModified
//      });
//      this.listView_Main.FullRowSelect = true;
//      this.listView_Main.GridLines = true;
//      this.listView_Main.Location = new Point(12, 64);
//      this.listView_Main.Name = "listView_Main";
//      this.listView_Main.Size = new Size(660, 356);
//      this.listView_Main.TabIndex = 0;
//      this.listView_Main.UseCompatibleStateImageBehavior = false;
//      this.listView_Main.View = View.Details;
//      this.listView_Main.ColumnClick += new ColumnClickEventHandler(this.listView_Main_ColumnClick);
//      this.columnNumber.Text = "#";
//      this.columnNumber.Width = 53;
//      this.colVersion.Text = "Version";
//      this.colVersion.Width = 104;
//      this.colLastModified.Text = "Date Modified";
//      this.colLastModified.Width = 475;
//      this.label_Description.AutoSize = true;
//      this.label_Description.Location = new Point(13, 22);
//      this.label_Description.Name = "label_Description";
//      this.label_Description.Size = new Size(651, 39);
//      this.label_Description.TabIndex = 1;
//      this.label_Description.Text = "If you would like to import your settings from a previous version of this program, please select a file from below and click \"Import Settings\".\r\n\r\nThe following settings files were found:";
//      this.button_Import.Location = new Point(473, 426);
//      this.button_Import.Name = "button_Import";
//      this.button_Import.Size = new Size(118, 23);
//      this.button_Import.TabIndex = 2;
//      this.button_Import.Text = "Import Settings";
//      this.button_Import.UseVisualStyleBackColor = true;
//      this.button_Import.Click += new EventHandler(this.button_Import_Click);
//      this.button_Cancel.Location = new Point(597, 426);
//      this.button_Cancel.Name = "button_Cancel";
//      this.button_Cancel.Size = new Size(75, 23);
//      this.button_Cancel.TabIndex = 3;
//      this.button_Cancel.Text = "Cancel";
//      this.button_Cancel.UseVisualStyleBackColor = true;
//      this.button_Cancel.Click += new EventHandler(this.button_Cancel_Click);
//      this.button_Delete.Location = new Point(12, 426);
//      this.button_Delete.Name = "button_Delete";
//      this.button_Delete.Size = new Size(118, 23);
//      this.button_Delete.TabIndex = 4;
//      this.button_Delete.Text = "Delete Settings";
//      this.button_Delete.UseVisualStyleBackColor = true;
//      this.button_Delete.Click += new EventHandler(this.button_Delete_Click);
//      this.AutoScaleDimensions = new SizeF(6f, 13f);
//      this.AutoScaleMode = AutoScaleMode.Font;
//      this.ClientSize = new Size(684, 461);
//      this.Controls.Add((Control) this.button_Delete);
//      this.Controls.Add((Control) this.button_Cancel);
//      this.Controls.Add((Control) this.button_Import);
//      this.Controls.Add((Control) this.label_Description);
//      this.Controls.Add((Control) this.listView_Main);
//      this.FormBorderStyle = FormBorderStyle.FixedDialog;
//      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
//      this.MaximizeBox = false;
//      this.MinimizeBox = false;
//      this.Name = nameof (UpgradeSettingsForm);
//      this.Text = "Import Settings from Previous Version";
//      this.ResumeLayout(false);
//      this.PerformLayout();
//    }
//  }
//}
