using Data.Metadata_Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableMethod
    {
        [DataMember(Name = "MetadataName")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Method_Name")]
        public string Name { get; set; }
        [DataMember(Name = "Return_Type")]
        public SerializableType SerReturnType;
   
    [DataMember(Name = "Parameters")]
        public IEnumerable<SerializableParameter> SerParameters;

        public SerializableMethod(MethodMetadata method)
        {
            Name = method.Name;
            MetadataName = method.MetadataName;
            SerReturnType = new SerializableType( method.ReturnType);
           

            SerParameters = from ParameterMetadata p in method.Parameters
                            select new SerializableParameter(p);
        }
    }
}