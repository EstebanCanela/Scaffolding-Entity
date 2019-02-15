using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBB.Abrigo.Infrastructure.IManagers
{
    public interface IGenericManager<TEntity> where TEntity : class
    {
        void Add(TEntity p);
        void Edit(TEntity p);
        void Remove(int Id);
        IEnumerable<TEntity> GetAll();
        TEntity FindById(int Id);
    }
}
