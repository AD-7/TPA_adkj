using System.Diagnostics;

namespace ViewModel.TraceService

{
    public interface ITraceSource
    {
        void TraceData(string mes);
    }
}
