using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// Entity of voting form
    /// </summary>
    public class VotingForm
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Choise { get; set; }
    }
}
