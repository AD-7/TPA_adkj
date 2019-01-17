
using DTG;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Reflection.Metadata_Model
{
 
    public class NamespaceMetadata : IMetadata
    {
     
        public string Name { get; set; }
 
        public string MetadataName { get;  set; }
       
        public List<TypeMetadata> Types { get; set; }
       
        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            Name = name;
            MetadataName = " Namespace: ";
            Types = types.OrderBy(t => t.Name)
                    .Select(t => TypeMetadata.LoadType(t)).ToList();
        }



        public NamespaceMetadata(string name, string metadataName)
        {
            Name = name;
            MetadataName =metadataName;
           
        }
       
        public NamespaceMetadata(NamespaceDTG namespacee)
        {
            Name = namespacee.Name;
            MetadataName = namespacee.MetadataName;
            Types = namespacee.Types?.Select(t => TypeMetadata.LoadType(t)).ToList();
        }


    }
}
