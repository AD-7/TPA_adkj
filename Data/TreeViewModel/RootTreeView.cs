using Data.Metadata_Model;
using System.Collections.ObjectModel;

namespace Data.TreeViewModel
{
    public class RootTreeView :TreeViewBase
    {
        

        public RootTreeView(IMetadata metadata) : base(metadata)
        {
            Children = new ObservableCollection<RootTreeView>();
            Children.Add(null);


        }

        private bool wasBuilt;
        private bool isExpanded;
        public ObservableCollection<RootTreeView> Children { get; set; }
        public virtual string Name { get { return base.Name; } set { base.Name = value; } }

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                if (wasBuilt)
                    return;
                Children.Clear();
              buildMyself(this);
                wasBuilt = true;
            }
        }
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
