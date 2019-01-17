using System;
using DTG;
using DTG_Transfer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection.MapperToDTG;
using Reflection.Metadata_Model;
using Serialization;

namespace SerializationTests
{
    [TestClass]
    public class TestSer
    {
        

       
        [TestMethod]
        public void SerializationTests()
        {
            ISerialization ser = new SerXML();
            Reflector refl = new Reflector();
            refl.Reflect("Reflection.dll");
            AssemblyDTG dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual(tmp.Name,"Reflection.dll");
        }

        [TestMethod]
        public void SerializationTests2()
        {
            ISerialization ser = new SerXML();
            Reflector refl = new Reflector();
            refl.Reflect("Reflection.dll");
            AssemblyDTG dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();
            Assert.AreEqual(tmp.Namespaces.Count, 3);
        }



    }


    

}
