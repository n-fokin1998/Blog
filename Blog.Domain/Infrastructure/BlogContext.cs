using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Domain.Entities;
using Blog.Domain.IdentityService;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Domain.Infrastructure
{
    /// <summary>
    /// The main context of the database.
    /// </summary>
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext() : base("DefaultConnection") { }

        /// <summary>
        /// Table of articles.
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// Table of feedbacks.
        /// </summary>
        public DbSet<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Table of questionnairies.
        /// </summary>
        public DbSet<Questionnaire> Questionnairies { get; set; }

        /// <summary>
        /// Table of voting forms.
        /// </summary>
        public DbSet<VotingForm> VotingForms { get; set; }

        /// <summary>
        /// Table of tags.
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        public static BlogContext Create()
        {
            return new BlogContext();
        }
    }
}