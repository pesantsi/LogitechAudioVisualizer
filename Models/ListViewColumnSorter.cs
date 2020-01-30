//// Decompiled with JetBrains decompiler
//// Type: ListViewColumnSorter
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using System.Collections;
//using System.Windows.Forms;

//public class ListViewColumnSorter : IComparer
//{
//  private int ColumnToSort;
//  private SortOrder OrderOfSort;
//  private CaseInsensitiveComparer ObjectCompare;

//  public ListViewColumnSorter()
//  {
//    this.ColumnToSort = 0;
//    this.OrderOfSort = SortOrder.None;
//    this.ObjectCompare = new CaseInsensitiveComparer();
//  }

//  public int Compare(object x, object y)
//  {
//    int num = this.ObjectCompare.Compare((object) ((ListViewItem) x).SubItems[this.ColumnToSort].Text, (object) ((ListViewItem) y).SubItems[this.ColumnToSort].Text);
//    if (this.OrderOfSort == SortOrder.Ascending)
//      return num;
//    if (this.OrderOfSort == SortOrder.Descending)
//      return -num;
//    return 0;
//  }

//  public int SortColumn
//  {
//    set
//    {
//      this.ColumnToSort = value;
//    }
//    get
//    {
//      return this.ColumnToSort;
//    }
//  }

//  public SortOrder Order
//  {
//    set
//    {
//      this.OrderOfSort = value;
//    }
//    get
//    {
//      return this.OrderOfSort;
//    }
//  }
//}
