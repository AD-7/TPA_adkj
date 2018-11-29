using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.TreeViewModel
{
    public class MyTreeView
    {
        public string Name { get; set; }
        public ObservableCollection<MyTreeView> Children { get; set; }
        public IMetadata data;
        private bool wasBuilt;
        private bool isExpanded;

        public MyTreeView(IMetadata metadata)
        {
            Children = new ObservableCollection<MyTreeView>();
            Children.Add(null);
            wasBuilt = false;
            data = metadata;
            Name = metadata.MetadataName + " " + metadata.Name;
        }

        public bool IsExpanded
        {
          //  get { return isExpanded; }
            set
            {
                isExpanded = value;
                if (wasBuilt)
                    return;
                Children.Clear();
                buildMyself();
                wasBuilt = true;
            }
        }
        private void buildMyself()
        {
            
            ObservableCollection<IMetadata> test = data.getChildren;
            foreach (var i in test)
            {
                MyTreeView newtree = new MyTreeView(i);
                Children.Add(newtree);
            }
        }



    }
}
