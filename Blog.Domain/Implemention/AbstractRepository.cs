using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Domain.Abstract;
using Blog.Domain.Infrastructure;

namespace Blog.Domain.Implemention
{
    /// <summary>
    /// General implementation of the repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        private BlogContext db;

        protected AbstractRepository(BlogContext context)
        {
            db = context;
        }

        public IQueryable<T> GetList()
        {
            return db.Set<T>();
        }

        public T GetItem(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void AddItem(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}