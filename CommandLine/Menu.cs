using Data;
using Data.Tracing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;
using WPF.ViewModel;

namespace CommandLine
{
    public class Menu
    {
        public Reflector reflector { get; private set; }
        public ConsoleViewer consoleViewer { get; private set; }
        public MyTraceSource myTraceSource { get; set; }
        public TreeView tv { get; set; }
        ObservableCollection<TreeView> views;

        string dllPath ;

        public Menu()
        {
            dllPath = "Data.dll";
            myTraceSource = new MyTraceSource("plik.txt");
            reflector = new Reflector();
            reflector.Reflect(dllPath, myTraceSource);
            TreeView tv = new TreeView(reflector.AssemblyModel);
            consoleViewer = new ConsoleViewer(tv.Children);
            views = new ObservableCollection<TreeView>();
            views.Add(tv);
        }


        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("MENU \n\n");
            Console.WriteLine("1) Show dll structure");
            string choice = Console.ReadLine();
            Console.WriteLine();
         

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Press ENTER to expand childern object");
<<<<<<< HEAD

=======
                       
>>>>>>> 6211c9b1516dac774d77111603a9c2a075990127
                    consoleViewer.ShowTree(views, 0);
                    break;
            }
        }
    }
}
