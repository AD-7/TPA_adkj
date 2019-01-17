using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTrace
{
    public class TraceItem
    {
        [Key]
        public int Id { get; set; }

        public string mes { get; set; }

        public DateTime time { get; set; }

    }
}
