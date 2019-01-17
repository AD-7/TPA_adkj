using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTrace
{
    public class TraceContext : DbContext
    {
        public TraceContext() : base ("info")
        {

        }
        public virtual DbSet<TraceItem> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
