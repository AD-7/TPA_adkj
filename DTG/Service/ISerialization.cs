using DTG;

namespace DTG_Transfer.Service
{
    public interface ISerialization
    {
       void Serialize(AssemblyDTG reflcetor, string fileName);

        AssemblyDTG Deserialize(string fileName);
    }
}
