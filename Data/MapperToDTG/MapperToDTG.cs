using Data.Metadata_Model;
using DTG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MapperToDTG
{
    public static class MapperToDTG
    {

        public static AssemblyDTG AssemblyDtg(AssemblyMetadata assemblyModel)
        {
            TypeDtgDictionary = new Dictionary<string, TypeDTG>();
            return new AssemblyDTG()
            {
                Name = assemblyModel.Name,
                MetadataName = assemblyModel.MetadataName,
                Namespaces = assemblyModel.Namespaces?.Select(NamespaceDtg).ToList()
            };
        }

        private static NamespaceDTG NamespaceDtg(NamespaceMetadata namespaceModel)
        {
            return new NamespaceDTG()
            {
                Name = namespaceModel.Name,
                MetadataName = namespaceModel.MetadataName,
                Types = namespaceModel.Types?.Select(LoadType).ToList()
            };
        }

        private static TypeDTG LoadType(TypeMetadata typeModel)
        {
            if (typeModel == null) return null;
            return GetType(typeModel.Name) ?? TypeDtg(typeModel);
        }

        private static TypeDTG TypeDtg(TypeMetadata typeModel)
        {
            TypeDTG typeDTG = new TypeDTG()
            {
                Name = typeModel.Name,
                MetadataName = typeModel.MetadataName,
                SernamespaceName = typeModel.namespaceName,

            };

            TypeDtgDictionary.Add(typeModel.Name, typeDTG);

            typeDTG.GenericArguments = typeModel.GenericArguments?.Select(LoadType).ToList();
            typeDTG.Interfaces = typeModel.Interfaces?.Select(LoadType).ToList();
            typeDTG.NestedTypes = typeModel.NestedTypes?.Select(LoadType).ToList();
            typeDTG.SerMethods = typeModel.Methods?.Select(MethodDtg).ToList();
            typeDTG.SerConstructors = typeModel.Constructors?.Select(MethodDtg).ToList();
            typeDTG.SerProperties = typeModel.Properties?.Select(PropertyDtg).ToList();
           
            return typeDTG;
        }

        private static MethodDTG MethodDtg(MethodMetadata methodModel)
        {
            return new MethodDTG()
            {
                Name= methodModel.Name,
                MetadataName = methodModel.MetadataName,
                SerReturnType = LoadType(methodModel.ReturnType),
                SerParameters = methodModel.Parameters?.Select(ParameterDtg).ToList()
            };
        }

        private static ParameterDTG ParameterDtg(ParameterMetadata parameterModel)
        {
            return new ParameterDTG()
            {
                Name = parameterModel.Name,
                MetadataName = parameterModel.MetadataName,
                Type = LoadType(parameterModel.Type)
            };
        }
        private static PropertyDTG PropertyDtg(PropertyMetadata propertyModel)
        {
            return new PropertyDTG()
            {
                Name = propertyModel.Name,
                MetadataName = propertyModel.MetadataName,
                SerType = LoadType(propertyModel.Type)
            };
        }

        private static Dictionary<string, TypeDTG> TypeDtgDictionary;
        private static TypeDTG GetType(string key)
        {
            TypeDtgDictionary.TryGetValue(key, out TypeDTG value);
            return value;
        }



    }
}
    






