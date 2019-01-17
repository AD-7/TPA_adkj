using System;
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
            ser = new DbSerialization();
            refl = new Reflector();
            refl.Reflect("Reflection.dll");
            dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
