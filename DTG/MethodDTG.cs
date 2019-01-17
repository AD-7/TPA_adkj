using System.Collections.Generic;

namespace DTG
{
    public class MethodDTG
    {
        public string Name { get; set; }
        public string MetadataName { get; set; }
        public TypeDTG SerReturnType {get; set;}
        public List<ParameterDTG> SerParameters { get; set; }
    }
}