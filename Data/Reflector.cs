using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Reflector
    {
        
        public AssemblyMetadata AssemblyModel { get; private set; }


        public void Reflect(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            AssemblyModel = new AssemblyMetadata(assembly);    
        }





    }
}
