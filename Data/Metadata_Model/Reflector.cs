using System.Reflection;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
  
    public class Reflector
    {

        public AssemblyMetadata AssemblyModel { get; private set; }

 
        public void Reflect(string path)
        {
             Assembly  assembly = Assembly.ReflectionOnlyLoadFrom(path);
            AssemblyModel = new AssemblyMetadata(assembly);
        }






    }
}
