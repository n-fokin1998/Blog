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
    /// Access the table of reviews, using a common repository.
    /// </summary>
    public class FeedbackRepository : AbstractRepository<Feedback>
    {
        /// <summary>
        /// Transfer DB context to a common repository.
        /// </summary>
        /// <param name="context"></param>
        public FeedbackRepository(BlogContext context) : base(context) { }
    }
}