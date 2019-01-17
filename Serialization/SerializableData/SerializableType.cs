using DTG;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableType
    {
        
        [DataMember(Name = "Type_Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Types_Name")]
        public  Dictionary<string, SerializableType> allTypes = new Dictionary<string, SerializableType>();
        [DataMember(Name = "Namespace_Name")]
        public string SernamespaceName;
        [DataMember(Name = "Generic_Arguments")]
        public List<SerializableType> GenericArguments;
       
       
      
        
        [DataMember(Name = "NestedType")]
        public List<SerializableType> NestedTypes { get; set; }
        [DataMember(Name = "Interface")]
        public List<SerializableType> Interfaces { get; set; }
      
       
 [DataMember(Name = "Method")]
        public List<SerializableMethod> SerMethods { get; set; }
  [DataMember(Name = "Constructor")]
        public List<SerializableMethod> SerConstructors { get; set; }
  [DataMember(Name = "Propertie")]
        public List<SerializableProperty> SerProperties { get; set; }

        public SerializableType(TypeDTG type)
        {
            DictionaryOfTypes.Instance.RegisterType(type.Name, this);
        
                Name = type.Name;
                MetadataName = type.MetadataName;
            SernamespaceName = type.SernamespaceName;
                if (type.GenericArguments != null)
                    GenericArguments = type.GenericArguments?.Select(t => SerializableType.LoadType(t)).ToList();
                if (type.NestedTypes != null)
                    NestedTypes = type.NestedTypes?.Select(nt => SerializableType.LoadType(nt)).ToList();
                if (type.Interfaces != null)
                    Interfaces = type.Interfaces?.Select(i => SerializableType.LoadType(i)).ToList();


                if (type.SerMethods != null)
                    SerMethods = type.SerMethods?.Select(m => new SerializableMethod(m)).ToList();
                if (type.SerConstructors != null)
                    SerConstructors = type.SerConstructors?.Select(c => new SerializableMethod(c)).ToList();
                if (type.SerProperties != null)
                    SerProperties = type.SerProperties?.Select(p => new SerializableProperty(p)).ToList();
                

            

        }

        public static SerializableType LoadType(TypeDTG type)
        {
            if (type == null) return null;
            return DictionaryOfTypes.Instance.GetType(type.Name) ?? new SerializableType(type);
        }
    }
}