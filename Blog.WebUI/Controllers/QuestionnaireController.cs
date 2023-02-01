using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using Blog.Domain.Implemention;
using Blog.Domain.Entities;
using Blog.Domain.Abstract;
using Blog.WebUI.ViewModels;
using AutoMapper;

namespace Blog.WebUI.Controllers
{
    public class QuestionnaireController : Controller
    {
        private IUnitOfWork repository;

        public QuestionnaireController()
        {
            repository = new EFUnitOfWork();
        }

        public ActionResult PassSurvey(QuestionnaireViewModel model, string[] improves)
        {
            if (HttpContext.Request.HttpMethod.ToUpper() == "POST")
            {
                if (improves != null)
                {
                    var strBuilder = new StringBuilder();
                    foreach (string s in improves)
                    {
                        strBuilder.Append(s);
                        if (improves[improves.Count() - 1] == s)
                            break;
                        strBuilder.Append(", ");
                    }
                    model.Improvement = strBuilder.ToString();
                }
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<QuestionnaireViewModel, Questionnaire>();
                }).CreateMapper();
                var questionnaire = config.Map<QuestionnaireViewModel, Questionnaire>(model);
                repository.Questionnairies.AddItem(questionnaire);
                return RedirectToAction("Result", "Questionnaire");
            }
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }
    }
}