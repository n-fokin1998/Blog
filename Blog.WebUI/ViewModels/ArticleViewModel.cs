using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels
{
    /// <summary>
    /// View Model for article.
    /// </summary>
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Content { get; set; }
    }
}