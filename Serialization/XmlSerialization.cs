using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serialization
{
    public static class XmlSerialization
    {
        public static void Serialize(Reflector reflcetor, string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            XmlSerializer ser = new XmlSerializer(typeof(Reflector));
            TextWriter writer = new StreamWriter(fileName);
            ser.Serialize(writer, reflcetor);


            //DataContractSerializer SerializerObj = new DataContractSerializer(typeof(Reflector), null,
            //                                                      0x7FFF /*maxItemsInObjectGraph*/,
            //                                                      false /*ignoreExtensionDataObject*/,
            //                                                      true /*preserveObjectReferences : this is where the magic happens */,
            //                                                      null /*dataContractSurrogate*/);

            //SerializerObj.WriteObject(file, reflcetor);
        }

    }

}

