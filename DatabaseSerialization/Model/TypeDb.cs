using DTG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSerialization.Model
{
    public class TypeDb
    {

        [Key]
        public int TypeID { get; set; }
        public string Name { get; private set; }
        public string MetadataName { get; set; }
        public string SernamespaceName;
        public List<TypeDb> GenericArguments;
        public List<TypeDb> NestedTypes { get; set; }
        public List<TypeDb> Interfaces { get; set; }
        public List<MethodDb> SerMethods { get; set; }
        public List<MethodDb> SerConstructors { get; set; }
        public List<PropertyDb> SerProperties { get; set; }

        public TypeDb(TypeDTG type)
        {
            DictionaryOfTypes.Instance.RegisterType(type.Name, this);
            Name = type.Name;
            MetadataName = type.MetadataName;
            SernamespaceName = type.SernamespaceName;
            GenericArguments = type.GenericArguments?.Select(t => LoadType(t)).ToList();
            NestedTypes = type.NestedTypes?.Select(n => LoadType(n)).ToList();
            Interfaces = type.Interfaces?.Select(i => LoadType(i)).ToList();
            SerMethods = type.SerMethods?.Select(m => new MethodDb(m)).ToList();
            SerConstructors = type.SerConstructors?.Select(c => new MethodDb(c)).ToList();
            SerProperties = type.SerProperties?.Select(p => new PropertyDb(p)).ToList();
        }

        public TypeDb()
        {
        }

        public static TypeDb LoadType(TypeDTG type)
        {
            if (type == null) return null;
            return DictionaryOfTypes.Instance.GetType(type.Name) ??  new TypeDb(type);
        }
    }
}
