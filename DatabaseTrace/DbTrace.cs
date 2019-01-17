

using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using ViewModel.TraceService;

namespace DatabaseTrace
{
    [Export(typeof(ITraceSource))]
    [ExportMetadata("Name", "Database")]
    public class DbTrace : ITraceSource
    {
        public void TraceData(string mes)
        {
            using (TraceContext context = new TraceContext())
            {
                context.Logs.Add(new TraceItem() { mes = mes, time = DateTime.Now });
                context.SaveChanges();
            }

        }
    }
}
