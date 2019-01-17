using DTG;
using DTG_Transfer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection.MapperToDTG;
using Reflection.Metadata_Model;
using Serialization;
using System.IO;

namespace UnitTestsData
{
    [TestClass]
    public class SerializationTest
    {
        ISerialization ser;
        Reflector refl;

        [TestInitialize]
        public void Init()
        {
            ser = new SerXML();
            refl = new Reflector();
            refl.Reflect("Reflection.dll");
            
        }

        [TestMethod]
        public void SerTest1()
        {
            AssemblyDTG dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

            ser.Serialize(dtg, "path");
            Assert.IsTrue(File.Exists("path.xml") == true);        
        }







    }
}
