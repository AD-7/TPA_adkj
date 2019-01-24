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
    
        [Import(typeof(ISerialization))]
        public ISerialization serializer;
        

        public void Save(AssemblyMetadata assemblyModel)
        {
         
            AssemblyDTG assemblyDTG = MapperToDTG.MapperToDTG.AssemblyDtg(assemblyModel);
            serializer.Serialize(assemblyDTG);
        }


        public AssemblyMetadata Load( )
        {
        
            AssemblyDTG assemblyDTG = serializer.Deserialize();
            AssemblyMetadata assemblyModel = new AssemblyMetadata(assemblyDTG);
            return assemblyModel;
        }

  

      

    }
}
