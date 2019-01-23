using DTG;
using DTG_Transfer.Service;
using Serialization.SerializableData;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;

namespace Serialization
{
    [Export(typeof(ISerialization))]
    [ExportMetadata("Name","File")]
    public   class SerXML :ISerialization
    {
        public void Serialize(AssemblyDTG assembly)
        {
            string fileName = "fileSave.xml";
            SerializableAssembly serRefl = new SerializableAssembly(assembly); 
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            DataContractSerializer SerializerObj = new DataContractSerializer(typeof(SerializableAssembly), null, int.MaxValue,  false, true, null);

            SerializerObj.WriteObject(file, serRefl);
            file.Close();
        }

        public  AssemblyDTG Deserialize()
        {
           string fileName = "fileSave.xml";
            DataContractSerializer SerializerObj = new DataContractSerializer(typeof(SerializableAssembly), null, int.MaxValue, false, true, null);

            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            SerializableAssembly assembly = (SerializableAssembly)SerializerObj.ReadObject(file);

            AssemblyDTG assemblyDTG = MapperXml.AssemblyDtg(assembly);

           

            file.Close();
            return assemblyDTG;
        }



    }
}
