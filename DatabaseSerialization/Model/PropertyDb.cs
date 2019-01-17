using DTG;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSerialization.Model
{
    public class PropertyDb
    {

        [Key]
        public int PropertyID { get; set; }
        public string Name { get; private set; }
        public string MetadataName { get; set; }
        public TypeDb SerType;

        public PropertyDb(PropertyDTG property)
        {
            Name = property.Name;
            MetadataName = property.MetadataName;
            SerType = TypeDb.LoadType(property.SerType);
        }

        public PropertyDb()
        {
        }
    }
}