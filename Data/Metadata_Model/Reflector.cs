using System.Reflection;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{

    public class Reflector
    {
        public Assembly assembly {get; set;}
        public AssemblyMetadata AssemblyModel { get; private set; }
        public string Path;

        public void Reflect(string path)
        {
            Path = path;
             assembly = Assembly.ReflectionOnlyLoadFrom(Path);     
            AssemblyModel = new AssemblyMetadata(assembly);
        }

        public void Reflect(Assembly assembly)
        {
            AssemblyModel = new AssemblyMetadata(assembly);
        }

      


    }
}
