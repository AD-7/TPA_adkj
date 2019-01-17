using DTG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSerialization.Model
{
    public class AssemblyDb
    {

        [Key]
      public int AssemblyID { get; set; }
        public string Name { get; set; }

        public string MetadataName { get; set; }


   
        public List<NamespaceDb> SerializableNamespaces { get; set; }

        public AssemblyDb(AssemblyDTG assembly)
        {
            Name = assembly.Name;
            MetadataName = assembly.MetadataName;
            SerializableNamespaces = assembly.Namespaces?.Select(ns => new NamespaceDb(ns)).ToList();

        }

        public AssemblyDb()
        {
        }
    }
}
