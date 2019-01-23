using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Metadata_Model
{
    public sealed class DictionaryOfTypes
    {
        private static DictionaryOfTypes _instance = null;

        public static DictionaryOfTypes Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_padlock)
                {
                    return _instance ?? (_instance = new DictionaryOfTypes());
                }

            }
        }

        private static readonly object _padlock = new object();

        private readonly Dictionary<string, TypeMetadata> _data;

        private DictionaryOfTypes()
        {
            _data = new Dictionary<string, TypeMetadata>();
        }

        public void RegisterType(string name, TypeMetadata type)
        {
          if(!DictionaryOfTypes.Instance.ContainsKey(name))
            _data.Add(name, type);
        }

        public bool ContainsKey(string name)
        {
            return _data.ContainsKey(name);
        }

        public TypeMetadata GetType(string key)
        {
            _data.TryGetValue(key, out TypeMetadata value);
            return value;
        }

        public void Clear()
        {
            _data.Clear();
        }
    }
}
