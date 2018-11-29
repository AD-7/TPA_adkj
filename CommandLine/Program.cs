using Data.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ShowMenu();
          
            Console.ReadKey();
        }
    }
}
