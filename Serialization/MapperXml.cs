using AutoMapper;
using Data.Metadata_Model;
using Serialization.SerializableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public static class MapperXml
    {

        public static  Reflector Map(SerializableReflector reflector)
        {
            Reflector Base = new Reflector();
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<SerializableAssembly, AssemblyMetadata>();

            });

            IMapper iMapper = config.CreateMapper();
            Base.AssemblyModel = iMapper.Map<SerializableAssembly, AssemblyMetadata>(reflector.SerializableAssembly);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SerializableNamespace, NamespaceMetadata>();
            }
            );
            iMapper = config.CreateMapper();

            Base.AssemblyModel.Namespaces = iMapper.Map<IEnumerable<SerializableNamespace>,IEnumerable<NamespaceMetadata>>(reflector.SerializableAssembly.SerializableNamespaces);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SerializableType, TypeMetadata>();
            }
            );
            iMapper = config.CreateMapper();

           for(int i =0; i< reflector.SerializableAssembly.SerializableNamespaces.Count(); i++)
            {
                config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SerializableType, TypeMetadata>();
                }
                );
                Base.AssemblyModel.Namespaces.ToList()[i].Types = iMapper.Map<IEnumerable<SerializableType>, IEnumerable<TypeMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes);

                for(int j=0; j< reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.Count(); j++)
                {
                    Base.AssemblyModel.Namespaces.ToList()[i].Types.ToList()[j].Interfaces = iMapper.Map<IEnumerable<SerializableType>, IEnumerable<TypeMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.ToList()[j].Interfaces);
                    Base.AssemblyModel.Namespaces.ToList()[i].Types.ToList()[j].NestedTypes = iMapper.Map<IEnumerable<SerializableType>, IEnumerable<TypeMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.ToList()[j].NestedTypes);
                    Base.AssemblyModel.Namespaces.ToList()[i].Types.ToList()[j].GenericArguments = iMapper.Map<IEnumerable<SerializableType>, IEnumerable<TypeMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.ToList()[j].GenericArguments);
                    
                }
                for (int j = 0; j < reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.Count(); j++)
                {
                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SerializableMethod, MethodMetadata>();
                    });
                    iMapper = config.CreateMapper();

                    Base.AssemblyModel.Namespaces.ToList()[i].Types.ToList()[j].Methods = iMapper.Map<IEnumerable<SerializableMethod>, IEnumerable<MethodMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.ToList()[j].SerMethods);
                    Base.AssemblyModel.Namespaces.ToList()[i].Types.ToList()[j].Constructors = iMapper.Map<IEnumerable<SerializableMethod>, IEnumerable<MethodMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.ToList()[j].SerConstructors);
                }
                for (int j = 0; j < reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.Count(); j++)
                {
                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SerializableProperty, PropertyMetadata>();
                    });
                    iMapper = config.CreateMapper();

                    Base.AssemblyModel.Namespaces.ToList()[i].Types.ToList()[j].Properties = iMapper.Map<IEnumerable<SerializableProperty>, IEnumerable<PropertyMetadata>>(reflector.SerializableAssembly.SerializableNamespaces.ToList()[i].SerializableTypes.ToList()[j].SerProperties);
                }



            }
                
           
            return Base;
        }
    }
}
