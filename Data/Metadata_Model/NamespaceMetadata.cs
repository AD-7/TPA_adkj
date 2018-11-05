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
        public IEnumerable<TypeMetadata> Types { get; set; }

        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            Name = name;
            Types = from type in types orderby type.Name select new TypeMetadata(type);
        }

        public ObservableCollection<Tuple<string,IMetadata>> getChildren
        {
            get
            {
                Tuple<string, IMetadata> metadata;
                ObservableCollection<Tuple<string, IMetadata>> children = new ObservableCollection<Tuple<string, IMetadata>>();
                foreach (IMetadata i in Types)
                {
                    metadata = new Tuple<string, IMetadata>("Type: ", i);
                    children.Add(metadata);
                }
                return children;
            }
        }



    }
}
