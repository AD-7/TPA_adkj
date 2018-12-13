using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Metadata_Model
{
    [DataContract(IsReference = true)]
    public class MethodMetadata : TreeViewBase,IMetadata
    {
        [DataMember(Name = "Metadata_Name")]
        public string MetadataName { get; set; }
        [DataMember(Name = "Method_Name")]
        public string Name { get; set; }
        [DataMember(Name = "Return_Type")]
        public TypeMetadata ReturnType;
        [DataMember(Name = "Parameters")]
        public IEnumerable<ParameterMetadata> Parameters;

        public MethodMetadata(MethodBase method)
        {
            MetadataName = "Method: ";
            Name = method.Name;
            ReturnType = EmitReturnType(method);
            Parameters = EmitParameters(method.GetParameters());
        }

        internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase tmp in methods where tmp.GetVisible() select new MethodMetadata(tmp);
        }
        internal static TypeMetadata EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null)
                return null;
            return TypeMetadata.EmitReference(methodInfo.ReturnType);
        }
        internal static IEnumerable<ParameterMetadata> EmitParameters(ParameterInfo[] parameters)
        {
            return from parameter in parameters
                   select new ParameterMetadata(parameter.Name, TypeMetadata.EmitReference(parameter.ParameterType));
        }

        public override ObservableCollection<IMetadata> getChildren()
        {
           
                ObservableCollection<IMetadata> children = new ObservableCollection<IMetadata>();
                if (ReturnType != null)
                {
                    ReturnType.MetadataName = "Return type: ";
                    children.Add(ReturnType);

                }

                return children;  
        }

    }
}
