
using DTG;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Reflection.Metadata_Model
{
  
    public class TypeMetadata : IMetadata
    {
        #region 
       
        public string Name { get; set; }
       
        public string MetadataName { get; set; }
     
        public static Dictionary<string, TypeMetadata> allTypes {get; set;}

        public string namespaceName;
  
        public List<TypeMetadata> GenericArguments;

        public List<MethodMetadata> Methods { get; set; }
    
        public List<MethodMetadata> Constructors { get; set; }

        public List<TypeMetadata> NestedTypes { get; set; }

        public List<TypeMetadata> Interfaces { get; set; }
       
        public List<PropertyMetadata> Properties { get; set; }
        
       

    
        bool exists = false;

        #endregion


        #region constructors
        internal TypeMetadata(Type type, string metadataName)
        {
           
            Name = type.Name;
            MetadataName = metadataName;

            allTypes  = new Dictionary<string, TypeMetadata>();
            GenericArguments = !type.IsGenericTypeDefinition ? null : (TypeMetadata.EmitGenericArguments(type.GetGenericArguments())).ToList();
            Methods = (MethodMetadata.EmitMethods(type.GetMethods())).ToList();
            Constructors = (MethodMetadata.EmitMethods(type.GetConstructors())).ToList();
            NestedTypes = (EmitNestedTypes(type.GetNestedTypes())).ToList();
            Interfaces = (EmitInterfaces(type.GetInterfaces())).ToList();
            Properties = (EmitProperties(type.GetProperties())).ToList();
            exists = true;
        }



        public TypeMetadata(string name, string metadataName, string namespaceName)
        {
            Name = name;
            MetadataName = metadataName;
            this.namespaceName = namespaceName;
            allTypes = new Dictionary<string, TypeMetadata>();
        }

            public TypeMetadata(string name, string metadataName )
            {
                Name = name;
                MetadataName = metadataName;
            exists = true;

        }

            public TypeMetadata(string name, string metadataName, string namespaceName, IEnumerable<TypeMetadata> genericArgs) : this(name, metadataName, namespaceName)
        {
            GenericArguments = genericArgs.ToList();
        }
        public TypeMetadata(TypeDTG type)
        {
            Name = type.Name;
            namespaceName = type.SernamespaceName;
            DictionaryOfTypes.Instance.RegisterType(Name, this);
            MetadataName = type.MetadataName;
            GenericArguments = type.GenericArguments?.Select(LoadType).ToList();
            NestedTypes = type.NestedTypes?.Select(LoadType).ToList();
            Interfaces = type.Interfaces?.Select(LoadType).ToList();
            Methods = type.SerMethods?.Select(m => new MethodMetadata(m)).ToList();
            Constructors = type.SerConstructors?.Select(c => new MethodMetadata(c)).ToList();
            Properties = type.SerProperties?.Select(p => new PropertyMetadata(p)).ToList();
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
        public static TypeMetadata AddType(TypeDTG type)
        {
            if(type != null && allTypes != null)
            {
                if (allTypes.ContainsKey(type.Name))
                {
                    if (allTypes[type.Name].exists)
                    {
                        return allTypes[type.Name];
                    }
                }
                TypeMetadata tmp = new TypeMetadata(type);

                if (allTypes.ContainsKey(type.Name))
                {
                    allTypes.Remove(type.Name);
                }
                allTypes.Add(type.Name, tmp);
                return tmp;
            }
            return null;
        }
        internal enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }


        #region emiters
        internal static TypeMetadata EmitReference(Type type)
        {

            if (allTypes.ContainsKey(type.Name))
            {
                return allTypes[type.Name];
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

            if (type.Name != null)
            {
                allTypes.Add(type.Name, tmp);
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

        public static TypeMetadata LoadType(Type type)
        {
            return DictionaryOfTypes.Instance.GetType(type.Name) ?? new TypeMetadata(type,"Type: ");
        }

        public static TypeMetadata LoadType(TypeDTG type)
        {
            return DictionaryOfTypes.Instance.GetType(type.Name) ?? new TypeMetadata(type); 
        }

        



    }
}