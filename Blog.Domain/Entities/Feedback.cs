using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// Entity of feedback.
    /// </summary>
    public class Feedback : Record
    {
        public string Author { get; set; }

        public int? ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}