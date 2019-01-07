using Data.Metadata_Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableNamespace
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
       
        public IEnumerable<TypeMetadata> Types { get; set; }
    [DataMember(Name = "Type")]
        public IEnumerable<SerializableType> SerializableTypes { get; set; }

        public SerializableNamespace(NamespaceMetadata namespacee)
        {
            Name = namespacee.Name;
            MetadataName = namespacee.MetadataName;
            Types = namespacee.Types;
            SerializableTypes = 
                from TypeMetadata t in namespacee.Types
                
                    select new SerializableType(t);

        }
    }
}