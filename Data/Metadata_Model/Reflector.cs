using System.Reflection;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
    [DataContract(IsReference = true)]
    public class Reflector
    {
        [DataMember(Name = "Assembly_Model")]
        public AssemblyMetadata AssemblyModel { get; private set; }


     
        public void Reflect(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            AssemblyModel = new AssemblyMetadata(assembly);
        }






    }
}
