using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Areas.Admin.Models
{
    /// <summary>
    /// View Model for results of voting.
    /// </summary>
    public class VotingFormViewModel
    {
        public string Choise { get; set; }

        public int Votes { get; set; }
    }
}