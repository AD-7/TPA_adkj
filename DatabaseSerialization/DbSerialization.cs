using DatabaseSerialization.Model;
using DTG;
using DTG_Transfer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSerialization
{
    [Export(typeof(ISerialization))]
    public class DbSerialization : ISerialization
    {
        public AssemblyDTG Deserialize()
        {
            using(AssemblyContext context = new AssemblyContext())
            {
                context.Namespaces.Load();
                context.Types.Load();
                context.Methods.Load();
                context.Parameters.Load();
                context.Properties.Load();
               
               
                AssemblyDb assemblyFromDatabase = context.Assemblies.First();
                if(assemblyFromDatabase == null)
                {
                    return null;
                }
                return MapperDb.AssemblyDtg(assemblyFromDatabase);
            }
            
        }

        public void Serialize(AssemblyDTG assembly)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AssemblyContext>());
      
            using (AssemblyContext context = new AssemblyContext() )
            {
                AssemblyDb assemblyToSave = new AssemblyDb(assembly);
                context.Assemblies.Add(assemblyToSave);
                context.SaveChanges();

            }
           
        }
    }
}
