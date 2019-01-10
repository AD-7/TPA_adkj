using Data.Metadata_Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Tests
{
    [TestClass()]
    public class SerXMLTests
    {
        private Reflector refl;
        private SerXML SerXML;

        [TestInitialize]
        public void Init()
        {
            this.refl = new Reflector();
            this.SerXML = new SerXML();
            refl.Reflect("Data.dll");
        }

        [TestMethod]
        public void SerializationTest()
        {
            SerXML.Serialize(refl, "SerializationTest.txt");

            Assert.IsTrue(File.Exists("SerializationTest.txt"));
        }

        [TestMethod]
        public void DeserializationTest()
        {
            SerXML.Serialize(refl, "SerializationTest2.txt");
            Reflector refl2 = null;
            refl2 = SerXML.Deserialize("SerializationTest2.txt");
            Assert.AreEqual("Data.dll", refl2.AssemblyModel.Name);

        }

    }
}
