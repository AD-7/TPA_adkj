using Data.Metadata_Model;
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
        public SerializableType Type;

        public SerializableProperty(PropertyMetadata property)
        {
            Name = property.Name;
            MetadataName = property.MetadataName;
            Type = new SerializableType(property.Type);
        }
    }
}