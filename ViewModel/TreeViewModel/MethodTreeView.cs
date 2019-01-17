using Reflection.Metadata_Model;

namespace ViewModel.TreeViewModel
{
    public class MethodTreeView : TreeViewBase
    {
        public MethodMetadata MethodMetadata { get; }

        public MethodTreeView(MethodMetadata metadata)
        {
            MethodMetadata = metadata;
            Name = metadata.MetadataName + ": " + metadata.Name;
        }


        protected override void buildMyself()
        {
         
            if(MethodMetadata.ReturnType != null)
            {
                Children.Add(new TypeTreeView(MethodMetadata.ReturnType));
            }

            if(MethodMetadata.Parameters != null)
            {
                foreach(ParameterMetadata i in MethodMetadata.Parameters)
                {
                    Children.Add(new ParameterTreeView(i));
                }
            }

        }
    }
}