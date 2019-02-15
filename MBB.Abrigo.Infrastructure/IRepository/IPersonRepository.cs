using MBB.Abrigo.Core.Models;
using MBB.Abrigo.Infrastructure.IRepository;
using System.Collections;
using System.Collections.Generic;

namespace MBB.Abrigo.Infrastructure.IRepository
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        new void Add(Person p);
        new void Edit(Person p);
        new void Remove(int Id);
        new IEnumerable<Person> GetAll();
        new Person FindById(int Id);
    }
}
