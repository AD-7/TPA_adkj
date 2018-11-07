using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tracing
{

    public class TraceSource : ITraceSource
    {
        string file;
        public TraceSource(string file)
        {
            this.file = file;
        }
        public void TraceData(TraceEventType eventType, object data)
        {
            DateTime now = DateTime.Now;
            string message;
            message = eventType.ToString() + "->";
            message += "(" + now.ToString() + ")";
            message += data.ToString() + "/n/n";
            byte[] tmpMessage = new UTF8Encoding(true).GetBytes(message); 
            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                fs.Write(tmpMessage, 0, tmpMessage.Length);
            }
        }
    }
}
