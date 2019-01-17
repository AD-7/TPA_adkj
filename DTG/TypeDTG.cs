using System.Collections.Generic;

namespace DTG
{
    public class TypeDTG
    {
        public string Name { get; set; }
        public string MetadataName { get; set; }
        public string SernamespaceName {get; set; }
        public List<TypeDTG> GenericArguments { get; set; }
        public List<TypeDTG> NestedTypes { get; set; }
        public List<TypeDTG> Interfaces { get; set; }
        public List<MethodDTG> SerMethods { get; set; }
        public List<MethodDTG> SerConstructors { get; set; }
        public List<PropertyDTG> SerProperties { get; set; }
        public Dictionary<string, TypeDTG> allTypes { get; set; }

    }
}