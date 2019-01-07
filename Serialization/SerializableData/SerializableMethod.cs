using Data.Metadata_Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableMethod
    {
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Method_Name")]
        public string Name { get; set; }
        [DataMember(Name = "Return_Type")]
        public SerializableType ReturnType;
    
        public IEnumerable<ParameterMetadata> Parameters;
    [DataMember(Name = "Parameters")]
        public IEnumerable<SerializableParameter> SerParameters;

        public SerializableMethod(MethodMetadata method)
        {
            Name = method.Name;
            MetadataName = method.MetadataName;
            ReturnType = new SerializableType( method.ReturnType);
            Parameters = method.Parameters;

            SerParameters = from ParameterMetadata p in method.Parameters
                            select new SerializableParameter(p);
        }
    }
}