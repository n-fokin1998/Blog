using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels
{
    /// <summary>
    /// View Model for feedback.
    /// </summary>
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Content { get; set; }
    }
}