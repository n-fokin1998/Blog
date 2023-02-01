using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// Entity of article.
    /// </summary>
    public class Article : Record
    {
        public string Name { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Article()
        {
            Feedbacks = new List<Feedback>();
            Tags = new List<Tag>();
        }
    }
}
