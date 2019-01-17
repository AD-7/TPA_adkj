using DTG;
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
       
   
    [DataMember(Name = "Type")]
        public List<SerializableType> SerializableTypes { get; set; }

        public SerializableNamespace(NamespaceDTG namespacee)
        {
            Name = namespacee.Name;
            MetadataName = namespacee.MetadataName;
            SerializableTypes = namespacee.Types?.Select(SerializableType.LoadType).ToList();

        }


      
  

    }
}