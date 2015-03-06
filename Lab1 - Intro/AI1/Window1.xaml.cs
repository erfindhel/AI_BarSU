using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;

namespace AI1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public class CollectionOfXandW
    {
        public double x { get; set; }
        public double w { get; set; }
        public double net { get; set; }
    }

    public partial class Window1 : Window
    {
        ObservableCollection<CollectionOfXandW> XWCollection=new ObservableCollection<CollectionOfXandW>();
        double NET = 0;
        public Window1()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog OpenDlg = new Microsoft.Win32.OpenFileDialog();
            OpenDlg.DefaultExt = ".txt";
            OpenDlg.Filter = "Text documents (.txt)|*.txt";
            if (OpenDlg.ShowDialog().Value == true)
            {
                StreamReader reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                char[] separator = new char[] { '\r', '\n' };
                string[] lines = reader.ReadToEnd().Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                string[] xw;

                double x,w;
                for (int i = 0; i < lines.Length; i++)
                {
                    xw = lines[i].Split(' ');
                    x=Convert.ToDouble(xw[0]);
                    w=Convert.ToDouble(xw[1]);
                    XWCollection.Add(new CollectionOfXandW { x = x, w = w,net=x*w});
                }
                dataGrid1.ItemsSource = XWCollection;
                for (int i = 0; i < XWCollection.Count; i++)
                    NET += XWCollection[i].net;
                textBlock1.Text = "NETSUMM=" + NET.ToString() + "\nOUT=\n";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NET = 0;
            for (int i = 0; i < XWCollection.Count; i++)
                NET += XWCollection[i].net;
            if (radioButton1.IsChecked == true)  
                textBlock1.Text += "Линейная: " + ActiviseFunctions.Lineral(NET).ToString();
            else
            if (radioButton2.IsChecked == true)
                textBlock1.Text += "\nПолулинейная: " + ActiviseFunctions.HalfLineral(0.5,NET).ToString();
            else
            if (radioButton3.IsChecked == true)
                textBlock1.Text += "\nЛинейная с насыщением: " + ActiviseFunctions.FillLineral(NET).ToString();
            else
            if (radioButton4.IsChecked == true)
                textBlock1.Text += "\nПороговая: " + ActiviseFunctions.Steep(NET).ToString();
            else
            if (radioButton5.IsChecked == true)
                textBlock1.Text += "\nСигмоидальная: " + ActiviseFunctions.Sigmaidal(1, NET).ToString();
            else
            if (radioButton6.IsChecked == true)
                textBlock1.Text += "\nГиперболический тангенс: " + ActiviseFunctions.Th(NET).ToString();
        }
    }
}
