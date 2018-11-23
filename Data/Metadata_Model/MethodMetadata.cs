using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    public class MethodMetadata : IMetadata

    { 

        public string MetadataName { get ; set; }
        public string Name { get; set; }

        internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase tmp in methods where tmp.GetVisible() select new MethodMetadata(tmp);
        }

         public MethodMetadata(MethodBase method)
        {
            MetadataName = "Method: ";
            Name = method.Name;
   
        }


        public ObservableCollection<IMetadata> getChildren {
            get { return new ObservableCollection<IMetadata>();

            }
        }

    }
}
