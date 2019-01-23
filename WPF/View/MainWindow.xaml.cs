using System;
using System.IO;
using System.Windows;
using ViewModel;

namespace WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewControl();
            AppDomain.CurrentDomain.SetData(
  "DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));
        }

        
    }
}
