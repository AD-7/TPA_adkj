using Data;
using Data.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsData
{
    [TestClass]
   public  class SerializationTests
    {

        private Reflector refl;

        [TestInitialize]
        public void Init()
        {
            this.refl = new Reflector();
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
