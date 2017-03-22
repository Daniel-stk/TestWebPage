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
            var job = JobServiceProvider.GetJobByTitle(name);
            if (TempData["success"] != null)
            {
                ViewBag.Success = "Your comment was posted I hope you are happy about it";
            }
            if(TempData["failed"] != null)
            {
                ViewBag.Failed = "No comment posted sooon";
            }
            return View(job);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Jobs/Previous/Entry")]
        public ActionResult PreviousJobs(CommentsViewModel payload)
        {
            var success = CommentServiceProvider.PostComment(payload);
            if (success)
            {
                TempData["success"] = true;
            }else
            {

                TempData["failed"] = true;
            }
            return RedirectToAction("PreviousJobs");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Extra/Contact/User/Form",Name = "Make_Rickquest")]
        public ActionResult Contact()
        {
            var requestViewModel = new RequestViewModel();
            if (TempData["success"] != null)
            {
                ViewBag.Success = "Your Rickquest was posted let's get schwifty!!";
               
            }
            if (TempData["failed"] != null)
            {
                ViewBag.Failed = "Man!. There was a problem with your Rickquest!! Maybe it was a success on a parallel timeline";
            }
            return View(requestViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken()]
        [Route("Extra/Contact/User/Form/Request",Name ="Rickquest_Posted")]
        public ActionResult MakeRickquest(RequestViewModel model, HttpPostedFileBase image)
        {
            
            if (ModelState.IsValid)
            {
               var route = Server.MapPath("~/Content/img/Rickquest/Before"); 
               var success = RequestServiceProvider.AddNewRequest(model,image,route);
                if (success)
                {
                    TempData["success"] = true;
                }
                else
                {
                    TempData["failed"] = true;
                }     

            }
            
            return RedirectToAction("Contact");
        }
    }
}