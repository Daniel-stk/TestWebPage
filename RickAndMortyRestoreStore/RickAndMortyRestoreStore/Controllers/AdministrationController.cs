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
        [ValidateAntiForgeryToken()]
        public ActionResult RequestToJob(AddJobViewModel job)
        {
            return RedirectToAction("RequestAdministration");
        }
    }
}
