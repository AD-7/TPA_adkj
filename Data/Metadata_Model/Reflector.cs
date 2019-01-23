using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace Reflection.Metadata_Model
{

    public class Reflector
    {
     
        public AssemblyMetadata AssemblyModel { get;  set; }
     

        public void Reflect(string path)
        {
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(path);

            foreach (var assemblyName in assembly.GetReferencedAssemblies())
            {
                try
                {
                    Assembly.ReflectionOnlyLoad(assemblyName.FullName);
                }
                catch
                {
                    Assembly.ReflectionOnlyLoadFrom(Path.Combine(Path.GetDirectoryName(path), assemblyName.Name + ".dll"));
                }
            }
            AssemblyModel = new AssemblyMetadata(assembly);
        }

        public void Reflect(Assembly assembly)
        {
            AssemblyModel = new AssemblyMetadata(assembly);
        }
        public Reflector()
        {

        }
        public Reflector(string Name, string MetadataName)
        {
            AssemblyModel = new AssemblyMetadata(Name, MetadataName);
        }
      
        

    }
}
