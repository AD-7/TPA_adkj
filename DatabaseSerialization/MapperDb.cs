using DatabaseSerialization.Model;
using DTG;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseSerialization
{
    public static class MapperDb
    {
       
            public static AssemblyDTG AssemblyDtg(AssemblyDb assemblyModel)
            {
                TypeDtgDictionary = new Dictionary<string, TypeDTG>();
                return new AssemblyDTG()
                {
                    Name = assemblyModel.Name,
                    MetadataName = assemblyModel.MetadataName,
                    Namespaces = assemblyModel.SerializableNamespaces?.Select(NamespaceDtg).ToList()
                };
            }

            private static NamespaceDTG NamespaceDtg(NamespaceDb namespaceModel)
            {
                return new NamespaceDTG()
                {
                    Name = namespaceModel.Name,
                    MetadataName = namespaceModel.MetadataName,
                    Types = namespaceModel.SerializableTypes?.Select(LoadType).ToList()
                };
            }

            private static TypeDTG LoadType(TypeDb typeModel)
            {
                if (typeModel == null) return null;
                return GetType(typeModel.Name) ?? TypeDtg(typeModel);
            }

            private static TypeDTG TypeDtg(TypeDb typeModel)
            {
                TypeDTG typeDTG = new TypeDTG()
                {
                    Name = typeModel.Name,
                    MetadataName = typeModel.MetadataName,
                    SernamespaceName = typeModel.SernamespaceName,

                };

                TypeDtgDictionary.Add(typeModel.Name, typeDTG);

                typeDTG.GenericArguments = typeModel.GenericArguments?.Select(LoadType).ToList();
                typeDTG.Interfaces = typeModel.Interfaces?.Select(LoadType).ToList();
                typeDTG.NestedTypes = typeModel.NestedTypes?.Select(LoadType).ToList();
                typeDTG.SerMethods = typeModel.SerMethods?.Select(MethodDtg).ToList();
                typeDTG.SerConstructors = typeModel.SerConstructors?.Select(MethodDtg).ToList();
                typeDTG.SerProperties = typeModel.SerProperties?.Select(PropertyDtg).ToList();
                return typeDTG;
            }

            private static MethodDTG MethodDtg(MethodDb methodModel)
            {
                return new MethodDTG()
                {
                    Name = methodModel.Name,
                    MetadataName = methodModel.MetadataName,
                    SerReturnType = LoadType(methodModel.SerReturnType),
                    SerParameters = methodModel.SerParameters?.Select(ParameterDtg).ToList()
                };
            }

            private static ParameterDTG ParameterDtg(ParameterDb parameterModel)
            {
                return new ParameterDTG()
                {
                    Name = parameterModel.Name,
                    MetadataName = parameterModel.MetadataName,
                    Type = LoadType(parameterModel.Type)
                };
            }
            private static PropertyDTG PropertyDtg(PropertyDb propertyModel)
            {
                return new PropertyDTG()
                {
                    Name = propertyModel.Name,
                    MetadataName = propertyModel.MetadataName,
                    SerType = LoadType(propertyModel.SerType)
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
