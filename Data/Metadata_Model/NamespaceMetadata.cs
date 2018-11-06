using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    public class NamespaceMetadata : IMetadata
    {
        public string Name { get; set; }
        public string MetadataName { get; private set; }
        public IEnumerable<TypeMetadata> Types { get; set; }

        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            Name = name;
            MetadataName = " Namespace: ";
            Types = from type in types orderby type.Name select  TypeMetadata.AddType(type);
        }

        public ObservableCollection<IMetadata> getChildren
        {
            get
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
}
