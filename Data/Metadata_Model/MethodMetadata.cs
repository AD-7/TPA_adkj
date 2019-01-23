using DTG;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Reflection.Metadata_Model
{

    public class MethodMetadata : IMetadata
    {
     
        public string MetadataName { get; set; }

        public string Name { get; set; }
     
        public TypeMetadata ReturnType;
     
        public List<ParameterMetadata> Parameters;

        public MethodMetadata(MethodBase method)
        {
            MetadataName = "Method: ";
            Name = method.Name;
            ReturnType = EmitReturnType(method);
            Parameters = (EmitParameters(method.GetParameters())).ToList();
        }
        public MethodMetadata(string Name, string Metadataname) 
        {
            this.Name = Name;
            this.MetadataName = "Method: ";
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

        public MethodMetadata(MethodDTG method)
        {
            Name = method.Name;
            MetadataName = method.MetadataName;
            ReturnType = TypeMetadata.LoadType(method.SerReturnType);
            Parameters = method.SerParameters?.Select(p => new ParameterMetadata(p)).ToList();
        }

    }
}
