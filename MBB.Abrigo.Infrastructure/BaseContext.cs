using MBB.Abrigo.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public DbSet<Person> Persons { get; set; }
    }
}
