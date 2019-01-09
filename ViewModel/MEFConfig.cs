using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace ViewModel
{
    public static class MEFConfig
    {
        public interface IRepoMeta
        {
            string Name { get; }
        }

        


    [ImportMany(typeof(ITraceSource))]
    public static IEnumerable<Lazy<ITraceSource, IRepoMeta>> trace;

    [ImportMany(typeof(ISerialization))]
    public static IEnumerable<Lazy<ISerialization, IRepoMeta>> ser;

    public static ISerialization serializer;
    public static ITraceSource tracer;
    public static string kindOfTrace = "File";
    public static string kindOfSerialize = "File";

    public static ITraceSource GetComponents(string file)
    {
        try
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFConfig).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(file, "*.dll"));
            CompositionContainer _cont = new CompositionContainer(catalog);


            _cont.ComposeParts();


            tracer = trace.Where(x => x.Metadata.Name == kindOfTrace)
                .Select(x => x.Value).First();
            serializer = ser.Where(x => x.Metadata.Name == kindOfSerialize)
               .Select(x => x.Value).First();
                return tracer;
        }
        catch (FileNotFoundException)
        {

        }
        catch (CompositionException)
        {

        }
        catch (DirectoryNotFoundException)
        {

        }
            return null;
    }
   }
}



