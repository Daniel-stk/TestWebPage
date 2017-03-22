using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Web.Mvc;

namespace RickAndMortyRestoreStore.Repositories
{
    public class JobRepository : IRepository<JobModel, JobViewModel>
    {
        public bool Add(ApplicationDbContext context, JobModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ApplicationDbContext context, JobModel model)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> FindByCondition(DbSet<JobModel> entity, Expression<Func<JobModel, bool>> expression)
        {
            List<JobViewModel> result = new List<JobViewModel>();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var baseBefore = urlHelper.Content("~/Content/img/Rickquest/Before");
            var baseAfter = urlHelper.Content("~/Content/img/Rickquest/After");
            IQueryable<JobModel> query = entity.AsQueryable();
            var Jobs = query.Where(expression);
            foreach(var Job in Jobs)
            {
                result.Add(new JobViewModel() {
                    JobId = Job.JobId,
                    ActualState = Job.State,
                    Description = Job.Description,
                    MediaAfter = Job.MediaAfter,
                    MediaBefore = Job.MediaBefore,
                    StartDate = Job.StartDate,
                    Name = Job.Name,
                    EndDate = Job.EndDate,
                    Comments = new List<CommentsViewModel>(),
                    RouteMediaBefore = System.IO.Path.Combine(baseBefore, Job.MediaBefore),
                    RouteMediaAfter = System.IO.Path.Combine(baseAfter, Job.MediaAfter)
                });
                if(Job.Comments != null)
                {
                   var commentsViewModel =  result.Where(j => j.JobId == Job.JobId).FirstOrDefault().Comments; 
                   foreach(var comment in Job.Comments)
                   {
                        commentsViewModel.Add(new CommentsViewModel() {
                            UserName = comment.UserName,
                            Comment = comment.CommentText
                        });    
                   }
                }

            }
            return result;

        }

        public JobViewModel FindById(DbSet<JobModel> entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> GetAll(DbSet<JobModel> entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApplicationDbContext context, JobModel model)
        {
            throw new NotImplementedException();
        }
    }
}