using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReportingDataBase.DAL
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
