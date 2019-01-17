using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Text;
using ViewModel.TraceService;

namespace Trace
{
    [Export(typeof(ITraceSource))]
    [ExportMetadata("Name","File")]
    public class MyTraceSource : ITraceSource
    {
     
   
     
        public void TraceData(string mes)
        {
            System.Diagnostics.Trace.WriteLine("(" + DateTime.Now + ") -> " + mes);
        }
    }
}
