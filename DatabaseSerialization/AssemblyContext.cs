namespace DatabaseSerialization
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DatabaseSerialization.Model;

    public partial class AssemblyContext : DbContext
    {
        public AssemblyContext()
            : base("name=AssemblyContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AssemblyContext>());
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
