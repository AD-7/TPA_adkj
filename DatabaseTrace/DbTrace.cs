

using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using ViewModel.TraceService;

namespace DatabaseTrace
{
    [Export(typeof(ITraceSource))]
    public class DbTrace : ITraceSource
    {
        public void TraceData(string mes)
        {
            using (Context context = new Context())
            {
                context.Logs.Add(new TraceItem() { mes = mes, time = DateTime.Now });
                context.SaveChanges();
            }

        }
    }
}
