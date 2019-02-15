using MBB.Abrigo.Core.Models;
using MBB.Abrigo.Infrastructure.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBB.Abrigo.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private BaseContext context;

        public PersonRepository (BaseContext context)
        {
            this.context = context;
        }

        public void Add(Person p)
        {
            context.Persons.Add(p);
            //context.SaveChanges();
        }

        public void Edit(Person p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }

        public Person FindById(int Id)
        {
            var result = (from r in context.Persons where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Persons;
        }

        public void Remove(int Id)
        {
            Person p = context.Persons.Find(Id);
            context.Persons.Remove(p);
            context.SaveChanges();
        }
    }
}
