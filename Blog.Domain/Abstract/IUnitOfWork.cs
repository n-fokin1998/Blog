using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;

namespace Blog.Domain.Abstract
{
    /// <summary>
    /// A set of methods for the general context of all repositories.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repository for articles.
        /// </summary>
        IRepository<Article> Articles { get; }

        /// <summary>
        /// Repository for feedbacks.
        /// </summary>
        IRepository<Feedback> Feedbacks { get; }

        /// <summary>
        /// Repository for questionnairies.
        /// </summary>
        IRepository<Questionnaire> Questionnairies { get; }

        /// <summary>
        /// Repository for voting forms.
        /// </summary>
        IRepository<VotingForm> VotingForms { get; }

        /// <summary>
        /// Repository for tags.
        /// </summary>
        IRepository<Tag> Tags { get; }
    }
}