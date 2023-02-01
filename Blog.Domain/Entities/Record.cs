using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// Base class for records on the site.
    /// </summary>
    public class Record
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}