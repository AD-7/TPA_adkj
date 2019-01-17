
using DTG;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Reflection.Metadata_Model
{

    public class AssemblyMetadata : IMetadata
    {
    
        public string Name { get; set; }
      
        public string MetadataName { get; set; }
  
        public List<NamespaceMetadata> Namespaces { get; set; }

        public AssemblyMetadata()
        {

        }
        public AssemblyMetadata(string Name, string MetadataName)
        {
            this.Name = Name;
            this.MetadataName = MetadataName;
        }
        internal AssemblyMetadata(Assembly assembly) 
        {
            Name = assembly.ManifestModule.Name;
            MetadataName = "Assembly: ";
            
            Namespaces = (from Type _type in assembly.GetTypes()
                         where _type.GetVisible()
                         group _type by _type.GetNamespace() into _group
                         orderby _group.Key
                         select new NamespaceMetadata(_group.Key, _group)).ToList();
        }

        public AssemblyMetadata(AssemblyDTG assembly)
        {
            Name = assembly.Name;
            MetadataName = assembly.MetadataName;
            Namespaces = assembly.Namespaces?.Select(n => new NamespaceMetadata(n)).ToList();
        }
      

        
    }
}
