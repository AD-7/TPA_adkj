using DTG;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Serialization.SerializableData

{
    [DataContract(IsReference = true)]
    public class SerializableAssembly
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
       
       
        [DataMember(Name = "NamespaceList")]
        public List<SerializableNamespace> SerializableNamespaces { get; set; }

        public SerializableAssembly(AssemblyDTG assembly)
        {
            Name = assembly.Name;
            MetadataName = assembly.MetadataName;
            SerializableNamespaces = assembly.Namespaces?.Select(ns => new SerializableNamespace(ns)).ToList(); 

        }


      


    }
}