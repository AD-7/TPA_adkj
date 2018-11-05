using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    public class AssemblyMetadata
    {
        public string Name { get; set; }






        internal AssemblyMetadata(Assembly assembly) 
        {
            Name = assembly.ManifestModule.Name;

        }
    }
}
