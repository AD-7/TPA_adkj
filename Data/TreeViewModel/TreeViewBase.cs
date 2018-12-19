
using Data.Metadata_Model;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Data.TreeViewModel
{
    [DataContract(IsReference =true)]
    public class TreeViewBase
    {
       public TreeViewBase(IMetadata metadata)
        {
            data = metadata;
            Name = metadata.MetadataName + " " + metadata.Name;
          
        }
        public TreeViewBase()
        {

        }

        protected ObservableCollection<IMetadata> getChildren() { return null; }
        protected string Name { get; set; }
        protected IMetadata data;
      
    }
}
