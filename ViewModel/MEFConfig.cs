using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using ViewModel.TraceService;

namespace ViewModel
{

    public sealed class MEFConfig
    {
        private static readonly MEFConfig instance = new MEFConfig();

        static MEFConfig()
        {

        }
        private MEFConfig()
        {

        }
        public static MEFConfig Instance
        {
            get
            {
                return instance;
            }
        }

        public interface IRepoMeta
        {
            string Name { get; }
        }

        [Import(typeof(ITraceSource))]
        public ITraceSource tracer;

       
       
        public void GetComp()
        {
            try
            {
                AggregateCatalog catalog = new AggregateCatalog();
                //catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFConfig).Assembly));
                catalog.Catalogs.Add(new DirectoryCatalog(@"../../../Lib", "*.dll"));
                CompositionContainer _cont = new CompositionContainer(catalog);


                _cont.ComposeParts(this);



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
         
        }
       
    }
}



