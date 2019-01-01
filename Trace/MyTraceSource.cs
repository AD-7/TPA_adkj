using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace
{
    [Export(typeof(ITraceSource))]
    [ExportMetadata("Name","File")]
    public class MyTraceSource : ITraceSource
    {
     
   
     
        public void TraceData(TraceEventType eventType, object data)
        {
            DateTime now = DateTime.Now;
            string message;
            message = "\n\n" + eventType.ToString() + "->";
            message += "(" + now.ToString() + ")->";
            message += data.ToString() + "\n\n";
            byte[] tmpMessage = new UTF8Encoding(true).GetBytes(message); 
            using (FileStream fs = new FileStream("plik.txt", FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                fs.Write(tmpMessage, 0, tmpMessage.Length);
            }
        }
    }
}
