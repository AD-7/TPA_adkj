using Data.Metadata_Model;
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
        //[DataMember(Name = "Types_Name")]
        //public static Dictionary<string, TypeMetadata> allTypes = new Dictionary<string, TypeMetadata>();
        [DataMember(Name = "Namespace_Name")]
        public string namespaceName;
        [DataMember(Name = "Generic_Arguments")]
        public IEnumerable<SerializableType> GenericArguments;
       
        public IEnumerable<MethodMetadata> Methods { get; set; }
      
        public IEnumerable<MethodMetadata> Constructors { get; set; }
        [DataMember(Name = "NestedType")]
        public IEnumerable<SerializableType> NestedTypes { get; set; }
        [DataMember(Name = "Interface")]
        public IEnumerable<SerializableType> Interfaces { get; set; }
      
        public IEnumerable<PropertyMetadata> Properties { get; set; }
 [DataMember(Name = "Method")]
        public IEnumerable<SerializableMethod> SerMethods { get; set; }
  [DataMember(Name = "Constructor")]
        public IEnumerable<SerializableMethod> SerConstructors { get; set; }
  [DataMember(Name = "Propertie")]
        public IEnumerable<SerializableProperty> SerProperties { get; set; }

        public SerializableType(TypeMetadata type)
        {
            if (type != null)
            {
                Name = type.Name;
                MetadataName = type.MetadataName;
                namespaceName = type.namespaceName;
                if (type.GenericArguments != null)
                    GenericArguments = from TypeMetadata t in type.GenericArguments
                                       select new SerializableType(t);
                if (type.NestedTypes != null)
                    NestedTypes = from TypeMetadata t in type.NestedTypes
                              select new SerializableType(t);
                if (type.Interfaces != null)
                    Interfaces = from TypeMetadata t in type.Interfaces
                             select new SerializableType(t);


                if (type.Methods != null)
                    SerMethods = from MethodMetadata m in type.Methods
                             select new SerializableMethod(m);
                if (type.Constructors != null)
                    SerConstructors = from MethodMetadata c in type.Constructors
                                  select new SerializableMethod(c);
                if (type.Properties != null)
                    SerProperties = from PropertyMetadata p in type.Properties
                                select new SerializableProperty(p);
            }

        }
    }
}