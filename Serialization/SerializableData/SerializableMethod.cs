using DTG;
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
        public List<SerializableParameter> SerParameters;

        public SerializableMethod(MethodDTG method)
        {
            Name = method.Name;
            MetadataName = method.MetadataName;
            if(method.SerReturnType != null)
            SerReturnType =  SerializableType.LoadType( method.SerReturnType);


            SerParameters = method.SerParameters?.Select(p => new SerializableParameter(p)).ToList();
        }
    }
}