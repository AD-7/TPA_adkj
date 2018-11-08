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
        public ObservableCollection<TreeView> TV { get; set; }
        public ICommand LoadClicked { get; }
        public string Path;
        public ViewControl()
        {
            TV = new ObservableCollection<TreeView>();
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
            TreeView newTree = new TreeView(Reflector.AssemblyModel);
            string tmpname = newTree.Name;
            newTree.Name =  tmpname;
            TV.Add(newTree);
            

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }

 
}
