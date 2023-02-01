using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Domain.Implemention;
using Blog.Domain.Entities;
using Blog.Domain.Abstract;
using Blog.WebUI.ViewModels;
using Blog.WebUI.Areas.Admin.Models;
using AutoMapper;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminPanelController : Controller
    {
        private IUnitOfWork repository;

        public AdminPanelController()
        {
            repository = new EFUnitOfWork();
        }

        public ActionResult Index()
        {
            var votingForms = repository.VotingForms.GetList();
            List<VotingFormViewModel> results = votingForms.GroupBy(v => v.Choise)
                .Select(g => new VotingFormViewModel { Choise = g.Key, Votes = g.Count() })
                .OrderByDescending(r => r.Votes).ThenBy(r => r.Choise).ToList();
            return View(results);
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            MultiSelectList tags = new MultiSelectList(repository.Tags.GetList(), nameof(Tag.Id), nameof(Tag.Name));
            ViewBag.Tags = tags;
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(ArticleViewModel model, string[] Tags)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleViewModel, Article>();
                }).CreateMapper();
                var article = config.Map<ArticleViewModel, Article>(model);
                if (Tags != null)
                {
                    foreach (string tag in Tags)
                    {
                        article.Tags.Add(repository.Tags.GetItem(int.Parse(tag)));
                    }
                }
                repository.Articles.AddItem(article);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            MultiSelectList tags = new MultiSelectList(repository.Tags.GetList(), nameof(Tag.Id), nameof(Tag.Name));
            ViewBag.Tags = tags;
            return View();
        }

        [HttpGet]
        public ActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTag(string newTagName)
        {
            if(!String.IsNullOrEmpty(newTagName))
            {
                var tag = repository.Tags.GetList().Where(t => t.Name == newTagName).FirstOrDefault();
                if(tag != null)
                {
                    ViewBag.ErrorMessage = "Тэг с таким именем уже существует!";
                    return View();
                }
                var newTag = new Tag() { Name = newTagName };
                repository.Tags.AddItem(newTag);
                return RedirectToAction("Index", "AdminPanel");
            }
            ViewBag.ErrorMessage = "Введите название нового тэга!";
            return View();
        }
    }
}