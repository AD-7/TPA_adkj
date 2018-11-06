using Data;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WPF.Model;

namespace WPF.ViewModel
{
    public class ViewControl : INotifyPropertyChanged
    {


        public Reflector Reflector;
        public ObservableCollection<TreeView> TreeView;
        public ICommand LoadClicked;
        public string Path;
        public ViewControl()
        {
            TreeView = new ObservableCollection<TreeView>();
            LoadClicked = new DelegateCommand(Load);
            Reflector = new Reflector();
        }


        private void Load()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Dynamic Library File(*.dll)| *.dll";
            file.ShowDialog();
            Path = file.FileName;
            LoadTree();
        }

        private void LoadTree()
        {
            Reflector.Reflect(Path);
            TreeView view = new TreeView

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }

 
}
