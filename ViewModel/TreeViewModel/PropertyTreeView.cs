using Reflection.Metadata_Model;

namespace ViewModel.TreeViewModel
{
    public class PropertyTreeView : TreeViewBase
    {
        public PropertyMetadata PropertyMetadata { get; }
        public PropertyTreeView(PropertyMetadata metadata)
        {
            PropertyMetadata = metadata;
            Name = metadata.MetadataName + ": " + metadata.Name;
        }




        protected override void buildMyself()
        {
            if (PropertyMetadata.Type != null)
                Children.Add(new TypeTreeView(PropertyMetadata.Type));
        }
    }
}