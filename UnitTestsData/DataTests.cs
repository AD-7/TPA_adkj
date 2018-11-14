using System;
using System.Linq;
using Data;
using Data.Metadata_Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsData
{
    [TestClass]
    public class DataTests
    {
        private Reflector refl;

        [TestInitialize]
        public void Init()
        {
             this.refl = new Reflector();
            refl.Reflect("Data.dll");
        }

        [TestMethod]
        public void DLLNameTest()
        {
            
            
            Assert.AreEqual("Data.dll", refl.AssemblyModel.Name);
        }


        [TestMethod]
        public void NamespaceNameTest()
        {
         
            Assert.AreEqual("Data", refl.AssemblyModel.Namespaces.ToList().ElementAt(0).Name);
            Assert.AreEqual("Data.Metadata_Model", refl.AssemblyModel.Namespaces.ToList().ElementAt(1).Name);
            Assert.AreEqual("Data.Tracing", refl.AssemblyModel.Namespaces.ToList().ElementAt(2).Name);

        }

        [TestMethod]
        public void NamespaceCountTest()
        {
            Assert.AreEqual(3, refl.AssemblyModel.Namespaces.ToList().Count);
        }


        [TestMethod]
        public void TypesInNamespacesCountTest()
        {
            NamespaceMetadata namespace1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(2);

            Assert.AreEqual(2, namespace1.Types.ToList().Count);
        }

        [TestMethod]
        public void TypesNamesTest()
        {
            NamespaceMetadata namespace1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata namespace2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            Assert.AreEqual("IMetadata", namespace1.Types.ToList().ElementAt(0).Name);
            Assert.AreEqual("MethodMetadata", namespace2.Types.ToList().ElementAt(1).Name);

        }

    }
}
