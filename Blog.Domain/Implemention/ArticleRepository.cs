using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Domain.Entities;
using Blog.Domain.Infrastructure;

namespace Blog.Domain.Implemention
{
    /// <summary>
    /// Access to the article table, using a common repository.
    /// </summary>
    public class ArticleRepository : AbstractRepository<Article>
    {
        /// <summary>
        /// Transfer DB context to a common repository.
        /// </summary>
        /// <param name="context"></param>
        public ArticleRepository(BlogContext context) : base(context) { }
    }
}