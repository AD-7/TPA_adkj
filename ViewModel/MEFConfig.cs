using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trace;

namespace ViewModel
{
    public class MEFConfig
    {
        public interface IRepoMeta
        {
            string Name { get; }
        }

        [ImportMany(typeof(ITraceSource))]
        public IEnumerable<Lazy<ITraceSource,IRepoMeta>> trace;

        [ImportMany(typeof(ISerialization))]
        public IEnumerable<Lazy<ISerialization,IRepoMeta>> ser;

        public ISerialization serializer;
        public ITraceSource tracer;
        public string kindOfTrace = "File";
        public string kindOfSerialize = "File";

        public void GetComponents(string file)
        {
            try
            {
                var catalog = new AggregateCatalog();
               catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFConfig).Assembly));
                 catalog.Catalogs.Add(new DirectoryCatalog(file,"*.dll"));
                CompositionContainer _cont = new CompositionContainer(catalog);


                _cont.ComposeParts(this);

               
                tracer = trace.Where(x => x.Metadata.Name == kindOfTrace)
                    .Select(x=>x.Value).First();
                serializer = ser.Where(x => x.Metadata.Name ==kindOfSerialize)
                   .Select(x => x.Value).First();

            }
            catch(FileNotFoundException)
            {

            }
            catch (CompositionException)
            {

            }
            catch (DirectoryNotFoundException)
            {

            }

        }

    }
}
