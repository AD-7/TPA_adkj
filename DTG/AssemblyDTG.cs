using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTG
{
    public class AssemblyDTG
    {
        public string Name { get; set; }
        public string MetadataName { get; set; }
        public List<NamespaceDTG> Namespaces {get; set;}

    }
}
