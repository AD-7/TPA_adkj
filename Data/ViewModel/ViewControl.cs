using Data.Tracing;
using Data.TreeViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System;

namespace Data.ViewModel
{
    public class ViewControl : INotifyPropertyChanged
    {


        public Reflector Reflector;
        public ObservableCollection<MyTreeView> TV { get; set; }
        public ICommand LoadFileClicked { get; }
        public ICommand ShowTree { get; }
        public MyTraceSource Tracer;
        public string Path;

        public ViewControl()

        {    Tracer = new MyTraceSource("plik.txt");
            TV = new ObservableCollection<MyTreeView>();
            LoadFileClicked = new DelegateCommand(Load);
            ShowTree = new DelegateCommand(LoadTree);
            Reflector = new Reflector();
        }

         public void LoadFile(string path)
        {
            Path = path;
            string info = "Wczytano plik " + Path;
            Tracer.TraceData(TraceEventType.Information, info);
        }
        private void Load()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Dynamic Library File(*.dll)| *.dll";
            file.ShowDialog();
            Path = file.FileName;
           
            string info = "Wczytano plik " + Path;
            Tracer.TraceData(TraceEventType.Information,info );
            
        }

        private void LoadTree()
        {
            Reflector.Reflect(Path,Tracer);
            MyTreeView newTree = new MyTreeView(Reflector.AssemblyModel);
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
