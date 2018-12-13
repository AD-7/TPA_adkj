using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    [DataContract(IsReference = true)]
    public class NamespaceMetadata : TreeViewBase,IMetadata
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get;  set; }
        [DataMember(Name = "Type")]
        public IEnumerable<TypeMetadata> Types { get; set; }

        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            Name = name;
            MetadataName = " Namespace: ";
            Types = from type in types orderby type.Name select new TypeMetadata(type,"Type: ");
        }

        public override ObservableCollection<IMetadata> getChildren()
        {
            
        
                ObservableCollection< IMetadata> children = new ObservableCollection<IMetadata>();
                foreach (IMetadata i in Types)
                {
                    
                    children.Add(i);
                }
                return children;
            
        }



    }
}
