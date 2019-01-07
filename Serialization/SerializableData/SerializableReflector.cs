using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.SerializableData
{
    [DataContract(IsReference = true)]
    public class SerializableReflector
    {
        
        public AssemblyMetadata assembly { get; private set; }
[DataMember(Name = "Assembly_Model")]
        public SerializableAssembly SerializableAssembly { get; private set; }

        public SerializableReflector(Reflector refl)
        {
            assembly = refl.AssemblyModel;
            SerializableAssembly = new SerializableAssembly(refl.AssemblyModel);
        }

    }
}
