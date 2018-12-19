using System.Collections.ObjectModel;

namespace Data.Metadata_Model
{
    public interface IMetadata
    {
        ObservableCollection<IMetadata> getChildren();
        string MetadataName { get; set; }
        string Name { get; }
    }
}
