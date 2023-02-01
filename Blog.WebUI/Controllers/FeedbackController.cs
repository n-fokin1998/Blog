using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Domain.Implemention;
using Blog.Domain.Entities;
using Blog.Domain.Abstract;
using Blog.Domain.IdentityService;
using Blog.WebUI.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.WebUI.Controllers
{
    public class FeedbackController : Controller
    {
        private IUnitOfWork repository;

        public FeedbackController()
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
            var feedbackList = new List<Feedback>();
            foreach(var f in repository.Feedbacks.GetList())
            {
                if (f.ArticleId == null)
                    feedbackList.Add(f);
            }
            feedbackList = feedbackList.OrderByDescending(f => f.Date).ToList();
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Feedback, FeedbackViewModel>();
            }).CreateMapper();
            var feedbacks = config.Map<List<Feedback>, List<FeedbackViewModel>>(feedbackList);
            if (TempData["ContentError"] != null)
                ModelState.AddModelError(nameof(Feedback.Content), TempData["ContentError"].ToString());
            if (TempData["Feedback"] != null)
                ViewBag.Feedback = (FeedbackViewModel)TempData["Feedback"];
            return View(feedbacks);
        }

        [Authorize]
        public ActionResult AddFeedback(FeedbackViewModel model)
        {
            TempData["Feedback"] = model;
            if (ModelState.IsValid)
            {
                TempData["Feedback"] = null;
                if (GetCurrentUser().Name != null)
                    model.Author = GetCurrentUser().Name;
                else
                    model.Author = GetCurrentUser().UserName;
                model.Date = DateTime.Now;
                var config = new MapperConfiguration(cfg => 
                {
                    cfg.CreateMap<FeedbackViewModel, Feedback>();
                }).CreateMapper();
                var feedback = config.Map<FeedbackViewModel, Feedback>(model);
                repository.Feedbacks.AddItem(feedback);
                return RedirectToAction("Index", "Feedback");
            }
            if (!ModelState.IsValidField(nameof(Feedback.Content)))
                TempData["ContentError"] = "Поле обязательно для заполнения!";
            return RedirectToAction("Index", "Feedback");
        }

        public ApplicationUser GetCurrentUser()
        {
            return UserManager.FindById(User.Identity.GetUserId());
        }
    }
}