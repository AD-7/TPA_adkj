using Reflection.Metadata_Model;
using DTG;
using DTG_Transfer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Reflection.SaveManager
{
    public class SaveManager
    {
    
        [ImportMany(typeof(ISerialization))]
        public IEnumerable<Lazy<ISerialization, IRepoMeta>> ser;
        public  ISerialization serializer;

        public void Save(AssemblyMetadata assemblyModel, string kindOfSerialize)
        {
            serializer = ser.Where(x => x.Metadata.Name == kindOfSerialize)
                 .Select(x => x.Value).First();
            AssemblyDTG assemblyDTG = MapperToDTG.MapperToDTG.AssemblyDtg(assemblyModel);
            serializer.Serialize(assemblyDTG);
        }


        public AssemblyMetadata Load( string kindOfSerialize)
        {
            serializer = ser.Where(x => x.Metadata.Name == kindOfSerialize)
                 .Select(x => x.Value).First();
            AssemblyDTG assemblyDTG = serializer.Deserialize();
            AssemblyMetadata assemblyModel = new AssemblyMetadata(assemblyDTG);
            return assemblyModel;
        }

        public static SaveManager GetSaveManager()
        {
            SaveManager sm = new SaveManager();

            AggregateCatalog catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(SaveManager).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../Lib", "*.dll"));
            CompositionContainer _cont = new CompositionContainer(catalog);


            _cont.ComposeParts(sm);
           

            return sm;
        }

        public interface IRepoMeta
        {
            string Name { get; }
        }

    }
}
