using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IMetadata
    {
        ObservableCollection<Tuple<string,IMetadata>> getChildren { get;  }
        string Name { get; }
    }
}
