using DTG;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
    public class PropertyMetadata : IMetadata
    {

        public string Name { get; private set; }
    
        public string MetadataName { get; set; }
   
        public TypeMetadata Type;

        public PropertyMetadata(string Name, TypeMetadata type)
        {
            this.Name = Name;
            MetadataName = "Property: ";
            Type = type;
        }

        public PropertyMetadata(string Name,string Metadataname)
        {
            this.Name=Name;
            this.MetadataName = Metadataname;
        }

       public PropertyMetadata(PropertyDTG property)
        {
            Name = property.Name;
            MetadataName = property.MetadataName;
            Type = TypeMetadata.AddType(property.SerType);
        }
    }
}