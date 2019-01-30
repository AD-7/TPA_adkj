using DTG;
using DTG_Transfer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection.MapperToDTG;
using Reflection.Metadata_Model;
using Serialization;
using System.IO;

namespace ReflectionTests
{
    [TestClass]
    public class SerializationTest
    {
        ISerialization ser;
        Reflector refl;
        AssemblyDTG dtg;

        [TestInitialize]
        public void Init()
        {
            ser = new SerXML();
            refl = new Reflector();
            refl.Reflect("../../dllForTests/TPA.ApplicationArchitecture.dll");
            dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

        }

        [TestMethod]
        public void SerTest1()
        {
            ser.Serialize(dtg);
            Assert.IsTrue(File.Exists("fileSave.xml") == true);
        }


        [TestMethod]
        public void SerTest2()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual(tmp.Name, "TPA.ApplicationArchitecture.dll");
        }

        [TestMethod]
        public void SerTest3()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();
            Assert.AreEqual(tmp.Namespaces.Count, 4);
        }

    }
}
