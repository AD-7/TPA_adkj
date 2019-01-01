using Data.Metadata_Model;

namespace ViewModel.TreeViewModel
{
   public class ParameterTreeView : TreeViewBase
    {
        public ParameterMetadata ParameterMetadata { get; }

        public ParameterTreeView(ParameterMetadata metadata)
        {
            ParameterMetadata = metadata;
            Name = metadata.MetadataName + ": " + metadata.Name;
        }

        protected override void buildMyself()
        {
            if(ParameterMetadata.Type != null)
            {
                Children.Add(new TypeTreeView(ParameterMetadata.Type));
            }
        }
    }
}