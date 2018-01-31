using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ReportingDataBase.DAL
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class, IEntity where C : DatabaseContext, new()
    {
        public C context { get; set; }

        public virtual List<T> GetAll()
        {
            List<T> query = context.Set<T>().ToList();
            return query;
        }

        public List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            List<T> query = context.Set<T>().Where(predicate).ToList();
            return query;
        }

        public T Get(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}