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
    /// Access the table of voting forms, using a common repository.
    /// </summary>
    public class VotingFormRepository : AbstractRepository<VotingForm>
    {
        /// <summary>
        /// Transfer DB context to a common repository.
        /// </summary>
        /// <param name="context"></param>
        public VotingFormRepository(BlogContext context) : base(context) { }
    }
}