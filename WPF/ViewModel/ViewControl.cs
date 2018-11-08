using Data;
using Data.Tracing;
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
        public MyTraceSource Tracer;
        public string Path;

        public ViewControl()

        {    Tracer = new MyTraceSource("plik.txt");
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
            string info = "Wczytano plik " + file.FileName ;
            Tracer.TraceData(TraceEventType.Information,info );
            LoadTree();
        }

        private void LoadTree()
        {
            Reflector.Reflect(Path,Tracer);
            TreeView newTree = new TreeView(Reflector.AssemblyModel);
            string tmpname = newTree.Name;
            newTree.Name =  tmpname;
            TV.Add(newTree);
            Tracer.TraceData(TraceEventType.Information, "Dodano nowy widok drzewa dla pliku.");
            

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }

 
}
