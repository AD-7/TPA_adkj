using DTG;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DatabaseSerialization.Model
{
    public class MethodDb
    {

        [Key]
        public int MethodID { get; set; }
        public string MetadataName { get; set; }
        public string Name { get; set; }
        public TypeDb SerReturnType;

        public List<ParameterDb> SerParameters;

        public MethodDb(MethodDTG method)
        {
            Name = method.Name;
            MetadataName = method.MetadataName;
            if (method.SerReturnType != null)
                SerReturnType = TypeDb.LoadType(method.SerReturnType);


            SerParameters = method.SerParameters?.Select(p => new ParameterDb(p)).ToList();
        }

        public MethodDb()
        {
        }
    }
}