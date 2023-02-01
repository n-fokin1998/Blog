using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Domain.Implemention;
using Blog.Domain.Entities;
using Blog.Domain.Abstract;
using Blog.WebUI.ViewModels;
using Blog.WebUI.Filters;
using Blog.Domain.IdentityService;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork repository;

        public HomeController()
        {
            repository = new EFUnitOfWork();
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Index()
        {
            IEnumerable<Article> articleList = repository.Articles
                .GetList().OrderByDescending(a => a.Date);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleViewModel>();
            }).CreateMapper();
            var articles = config.Map<IEnumerable<Article>, List<ArticleViewModel>>(articleList);
            return View(articles);
        }

        public ActionResult OpenArticle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            var article = repository.Articles.GetItem((int)id);
            if (article == null)
                return RedirectToAction("Index", "Home");
            article.Feedbacks = article.Feedbacks.OrderByDescending(f => f.Date).ToList();
            return View(article);
        }

        [Authorize]
        public ActionResult AddComment(FeedbackViewModel comment, int articleId)
        {
            var article = repository.Articles.GetItem(articleId);
            if (GetCurrentUser().Name != null)
                comment.Author = GetCurrentUser().Name;
            else
                comment.Author = GetCurrentUser().UserName;
            comment.Date = DateTime.Now;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FeedbackViewModel, Feedback>();
            }).CreateMapper();
            var newComment = config.Map<FeedbackViewModel, Feedback>(comment);
            article.Feedbacks.Add(newComment);
            repository.Articles.Update(article);
            return RedirectToAction("OpenArticle", "Home", new { id = articleId });
        }

        [CheckContext]
        [ChildActionOnly]
        public ActionResult Vote()
        {
            DateTime weekBefore = DateTime.Today.AddDays(-7);
            List<Article> articles = repository.Articles.GetList()
                .Where(a => a.Date >= weekBefore).OrderByDescending(a => a.Date).ToList();
            var titles = new string[articles.Count()];
            for (int i = 0; i < articles.Count(); i++)
            {
                titles[i] = articles[i].Name;
            }
            return PartialView(titles);
        }

        [HttpPost]
        [Authorize]
        public ActionResult PassVoting(VotingForm model)
        {
            model.Date = DateTime.Now;
            repository.VotingForms.AddItem(model);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SearchByTag(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            var tag = repository.Tags.GetItem((int)id);
            if (tag == null)
                return RedirectToAction("Index", "Home");
            List<Article> articleList = tag.Articles.OrderByDescending(a => a.Date).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleViewModel>();
            }).CreateMapper();
            var articles = config.Map<List<Article>, List<ArticleViewModel>>(articleList);
            ViewBag.TagName = tag.Name;
            return View(articles);
        }

        public ApplicationUser GetCurrentUser()
        {
            return UserManager.FindById(User.Identity.GetUserId());
        }
    }
}