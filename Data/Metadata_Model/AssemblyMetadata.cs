
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
        public AssemblyMetadata(Assembly assembly) 
        {
            Name = assembly.ManifestModule.Name;
            MetadataName = "Assembly: ";

            Namespaces = assembly
                    .GetTypes()?
                    .GroupBy(t => t.Namespace)
                    .OrderBy(grouping => grouping.Key)
                    .Select(t => new NamespaceMetadata(t.Key, t.ToList()))
                    .ToList();
                    }

        public AssemblyMetadata(AssemblyDTG assembly)
        {
            Name = assembly.Name;
            MetadataName = assembly.MetadataName;
            Namespaces = assembly.Namespaces?.Select(n => new NamespaceMetadata(n)).ToList();
        }
      

        
    }
}
