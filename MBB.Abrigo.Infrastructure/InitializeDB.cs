using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MBB.Abrigo.Core.Models;
using System.Threading.Tasks;

namespace MBB.Abrigo.Infrastructure
{
    public class InitializeDB : DropCreateDatabaseIfModelChanges<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
            context.Persons.Add(new Person
            {
                Id = "1",
                FirstName = "Esteban",
                LastName = "Federico",
                Age = 18
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
