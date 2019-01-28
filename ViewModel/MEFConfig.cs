using Reflection.SaveManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using ViewModel.TraceService;

namespace ViewModel
{

    public sealed class MEFConfig : IDisposable
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

        public SaveManager saveManager;
        private CompositionContainer _cont;


        public void GetComp()
        {
            try
            {
                AggregateCatalog catalog = new AggregateCatalog();
                //catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFConfig).Assembly));
                catalog.Catalogs.Add(new DirectoryCatalog(@"../../../Lib", "*.dll"));
              _cont = new CompositionContainer(catalog);


                _cont.ComposeParts(this);

                saveManager = new SaveManager();
                _cont.ComposeParts(saveManager);


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

        public void Dispose()
        {
            _cont?.Dispose();
        }
    }
}



