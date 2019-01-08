﻿
using Data.Metadata_Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Trace;
using ViewModel.TreeViewModel;

namespace ViewModel
{
    public class ViewControl : INotifyPropertyChanged
    {


        public Reflector Reflector;
        public ObservableCollection<TreeViewBase> TV { get; set; }
        public ObservableCollection<string> methods { get; set; }
        public string methodTrace { get; set; }
        public string methodSer { get; set; }
        public ICommand LoadFileClicked { get; }
        public ICommand ShowTree { get; }
        public ICommand Click_Ser { get; }
        public ICommand Click_DeSer { get; }
        public MyTraceSource tracer;
        public MEFConfig MEF;
        public string Path;

        public ViewControl()

        {
          //  tracer = new MyTraceSource("plik.txt");
            TV = new ObservableCollection<TreeViewBase>();
            methods = new ObservableCollection<string>();
            methods.Add("File");
            //methods.Add("Database");
            methodTrace = "File";
            methodSer = "File";
            LoadFileClicked = new DelegateCommand(Load);
            ShowTree = new DelegateCommand(LoadTree);
            Click_DeSer = new DelegateCommand(Deserialize);
            Click_Ser = new DelegateCommand(Serialize);
            Reflector = new Reflector();
         //   ser = new SerXML();
            MEF = new MEFConfig();
            MEF.GetComponents(@"../../Lib");
            Path = "";
        }




        private void Load()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Dynamic Library File(*.dll)| *.dll";
            file.ShowDialog();
            Path = file.FileName;
           
            string info = "Wczytano plik " + Path;
            MEF.kindOfTrace = methodTrace;
            MEF.tracer.TraceData(TraceEventType.Information, info);
        }

        private void LoadTree()
        {
            if (Path != "")
            {
                Reflector.Reflect(Path);
                //tracer.TraceData(System.Diagnostics.TraceEventType.Information, "Odczyt metadanych.");
               TreeViewBase newTree = new AssemblyTreeView(Reflector.AssemblyModel);
                string tmpname = newTree.Name;
                newTree.Name = tmpname;
                TV.Add(newTree);
                MEF.kindOfTrace = methodTrace;
                MEF.kindOfSerialize = methodSer;
                MEF.tracer.TraceData(TraceEventType.Information, "Dodano nowy widok drzewa dla pliku.");
            }

        }

        private void Serialize()
        {
            if (TV.Count > 0)
            {
                MEF.serializer.Serialize(Reflector, "test.xml");
            }

            MEF.kindOfTrace = methodTrace;
            MEF.kindOfSerialize = methodSer;
            MEF.tracer.TraceData(TraceEventType.Information, "Dokonano serializacji");
        }


        private void Deserialize()
        {
            if(methodSer == "File")
            {
                LoadXML();
            }
           

            MEF.kindOfSerialize = methodSer;
            Reflector = MEF.serializer.Deserialize(Path);

           AssemblyTreeView rootItem = new AssemblyTreeView(Reflector.AssemblyModel) { Name = Reflector.AssemblyModel.Name };
            string tempRootName = rootItem.Name;
            TV.Clear();
            rootItem.Name = "Assembly: " + tempRootName;
            TV.Add(rootItem);
            MEF.kindOfTrace = methodTrace;

            MEF.tracer.TraceData(TraceEventType.Information, "Dokonano deserializacji.");
        }

        private void LoadXML()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "XML Files (*.xml)|*.xml";
            file.ShowDialog();
            Path = file.FileName;

            string info = "Wczytano plik " + Path;
            MEF.kindOfTrace = methodTrace;
            MEF.tracer.TraceData(TraceEventType.Information, info);
        }


        

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }

 
}
