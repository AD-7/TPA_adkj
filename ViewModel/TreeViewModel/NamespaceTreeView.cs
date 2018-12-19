using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.TreeViewModel
{
    public class NamespaceTreeView : TreeViewBase
    {

        public NamespaceMetadata NamespaceMetadata { get; }
        public NamespaceTreeView(NamespaceMetadata metadata)
        {
            NamespaceMetadata = metadata;
            Name = metadata.MetadataName + ": " + metadata.Name;
        }



        protected override void buildMyself()
        {
            if(NamespaceMetadata.Types != null)
            {
                    foreach(TypeMetadata i in NamespaceMetadata.Types)
                 {
                      Children.Add(new TypeTreeView(i));
                 }
            }
          
        }
    }
}
