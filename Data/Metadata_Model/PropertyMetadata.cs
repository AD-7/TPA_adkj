using System.Collections.ObjectModel;

namespace Data.Metadata_Model
{
    public class PropertyMetadata : IMetadata
    {
        public string Name { get; private set; }
        public string MetadataName { get; set; }
        private TypeMetadata Type;

        public PropertyMetadata(string Name, TypeMetadata type)
        {
            this.Name = Name;
            MetadataName = "Property: ";
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