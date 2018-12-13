using Data.ViewModel;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Data.Metadata_Model
{
    [DataContract(IsReference = true)]
    public class PropertyMetadata : TreeViewBase,IMetadata
    {
        [DataMember(Name = "Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Type_Metadata")]
        private TypeMetadata Type;

        public PropertyMetadata(string Name, TypeMetadata type)
        {
            this.Name = Name;
            MetadataName = "Property: ";
            Type = type;
        }



        public override ObservableCollection<IMetadata> getChildren()
        {

           
                ObservableCollection<IMetadata> children = new ObservableCollection<IMetadata>();

                children.Add(Type);
                return children;
            
        }
    }
}