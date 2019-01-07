using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.SerializableData

{
    [DataContract(IsReference = true)]
    public class SerializableAssembly
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
       
        public IEnumerable<NamespaceMetadata> Namespaces { get; set; }
 [DataMember(Name = "NamespaceList")]
        public IEnumerable<SerializableNamespace> SerializableNamespaces { get; set; }

        public SerializableAssembly(AssemblyMetadata assembly)
        {
            Name = assembly.Name;
            MetadataName = assembly.MetadataName;
            Namespaces = assembly.Namespaces;
            SerializableNamespaces = from NamespaceMetadata n in assembly.Namespaces
                         select new SerializableNamespace(n);

        }


    }
}