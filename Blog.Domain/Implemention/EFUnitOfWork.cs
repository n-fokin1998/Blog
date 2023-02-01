using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using Blog.Domain.Infrastructure;

namespace Blog.Domain.Implemention
{
    /// <summary>
    /// Common context for unified access to all repositories.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private ArticleRepository articleRepository;
        private FeedbackRepository feedbackRepository;
        private QuestionnaireRepository questionnaireRepository;
        private VotingFormRepository votingFormRepository;
        private TagRepository tagRepository;

        public EFUnitOfWork()
        {
            db = new BlogContext();
        }

        public IRepository<Article> Articles
        {
            get
            {
                return articleRepository 
                    ?? (articleRepository = new ArticleRepository(db));
            }
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                return feedbackRepository 
                    ?? (feedbackRepository = new FeedbackRepository(db));
            }
        }

        public IRepository<Questionnaire> Questionnairies
        {
            get
            {
                return questionnaireRepository 
                    ?? (questionnaireRepository = new QuestionnaireRepository(db));
            }
        }

        public IRepository<VotingForm> VotingForms
        {
            get
            {
                return votingFormRepository 
                    ?? (votingFormRepository = new VotingFormRepository(db));
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return tagRepository 
                    ?? (tagRepository = new TagRepository(db));
            }
        }
    }
}