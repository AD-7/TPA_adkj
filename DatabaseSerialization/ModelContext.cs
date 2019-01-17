using DatabaseSerialization.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSerialization
{
    class ModelContext : DbContext
    {
        public ModelContext() : base("AssemblyData")
        {
            Database.SetInitializer<ModelContext>(new DropCreateDatabaseAlways<ModelContext>());

        }

        public virtual DbSet<AssemblyDb> Assemblies { get; set; }
        public virtual DbSet<NamespaceDb> Namespaces { get; set; }
        public virtual DbSet<TypeDb> Types { get; set; }
        public virtual DbSet<MethodDb> Methods { get; set; }
        public virtual DbSet<ParameterDb> Parameters { get; set; }
        public virtual DbSet<PropertyDb> Properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}
