using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Domain.Infrastructure;

namespace Blog.Domain.Implemention
{
    /// <summary>
    /// Access the table of tags, using a common repository.
    /// </summary>
    public class TagRepository : AbstractRepository<Tag>
    {
        /// <summary>
        /// Transfer DB context to a common repository.
        /// </summary>
        /// <param name="context"></param>
        public TagRepository(BlogContext context) : base(context) { }
    }
}
