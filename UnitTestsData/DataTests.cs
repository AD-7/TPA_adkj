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

            Assert.AreEqual("Data.MapperToDTG", refl.AssemblyModel.Namespaces.ToList().ElementAt(0).Name);
            Assert.AreEqual("Data.Metadata_Model", refl.AssemblyModel.Namespaces.ToList().ElementAt(1).Name);
            Assert.AreEqual("Data.SaveManager", refl.AssemblyModel.Namespaces.ToList().ElementAt(2).Name);

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

            Assert.AreEqual("MapperToDTG", namespace1.Types.ToList().ElementAt(0).Name);
            Assert.AreEqual("DictionaryOfTypes", namespace2.Types.ToList().ElementAt(1).Name);

        }



        [TestMethod]
        public void CountMethodTest()
        {
            NamespaceMetadata n1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata n2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = n1.Types.ToList().ElementAt(0);
            TypeMetadata typeMetadata2 = n2.Types.ToList().ElementAt(1);

            Assert.AreEqual(5, typeMetadata1.Methods.ToList().Count);
            Assert.AreEqual(9, typeMetadata2.Methods.ToList().Count);
        }

        [TestMethod]
        public void NameMethodTest()
        {
            NamespaceMetadata n1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata n2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = n1.Types.ToList().ElementAt(0);
            TypeMetadata typeMetadata2 = n2.Types.ToList().ElementAt(1);

            Assert.AreEqual("AssemblyDtg", typeMetadata1.Methods.ToList().ElementAt(0).Name);
            Assert.AreEqual("RegisterType", typeMetadata2.Methods.ToList().ElementAt(1).Name);
        }

        [TestMethod]
        public void NumberofParameterOfMethodTest()
        {
            NamespaceMetadata n1 = refl.AssemblyModel.Namespaces.ToList().ElementAt(0);
            NamespaceMetadata n2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = n1.Types.ToList().ElementAt(0);
            TypeMetadata typeMetadata2 = n2.Types.ToList().ElementAt(1);

            Assert.AreEqual(1, typeMetadata1.Methods.ToList().ElementAt(0).Parameters.Count());
          
        }


        [TestMethod]
    
        public void AmountOfPropertiesInTypesInNamespacesTest()
        {
            

            NamespaceMetadata namespaceMetadata2 = refl.AssemblyModel.Namespaces.ToList().ElementAt(1);

            TypeMetadata typeMetadata1 = namespaceMetadata2.Types.ToList().ElementAt(3);
            TypeMetadata typeMetadata2 = namespaceMetadata2.Types.ToList().ElementAt(1);

            Assert.AreEqual(1, typeMetadata2.Properties.ToList().Count);
            Assert.AreEqual(2, typeMetadata1.Properties.ToList().Count);
        }







    }
}