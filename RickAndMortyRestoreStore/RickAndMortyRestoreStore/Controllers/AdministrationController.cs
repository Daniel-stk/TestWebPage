using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RickAndMortyRestoreStore.Controllers
{
    public class AdministrationController:BaseController
    {
        [Authorize(Roles ="ShopOwner, ShopAdministrator")]
        [HttpGet]
        [Route("Administration/Rickquest",Name ="Administration_Rickquest")]
        public ActionResult RequestAdministration()
        {
           
            var viewModel = new JobAdministrationViewModel();
            viewModel.PendingJobs = JobServiceProvider.GetPendingJobs();
            viewModel.FinishedJobs = JobServiceProvider.GetFinishedJobs();
            viewModel.Rickquests = RequestServiceProvider.GetRequests();
            if (TempData["success"] != null)
            {
                ViewBag.Success = "Noooww l-l-et's get Schwifty!!";
            }
            if (TempData["failed"] != null)
            {
                ViewBag.Failed = "Seems we can't take this Rickquest";
            }
            return View(viewModel);
        }

        [Authorize(Roles="ShopOwner, ShopAdministrator")]
        [HttpGet]
        [Route("Administration/Rickquest/{RequestId}",Name ="Request_To_Job")]
        public ActionResult RequestToJob(int RequestId)
        {
            var viewModel = new RequestToJobViewModel();
            viewModel.Request = RequestServiceProvider.GetRequest(RequestId);
            viewModel.JobField = new AddJobViewModel();
            return View(viewModel);      
        }

        [Authorize(Roles = "ShopOwner, ShopAdministrator")]
        [HttpPost]
        [Route("Administration/RickquestToJob")]
        [ValidateAntiForgeryToken()]
        public ActionResult RequestToJob(RequestToJobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.JobField.RequestId = viewModel.Request.RequestId;
                var success = JobServiceProvider.AddJob(viewModel.JobField);
                if(success)
                {
                    TempData["success"] = true;
                }
                else
                {
                    TempData["failed"] = true;
                }
            }
            return RedirectToAction("RequestAdministration");
        }

        [Authorize(Roles = "ShopOwner, ShopAdministrator")]
        [HttpGet]
        [Route("Administration/Job/{JobId}", Name = "Get_Job")]
        public ActionResult JobDetails(int JobId)
        {
            var viewModel = JobServiceProvider.GetJobDetails(JobId);
            return View(viewModel);
        }
 

        [Authorize(Roles = "ShopOwner, ShopAdministrator")]
        [HttpPost]
        [Route("Administration/Job/FinishJob",Name = "Finish_Job")]
        [ValidateAntiForgeryToken()]
        public ActionResult FinishJob(int JobId,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            { 
                string route = Server.MapPath("~/Content/img/Rickquest/After");
                var success = JobServiceProvider.FinishJob(JobId,image,route);
            }
            return RedirectToAction("RequestAdministration");
        }
    }
}
