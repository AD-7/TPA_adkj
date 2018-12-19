
using Data.Metadata_Model;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ViewModel.TreeViewModel
{
  
    public abstract class TreeViewBase
    {
       protected TreeViewBase()
        {
            Children = new ObservableCollection<TreeViewBase>() { null };
            wasBuilt = false;
        }
        private bool wasBuilt;
        private bool isExpanded;
        public ObservableCollection<TreeViewBase> Children { get;  }
        public string Name { get; set; }
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

        protected abstract void buildMyself();



    }
}
