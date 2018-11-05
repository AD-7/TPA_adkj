using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    public class AssemblyMetadata : IMetadata
    {
        public string Name { get; set; }
        public IEnumerable<NamespaceMetadata> Namespaces { get; set; }



        internal AssemblyMetadata(Assembly assembly) 
        {
            Name = assembly.ManifestModule.Name;
            Namespaces = from Type _type in assembly.GetTypes()
                         where _type.GetVisible()
                         group _type by _type.GetNamespace() into _group
                         orderby _group.Key
                         select new NamespaceMetadata(_group.Key, _group);
        }


        public ObservableCollection<Tuple<string, IMetadata>> getChildren
        {

            get
            {
                Tuple<string, IMetadata> metadata;
                ObservableCollection<Tuple<string, IMetadata>> children = new ObservableCollection<Tuple<string, IMetadata>>();
                foreach (IMetadata i in Namespaces)
                {
                    metadata = new Tuple<string, IMetadata>("Namespace: ", i);
                    children.Add(metadata);
                }
                return children;
            }
        }

      
    }
}
