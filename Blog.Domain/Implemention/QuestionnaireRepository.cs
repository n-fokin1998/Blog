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
    /// Access the table of questionnairies, using a common repository.
    /// </summary>
    public class QuestionnaireRepository : AbstractRepository<Questionnaire>
    {
        /// <summary>
        /// Transfer DB context to a common repository.
        /// </summary>
        /// <param name="context"></param>
        public QuestionnaireRepository(BlogContext context) : base(context) { }
    }
}