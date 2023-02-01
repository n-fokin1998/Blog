using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels
{
    /// <summary>
    /// View Model for questionnaire.
    /// </summary>
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Откуда Вы узнали о нашем сайте?")]
        public string Referrer { get; set; }

        [Display(Name = "Нравится ли Вам дизайн сайта?")]
        public string Design { get; set; }

        [Display(Name = "Вы бы рекомендовали этот сайт другим людям?")]
        public string Recommend { get; set; }

        [Display(Name = "Считаете ли Вы тематику сайта интересной?")]
        public string Interesting { get; set; }

        [Display(Name = "Что из предложенного Вы бы хотели видеть на нашем сайте?")]
        public string Improvement { get; set; }

        [Display(Name = "Дополнительные комментарии и пожелания.")]
        public string Comment { get; set; }
    }
}