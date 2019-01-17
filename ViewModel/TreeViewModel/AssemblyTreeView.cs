using Reflection.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.TreeViewModel
{
    public class AssemblyTreeView : TreeViewBase
    {
        public AssemblyMetadata AssemblyMetadata { get; }

        public AssemblyTreeView (AssemblyMetadata metadata)
        {
            AssemblyMetadata = metadata;
            Name = metadata.MetadataName + ": " +  metadata.Name;
        }



        protected override void buildMyself()
        {
           if(AssemblyMetadata.Namespaces != null)
            {
                 foreach (NamespaceMetadata i in AssemblyMetadata.Namespaces)
                   {
                
                      Children.Add(new NamespaceTreeView(i));
                  }
            }
           
             
        }
    }
}
