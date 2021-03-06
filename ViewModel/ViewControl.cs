﻿
using Reflection.Metadata_Model;
using Reflection.SaveManager;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using ViewModel.TreeViewModel;
using System.Windows;

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
        public string Path;

        public ViewControl()

        {
            MEFConfig.Instance.GetComp();
   
            TV = new ObservableCollection<TreeViewBase>();
            LoadFileClicked = new DelegateCommand(Load);
            ShowTree = new DelegateCommand(LoadTree);
            Click_DeSer = new DelegateCommand(Read);
            Click_Ser = new DelegateCommand(Save);
            Reflector = new Reflector();
            Path = "";

           
        }
     
        private  void Save()
        {
            if (TV.Count > 0)
            {
                MEFConfig.Instance.saveManager.Save(Reflector.AssemblyModel);
            }

            MessageBox.Show("Saved");
            MEFConfig.Instance.tracer.TraceData( "Dokonano serializacji");
        }

        private void Read()
        {
          
            
          
            Reflector.AssemblyModel = MEFConfig.Instance.saveManager.Load();
            AssemblyTreeView rootItem = new AssemblyTreeView(Reflector.AssemblyModel) { Name = Reflector.AssemblyModel.Name };
            string tempRootName = rootItem.Name;
            TV.Clear();
            rootItem.Name = "Assembly: " + tempRootName;
            TV.Add(rootItem);

            MessageBox.Show("Loaded");
            MEFConfig.Instance.tracer.TraceData( "Dokonano deserializacji.");
        }



        private void Load()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Dynamic Library File(*.dll)| *.dll";
            file.ShowDialog();
            Path = file.FileName;
           
            string info = "Wczytano plik " + Path;

  
            MEFConfig.Instance.tracer.TraceData( info);
        }
       
        private void LoadTree()
        {
            if (Path != "")
            {
                Reflector.Reflect(Path);
             
               TreeViewBase newTree = new AssemblyTreeView(Reflector.AssemblyModel);
                string tmpname = newTree.Name;
                newTree.Name = tmpname;
                TV.Add(newTree);
          
    
                MEFConfig.Instance.tracer.TraceData( "Dodano nowy widok drzewa dla pliku.");
            }

        }
      
        private void LoadXML()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "XML Files (*.xml)|*.xml";
            file.ShowDialog();
            Path = file.FileName;
       
            string info = "Wczytano plik " + Path;
         
            MEFConfig.Instance.tracer.TraceData( info);
        }


        

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }

 
}
