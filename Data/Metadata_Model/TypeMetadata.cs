
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
    [DataContract(IsReference = true)]
    public class TypeMetadata : IMetadata
    {
        #region 
        [DataMember(Name = "Type_Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Types_Name")]
        public static Dictionary<string, TypeMetadata> allTypes = new Dictionary<string, TypeMetadata>();
        [DataMember(Name = "Namespace_Name")]
        public string namespaceName;
        [DataMember(Name = "Generic_Arguments")]
        public IEnumerable<TypeMetadata> GenericArguments;
        [DataMember(Name = "Method")]
        public IEnumerable<MethodMetadata> Methods { get; set; }
        [DataMember(Name = "Constructor")]
        public IEnumerable<MethodMetadata> Constructors { get; set; }
        [DataMember(Name = "NestedType")]
        public IEnumerable<TypeMetadata> NestedTypes { get; set; }
        [DataMember(Name = "Interface")]
        public IEnumerable<TypeMetadata> Interfaces { get; set; }
        [DataMember(Name = "Propertie")]
        public IEnumerable<PropertyMetadata> Properties { get; set; }
        
        public IEnumerable<Attribute> Attributes;

    
        bool exists = false;

        #endregion


        #region constructors
        internal TypeMetadata(Type type, string metadataName)
        {

            Name = type.Name;
            MetadataName = metadataName;
            GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            Methods = MethodMetadata.EmitMethods(type.GetMethods());
            Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            Interfaces = EmitInterfaces(type.GetInterfaces());
            Properties = EmitProperties(type.GetProperties());
            Attributes = type.GetCustomAttributes(false).Cast<Attribute>();
            exists = true;
        }



        public TypeMetadata(string name, string metadataName, string namespaceName)
        {
            Name = name;
            MetadataName = metadataName;
            this.namespaceName = namespaceName;
        }
        public TypeMetadata(string name, string metadataName, string namespaceName, IEnumerable<TypeMetadata> genericArgs) : this(name, metadataName, namespaceName)
        {
            GenericArguments = genericArgs;
        }
        #endregion

        internal static TypeMetadata AddType(Type type)
        {
            if (allTypes.ContainsKey(type.FullName))
            {
                if (allTypes[type.FullName].exists)
                {
                    return allTypes[type.FullName];
                }
            }
            TypeMetadata tmp = new TypeMetadata(type, "Type: ");

            if (allTypes.ContainsKey(type.FullName))
            {
                allTypes.Remove(type.FullName);
            }
            allTypes.Add(type.FullName, tmp);
            return tmp;
        }

        internal enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }


        #region emiters
        internal static TypeMetadata EmitReference(Type type)
        {
            if (allTypes.ContainsKey(type.FullName))
            {
                return allTypes[type.FullName];
            }

            TypeMetadata tmp;

            if (!type.IsGenericType)
            {
                tmp = new TypeMetadata(type.Name, "Type: ", type.GetNamespace());
            }
            else
            {
                tmp = new TypeMetadata(type.Name, "Type: ", type.GetNamespace(), EmitGenericArguments(type.GetGenericArguments()));
            }

            if (type.FullName != null)
            {
                allTypes.Add(type.FullName, tmp);
            }
            return tmp;
        }

        internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> args)
        {
            return from Type arg in args select EmitReference(arg);
        }


        internal static IEnumerable<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
        {
            return from type in nestedTypes
                   where type.GetVisible()
                   select new TypeMetadata(type, "Nested Type: ");
        }
        internal static IEnumerable<TypeMetadata> EmitInterfaces(IEnumerable<Type> interfaces)
        {
            return from interfaceTmp in interfaces
                   select EmitReference(interfaceTmp);
        }
        internal static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> properties)
        {

            return from prop in properties
                   where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
                   select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
        }
        #endregion





        



    }
}