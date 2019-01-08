
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
 
    public class NamespaceMetadata : IMetadata
    {
     
        public string Name { get; set; }
 
        public string MetadataName { get;  set; }
       
        public IEnumerable<TypeMetadata> Types { get; set; }
       
        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            Name = name;
            MetadataName = " Namespace: ";
            Types = from type in types orderby type.Name select new TypeMetadata(type,"Type: ");
        }



        public NamespaceMetadata(string name, string metadataName)
        {
            Name = name;
            MetadataName =metadataName;
           
        }
       


    }
}
