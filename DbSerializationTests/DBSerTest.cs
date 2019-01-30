using System;
using System.IO;
using DatabaseSerialization;
using DTG;
using DTG_Transfer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection.MapperToDTG;
using Reflection.Metadata_Model;

namespace DbSerializationTests
{
    [TestClass]
    public class DBSerTest
    {
        ISerialization ser;
        Reflector refl;
        AssemblyDTG dtg;
        [TestInitialize]
        public void Init()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));

            ser = new DbSerialization();
            refl = new Reflector();
            refl.Reflect("../../dllForTests/TPA.ApplicationArchitecture.dll");
            dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

        }


        [TestMethod]
        public void CheckAssemblyNameAfterDeserialization()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();
            Assert.AreEqual(tmp.Name, "TPA.ApplicationArchitecture.dll");
        }

        [TestMethod]
        public void CheckNumberOfNamespaces()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();
            Assert.AreEqual(tmp.Namespaces.Count, 4);
        }

        [TestMethod]
        public void CheckNamespaceName()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual("TPA.ApplicationArchitecture.Presentation", tmp.Namespaces[0].Name);
            Assert.AreEqual("TPA.ApplicationArchitecture.Data.CircularReference", tmp.Namespaces[1].Name);
            Assert.AreEqual("TPA.ApplicationArchitecture.Data", tmp.Namespaces[2].Name);
            Assert.AreEqual("TPA.ApplicationArchitecture.BusinessLogic", tmp.Namespaces[3].Name);
        }

        [TestMethod]
        public void CheckFirstMethodName()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual("ToString", tmp.Namespaces[0].Types[0].SerMethods[0].Name);
        }


        [TestMethod]
        public void CheckNumberOfMethodsInFirstType()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual(4, tmp.Namespaces[0].Types[0].SerMethods.ToArray().Length);
        }




    }
}