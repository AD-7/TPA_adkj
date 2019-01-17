using DTG;
using System.Runtime.Serialization;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableProperty
    {
        [DataMember(Name = "Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Type_Metadata")]
        public SerializableType SerType;

        public SerializableProperty(PropertyDTG property)
        {
            Name = property.Name;
            MetadataName = property.MetadataName;
           SerType = SerializableType.LoadType(property.SerType);
        }
    }
}