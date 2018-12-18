using Data.Metadata_Model;
using Interfaces;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;

namespace Serialization
{
    [Export(typeof(ISerialization))]
    [ExportMetadata("Name","File")]
    public   class SerXML :ISerialization
    {
        public   void Serialize(Reflector reflcetor, string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            DataContractSerializer SerializerObj = new DataContractSerializer(typeof(Reflector), null, 0x7FFF,  false, true, null);

            SerializerObj.WriteObject(file, reflcetor);
            file.Close();
        }

        public  Reflector Deserialize(string fileName)
        {
            DataContractSerializer SerializerObj = new DataContractSerializer(typeof(Reflector), null, 0x7FFF, false, true, null);

            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            Reflector reflector = (Reflector)SerializerObj.ReadObject(file);
            file.Close();
            return reflector;
        }



    }
}
