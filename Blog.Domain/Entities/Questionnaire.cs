using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// Entity of questionnaire.
    /// </summary>
    public class Questionnaire
    {
        public int Id { get; set; }

        public string Referrer { get; set; }

        public string Design { get; set; }

        public string Recommend { get; set; }

        public string Interesting { get; set; }

        public string Improvement { get; set; }

        public string Comment { get; set; }
    }
}