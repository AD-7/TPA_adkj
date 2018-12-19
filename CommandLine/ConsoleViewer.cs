
using Data.TreeViewModel;
using System;
using System.Collections.ObjectModel;

namespace CommandLine
{
    public class ConsoleViewer
    {
        ObservableCollection<RootTreeView> treeViews;

        public ConsoleViewer(ObservableCollection<RootTreeView> treeViews)
        {
            this.treeViews = treeViews;
        }

        public void ShowTree(ObservableCollection<RootTreeView> treeViews, int lvl)
        {
            if (lvl != 0)
                Console.WriteLine();
            int childLvl = 0;
            foreach (RootTreeView i in treeViews)
            {
                for (int k = 0; k < lvl; k++)
                    Console.Write("  ");

                Console.Write(i.Name);
               i.IsExpanded = true;

                if (childLvl == 0)
                {
                    ConsoleKeyInfo keyPressed;
                    keyPressed = Console.ReadKey();
                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine();
                        return;
                    }
                    while (keyPressed.Key != ConsoleKey.Enter)
                    {
                        keyPressed = Console.ReadKey();
                    }
                }
                ShowTree(i.Children, lvl + 1);
               // childLvl++;

            } 
        }


    }
}
