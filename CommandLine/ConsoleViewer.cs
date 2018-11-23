﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.TreeViewModel;

namespace CommandLine
{
    public class ConsoleViewer
    {
        ObservableCollection<MyTreeView> treeViews;

        public ConsoleViewer(ObservableCollection<MyTreeView> treeViews)
        {
            this.treeViews = treeViews;
        }

        public void ShowTree(ObservableCollection<MyTreeView> treeViews, int lvl)
        {
            if (lvl != 0)
                Console.WriteLine();
            int childLvl = 0;
            foreach (MyTreeView i in treeViews)
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