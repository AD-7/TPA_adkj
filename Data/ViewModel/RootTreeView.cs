using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class RootTreeView
    {
        

        public RootTreeView(IMetadata metadata)
        {
            Children = new ObservableCollection<RootTreeView>();
            Children.Add(null);
            data = metadata;
            Name = metadata.MetadataName + " " + metadata.Name; ;
        }

        public string Name { get; set; }
        public ObservableCollection<RootTreeView> Children { get; set; }
        private bool wasBuilt;
        private bool isExpanded;
        public IMetadata data;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                if (wasBuilt)
                    return;
                Children.Clear();
               TreeViewBase.buildMyself(this);
                wasBuilt = true;
            }
        }

       
    }
}
