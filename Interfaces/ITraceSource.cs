using System.Diagnostics;

namespace Interfaces
{
    public interface ITraceSource
    {
        void TraceData(TraceEventType eventType, object data);
    }
}
