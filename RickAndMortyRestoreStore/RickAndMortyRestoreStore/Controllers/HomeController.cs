using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RickAndMortyRestoreStore.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("FinishedJobs", Name = "Get_Jobs")]
        public ActionResult About()
        {
            var finishedJobs = JobServiceProvider.GetFinishedJobs();
            return View(finishedJobs);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Jobs/Previous/{name}/Entry", Name = "Job_Details")]
        public ActionResult PreviousJobs(string name)
        {
            var viewModel = new CommentsJobsViewModel();
            viewModel.Job = JobServiceProvider.GetJobByTitle(name);
            viewModel.Comments = new CommentsViewModel();
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Jobs/Previous/Entry")]
        public ActionResult PreviousJobs(CommentsViewModel payload)
        {
            var result = CommentServiceProvider.PostComment(payload);
            return RedirectToAction("About");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Extra/Contact/User/Form",Name = "Make_Rickquest")]
        public ActionResult Contact()
        {
            var requestViewModel = new RequestViewModel();
            return View(requestViewModel);
        }
    }
}