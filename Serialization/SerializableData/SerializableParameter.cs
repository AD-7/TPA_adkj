using Data.Metadata_Model;
using System.Runtime.Serialization;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableParameter
    {
        [DataMember(Name = "Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Type_Metadata")]
        public SerializableType Type;

        public SerializableParameter(ParameterMetadata parameter)
        {
            Name = parameter.Name;
            MetadataName = parameter.MetadataName;
            Type = new SerializableType(parameter.Type);
        }
    }
}