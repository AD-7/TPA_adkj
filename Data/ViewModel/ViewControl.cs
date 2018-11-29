using Data.Tracing;
using Data.TreeViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System;
using System.Windows;

namespace Data.ViewModel
{
    public class ViewControl : INotifyPropertyChanged
    {


        public Reflector Reflector;
        public ObservableCollection<MyTreeView> TV { get; set; }
        public ICommand LoadFileClicked { get; }
        public ICommand ShowTree { get; }
        public ICommand Click_Ser { get; }
        public ICommand Click_DeSer { get; }
        public MyTraceSource Tracer;
        public string Path;

        public ViewControl()

        {    Tracer = new MyTraceSource("plik.txt");
            TV = new ObservableCollection<MyTreeView>();
            LoadFileClicked = new DelegateCommand(Load);
            ShowTree = new DelegateCommand(LoadTree);
            Click_DeSer = new DelegateCommand(Deserialize);
            Click_Ser = new DelegateCommand(Serialize);
            Reflector = new Reflector();
            Path = "";
        }

         public void LoadFile(string path)
        {
            Path = path;
            string info = "Wczytano plik " + Path;
            Tracer.TraceData(TraceEventType.Information, info);
        }
        public void DeserializeInCommandLine(string path)
        {
            Path = path;

            Reflector = Serialization.SerXML.Deserialize(Path);

            MyTreeView rootItem = new MyTreeView(Reflector.AssemblyModel) { Name = Reflector.AssemblyModel.Name };
            string tempRootName = rootItem.Name;
            TV.Clear();
            rootItem.Name = "Assembly: " + tempRootName;
            TV.Add(rootItem);

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
            if (Path != "")
            {
                Reflector.Reflect(Path, Tracer);
                MyTreeView newTree = new MyTreeView(Reflector.AssemblyModel);
                string tmpname = newTree.Name;
                newTree.Name = tmpname;
                TV.Add(newTree);
                Tracer.TraceData(TraceEventType.Information, "Dodano nowy widok drzewa dla pliku.");
            }

        }

        private void Serialize()
        {
            if (TV.Count > 0)
            {
                Serialization.SerXML.Serialize(Reflector, "test.xml");
            }
           
        }


        private void Deserialize()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "XML Files (*.xml)|*.xml";
            file.ShowDialog();
            Path = file.FileName;

            Reflector = Serialization.SerXML.Deserialize(Path);

            MyTreeView rootItem = new MyTreeView(Reflector.AssemblyModel) { Name = Reflector.AssemblyModel.Name };
            string tempRootName = rootItem.Name;
            TV.Clear();
            rootItem.Name = "Assembly: " + tempRootName;
            TV.Add(rootItem);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }

 
}
