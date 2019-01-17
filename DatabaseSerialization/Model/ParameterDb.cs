using DTG;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSerialization.Model
{
    public class ParameterDb
    {

        [Key]
        public int ParameterID { get; set; }
        public string Name { get; private set; }
        public string MetadataName { get; set; }
        public TypeDb Type;

        public ParameterDb(ParameterDTG parameter)
        {
            Name = parameter.Name;
            MetadataName = parameter.MetadataName;
            Type = TypeDb.LoadType(parameter.Type);
        }

        public ParameterDb()
        {
        }
    }
}