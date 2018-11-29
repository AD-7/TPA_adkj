using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
    [DataContract(IsReference = true)]
    public class ParameterMetadata : IMetadata
    {
        [DataMember(Name = "Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Type_Metadata")]
        public TypeMetadata Type;

        public ParameterMetadata(string name, TypeMetadata type)
        {
            Name = name;
            MetadataName = "Parameter: ";
            Type = type;
        }

        public ObservableCollection<IMetadata> getChildren
        {

            get
            {
                ObservableCollection<IMetadata> children = new ObservableCollection<IMetadata>();
                children.Add(Type);
                return children;
            }
        }
    }
}