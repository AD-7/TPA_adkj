
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
        public TypeMetadata(Type type, string metadataName)
        {
           
            Name = type.Name;
            MetadataName = metadataName;
            DictionaryOfTypes.Instance.RegisterType(Name, this);
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

       
        
        internal enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }


        #region emiters
        internal static TypeMetadata EmitReference(Type type)
        {

           return  LoadType(type);
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