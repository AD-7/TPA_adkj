using Reflection.Metadata_Model;

namespace ViewModel.TreeViewModel
{
    public  class TypeTreeView : TreeViewBase
    {

        public TypeMetadata TypeMetadata { get; }


        public TypeTreeView(TypeMetadata metadata)
        {
             TypeMetadata = metadata;
            Name = metadata.MetadataName + ": " + metadata.Name;
        }





        protected override void buildMyself()
        {
           if(TypeMetadata.Methods != null)
            {
                foreach(MethodMetadata i in TypeMetadata.Methods)
                {
                    Children.Add(new MethodTreeView(i));

                }
            }

           if(TypeMetadata.GenericArguments != null)
            {
                foreach(TypeMetadata i in TypeMetadata.GenericArguments)
                {
                    Children.Add(new TypeTreeView(i));
                }
            }

           if(TypeMetadata.Constructors != null)
            {
                foreach(MethodMetadata i in TypeMetadata.Constructors)
                {
                    Children.Add(new MethodTreeView(i));
                }
            }

            if (TypeMetadata.NestedTypes != null)
            {
                foreach (TypeMetadata i in TypeMetadata.NestedTypes)
                {
                    Children.Add(new TypeTreeView(i));
                }
            }
            if (TypeMetadata.Interfaces != null)
            {
                foreach (TypeMetadata i in TypeMetadata.Interfaces)
                {
                    Children.Add(new TypeTreeView(i));
                }
            }
            if (TypeMetadata.Properties != null)
            {
                foreach (PropertyMetadata i in TypeMetadata.Properties)
                {
                    Children.Add(new PropertyTreeView(i));
                }
            }


        }
    }
}