using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBB.Abrigo.Infrastructure.IManagers
{
    public interface IGenericManager<TEntity> where TEntity : class
    {
        string Add(TEntity p);
        string Edit(TEntity p);
        string Remove(string Id);
        IEnumerable<TEntity> GetAll();
        TEntity FindById(string Id);
    }
}
