using System.Runtime.Serialization;

namespace Data.Metadata_Model
{

    public class ParameterMetadata :IMetadata
    {

        public string Name { get; private set; }
    
        public string MetadataName { get; set; }
    
        public TypeMetadata Type;

        public ParameterMetadata(string name, TypeMetadata type)
        {
            Name = name;
            MetadataName = "Parameter: ";
            Type = type;
        }

     
    }
}