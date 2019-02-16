using MBB.Abrigo.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBB.Abrigo.Infrastructure
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("name=AbrigoDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           // dbModelBuilder.Entity<TableName>().ToTable("TableName", schemaName: "EDI");
        }

        public DbSet<Person> Persons { get; set; }
    }
}
