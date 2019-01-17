﻿using System;
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
            ser = new DbSerialization();
            refl = new Reflector();
            refl.Reflect("Reflection.dll");
            dtg = MapperToDTG.AssemblyDtg(refl.AssemblyModel);

        }


        [TestMethod]
        public void CheckAssemblyNameAfterDeserialization()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();
            Assert.AreEqual(tmp.Name, "Reflection.dll");
        }

        [TestMethod]
        public void CheckNumberOfNamespaces()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();
            Assert.AreEqual(tmp.Namespaces.Count, 3);
        }

        [TestMethod]
        public void CheckNamespaceName()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual("Reflection.SaveManager", tmp.Namespaces[0].Name);
            Assert.AreEqual("Reflection.Metadata_Model", tmp.Namespaces[1].Name);
            Assert.AreEqual("Reflection.MapperToDTG", tmp.Namespaces[2].Name);
        }

        [TestMethod]
        public void CheckFirstMethodName()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual("get_Name", tmp.Namespaces[0].Types[0].SerMethods[0].Name);
        }


        [TestMethod]
        public void CheckFirstPropertieName()
        {
            ser.Serialize(dtg);
            AssemblyDTG tmp = ser.Deserialize();

            Assert.AreEqual("Name", tmp.Namespaces[0].Types[0].SerProperties[0].Name);
        }




    }
}