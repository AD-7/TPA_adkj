using Data.Metadata_Model;
using Data.Tracing;
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


        public void Reflect(string path,MyTraceSource tracer)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            AssemblyModel = new AssemblyMetadata(assembly);
            tracer.TraceData(System.Diagnostics.TraceEventType.Information, "Odczyt metadanych.");
        }

      




    }
}
