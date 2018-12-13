using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    public interface IMetadata
    {
        ObservableCollection<IMetadata> getChildren();
        string MetadataName { get; set; }
        string Name { get; }
    }
}
