using System.Reflection;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{

    public class Reflector
    {
     
        public AssemblyMetadata AssemblyModel { get;  set; }
     

        public void Reflect(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);     
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
