using Data.Metadata_Model;

namespace Interfaces
{
    public interface ISerialization
    {
       void Serialize(Reflector reflcetor, string fileName);

         Reflector Deserialize(string fileName);
    }
}
