using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITraceSource
    {
        void TraceData(TraceEventType eventType, object data);
    }
}
