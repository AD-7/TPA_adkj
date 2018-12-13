using Data;
using Data.Tracing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.ViewModel;

namespace CommandLine
{
    public class Menu
    {

        public ConsoleViewer consoleViewer { get; private set; }
        public MyTraceSource myTraceSource { get; set; }
        private ViewControl view;
        string dllPath;

        

        public Menu()
        {
            dllPath = "Data.dll";
            myTraceSource = new MyTraceSource("plik.txt");
            view = new ViewControl();

            loadViewModel(dllPath);
            consoleViewer = new ConsoleViewer(view.TV);
          
        }


        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("MENU \n\n");
            Console.WriteLine("1) Show dll structure");
            Console.WriteLine("2) Change path to .dll file");
            Console.WriteLine("3) Serialize");
            Console.WriteLine("4) Deserialize");
            string choice = Console.ReadLine();
            Console.WriteLine();


            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Press ENTER to expand childern object\n");
                    loadViewModel(dllPath);
                 
                    consoleViewer.ShowTree(view.TV, 0);
                    ReloadMenu();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Add new path to .dll file:\n");
                    changeDLL();

                    ReloadMenu();
                    break;

                case "3":

                    view.Click_Ser.Execute(null);
                    ReloadMenu();
                    break;

                case "4":
                    string pathDeser;
                    Console.WriteLine("Podaj ścieżkę pliku: ");
                    pathDeser = Console.ReadLine();
                    view.DeserializeInCommandLine(pathDeser);
                    ReloadMenu();
                    break;

            }
        }

        public void ReloadMenu()
        {
            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey();
            ShowMenu();
        }

        private void loadViewModel(string path)
        {
            view.LoadFile(path);
            view.ShowTree.Execute(null);
            consoleViewer = new ConsoleViewer(view.TV);
        }
        private void changeDLL()
        {
            dllPath = Console.ReadLine();
        }
    }
}
