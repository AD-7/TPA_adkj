using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace Data.Serialization
{
    public static class SerXML
    {
        public static void Serialize(Reflector reflcetor, string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            DataContractSerializer SerializerObj = new DataContractSerializer(typeof(Reflector), null, 0x7FFF,  false, true, null);

            SerializerObj.WriteObject(file, reflcetor);
            file.Close();
        }

        public static Reflector Deserialize(string fileName)
        {
            DataContractSerializer SerializerObj = new DataContractSerializer(typeof(Reflector), null, 0x7FFF, false, true, null);

            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            Reflector reflector = (Reflector)SerializerObj.ReadObject(file);
            file.Close();
            return reflector;
        }



    }
}
