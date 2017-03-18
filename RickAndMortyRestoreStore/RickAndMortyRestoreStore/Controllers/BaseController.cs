using Microsoft.AspNet.Identity.Owin;
using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RickAndMortyRestoreStore.Controllers
{
    public class BaseController:Controller
    {
        private ApplicationRoleManager _RoleManager = null;
        private ApplicationDbContext _Context = null;
        private JobService _JobServiceProvider = null;
        private RequestService _RequestServiceProvider = null;
        private CommentService _CommentServiceProvider = null;
         

        public BaseController() : base() { }

        protected ApplicationRoleManager RoleManager
        {
            get
            {
                return _RoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        protected ApplicationDbContext Context
        {
            get
            {
                return _Context ?? Request.GetOwinContext().Get<ApplicationDbContext>();
            }
        }

        protected JobService JobServiceProvider
        {
            get
            {
                return _JobServiceProvider ?? new JobService(Context);
            }
        }

        protected RequestService RequestServiceProvider
        {
            get
            {
                return _RequestServiceProvider ?? new RequestService(Context);
            }
        }

        protected CommentService CommentServiceProvider
        {
            get
            {
                return _CommentServiceProvider ?? new CommentService(Context);
            }
        }
    }
}