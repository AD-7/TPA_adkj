
using Data.Metadata_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.TreeViewModel
{
    [DataContract(IsReference =true)]
    public abstract  class TreeViewBase
    {
       
        public abstract ObservableCollection<IMetadata> getChildren();

    }
}
