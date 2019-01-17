using System.Diagnostics;

namespace ViewModel.TraceService

{
    public interface ITraceSource
    {
        void TraceData(TraceEventType eventType, object data);
    }
}
