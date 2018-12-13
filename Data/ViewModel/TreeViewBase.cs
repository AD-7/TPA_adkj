using Data;
using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public abstract  class TreeViewBase
    {
       
       
       public abstract ObservableCollection<IMetadata> getChildren();


        public static void buildMyself(RootTreeView root)
        {
            ObservableCollection<IMetadata> test = root.data.getChildren();
            foreach (var i in test)
            {
                RootTreeView newtree = new RootTreeView(i);
                root.Children.Add(newtree);
            }
        }







    }
}
