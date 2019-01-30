using System;
using System.Linq;
using Reflection;
using Reflection.Metadata_Model;
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
            refl = new Reflector();
            refl.Reflect("../../dllForTests/TPA.ApplicationArchitecture.dll");
        }

        [TestMethod]
        public void DLLNameTest()
        {
            Assert.AreEqual("TPA.ApplicationArchitecture.dll", refl.AssemblyModel.Name);
        }


        [TestMethod]
        public void NamespaceNameTest()
        {

            Assert.AreEqual("TPA.ApplicationArchitecture.BusinessLogic", refl.AssemblyModel.Namespaces.ToList().ElementAt(0).Name);
            Assert.AreEqual("TPA.ApplicationArchitecture.Data", refl.AssemblyModel.Namespaces.ToList().ElementAt(1).Name);
            Assert.AreEqual("TPA.ApplicationArchitecture.Data.CircularReference", refl.AssemblyModel.Namespaces.ToList().ElementAt(2).Name);

        }

        [TestMethod]
        public void NamespaceCountTest()
        {
            Assert.AreEqual(4, refl.AssemblyModel.Namespaces.ToList().Count);
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

            Assert.AreEqual("Model", namespace1.Types.ToList().ElementAt(0).Name);
            Assert.AreEqual("ClassWithAttribute", namespace2.Types.ToList().ElementAt(1).Name);

        }



        [TestMethod]
        public void CountMethodTest()
        {
            NamespaceMetadata n1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata n2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = n1.Types.ToList().ElementAt(0);
            TypeMetadata typeMetadata2 = n2.Types.ToList().ElementAt(1);

            Assert.AreEqual(6, typeMetadata1.Methods.ToList().Count);
            Assert.AreEqual(4, typeMetadata2.Methods.ToList().Count);
        }

        [TestMethod]
        public void NameMethodTest()
        {
            NamespaceMetadata n1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata n2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = n1.Types.ToList().ElementAt(0);
            TypeMetadata typeMetadata2 = n2.Types.ToList().ElementAt(1);

            Assert.AreEqual("get_Linq2SQL", typeMetadata1.Methods.ToList().ElementAt(0).Name);
            Assert.AreEqual("Equals", typeMetadata2.Methods.ToList().ElementAt(1).Name);
        }

        [TestMethod]
        public void NumberofParameterOfMethodTest()
        {
            NamespaceMetadata n1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata n2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = n1.Types.ToList().ElementAt(0);
            TypeMetadata typeMetadata2 = n2.Types.ToList().ElementAt(1);

            Assert.AreEqual(1, typeMetadata1.Methods.ToList().ElementAt(3).Parameters.Count());
            Assert.AreEqual(1, typeMetadata2.Methods.ToList().ElementAt(1).Parameters.Count());
        }


        [TestMethod]
    
        public void AmountOfPropertiesInTypesInNamespacesTest()
        {
            NamespaceMetadata namespaceMetadata2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = namespaceMetadata2.Types.ToList().ElementAt(3);
            TypeMetadata typeMetadata2 = namespaceMetadata2.Types.ToList().ElementAt(1);

            Assert.AreEqual(4, typeMetadata2.Methods.ToList().Count);
            Assert.AreEqual(29, typeMetadata1.Methods.ToList().Count);
        }







    }
}