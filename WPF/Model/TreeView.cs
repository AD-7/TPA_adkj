using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    public class TreeView
    {
        public string Name { get; set; }
        public ObservableCollection<TreeView> Children { get; set; }
        IMetadata data;
        private bool wasBuilt;
        private bool isExpanded;

        public TreeView(IMetadata metadata)
        {
            Children = new ObservableCollection<TreeView>();
            Children.Add(null);
            wasBuilt = false;
            data = metadata;
            Name = metadata.MetadataName + " " + metadata.Name;
        }

        public bool IsExpanded
        {
            get { return isExpanded; }
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
                TreeView newtree = new TreeView(i);
                Children.Add(newtree);
            }
        }



    }
}
