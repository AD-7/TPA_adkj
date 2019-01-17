using DTG;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DatabaseSerialization.Model
{
    public class NamespaceDb
    {

        [Key]
      public int NamespaceID { get; set; }
        public string Name { get; set; }
   
        public string MetadataName { get; set; }


        
        public List<TypeDb> SerializableTypes { get; set; }

        public NamespaceDb(NamespaceDTG namespacee)
        {
            Name = namespacee.Name;
            MetadataName = namespacee.MetadataName;
            SerializableTypes = namespacee.Types?.Select(TypeDb.LoadType).ToList();

        }

        public NamespaceDb()
        {
        }
    }
}