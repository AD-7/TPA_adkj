using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Data.Metadata_Model
{
    public class TypeMetadata : IMetadata
    {
        #region 
        public string Name { get; private set; }
        public string MetadataName { get; set; }
        public static Dictionary<string, TypeMetadata> allTypes = new Dictionary<string, TypeMetadata>();
        public string namespaceName;
    
        private IEnumerable<TypeMetadata> GenericArguments;
        public IEnumerable<MethodMetadata> Methods { get; set; }
        bool exists= false;

        #endregion


        #region constructors
        internal TypeMetadata(Type type, string metadataName)
        {
            
            Name = type.Name;
            MetadataName = metadataName;
            GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            Methods = MethodMetadata.EmitMethods(type.GetMethods());

            exists = true;
        }

        public TypeMetadata(string name, string metadataName, string namespaceName) 
        {
            Name = name;
            MetadataName = metadataName;
            this.namespaceName = namespaceName;
        }
        public TypeMetadata(string name, string metadataName,string namespaceName, IEnumerable<TypeMetadata> genericArgs) : this(name,metadataName,namespaceName)
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
            TypeMetadata tmp = new TypeMetadata(type,"Type: " );

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

            if(type.FullName != null)
            {
                allTypes.Add(type.FullName, tmp);
            }
            return tmp;
        }

        internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> args)
        {
            return from Type arg in args select EmitReference(arg);
        }

       

        #endregion





       public ObservableCollection<IMetadata> getChildren
       {
            get
            {
           
                ObservableCollection<IMetadata> children = new ObservableCollection<IMetadata>();

                foreach(IMetadata p in Methods )
                {
                    children.Add(p);
                }
                foreach(IMetadata i in GenericArguments ?? Enumerable.Empty<IMetadata>())
                {
                    children.Add(i);
                }



                return children;

            }

       }



    }
}