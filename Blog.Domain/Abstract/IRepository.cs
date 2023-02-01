using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
    /// <summary>
    /// Generic - repository with a set of methods
    /// for accessing the database context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all records from table.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetList();

        /// <summary>
        /// Get a specific record by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItem(int id);

        /// <summary>
        /// Add a record to the table.
        /// </summary>
        /// <param name="item"></param>
        void AddItem(T item);

        /// <summary>
        /// Update a specific record.
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
    }
}