using DTG;

namespace DTG_Transfer.Service
{
    public interface ISerialization
    {
       void Serialize(AssemblyDTG assembly);

        AssemblyDTG Deserialize();
    }
}
