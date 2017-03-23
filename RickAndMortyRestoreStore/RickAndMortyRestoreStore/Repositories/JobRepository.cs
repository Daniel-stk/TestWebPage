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
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Jobs.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    return false;
                }
            }
            return true;
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
                    RouteMediaBefore = System.IO.Path.Combine(baseBefore, Job.MediaBefore),
                });
                if (Job.MediaAfter != null)
                {
                    result.Where(j => j.JobId == Job.JobId).FirstOrDefault().RouteMediaAfter = System.IO.Path.Combine(baseAfter, Job.MediaAfter);
                }
                
           }
            return result;

        }

        public JobViewModel FindById(DbSet<JobModel> entity, int id)
        {
            var viewModel = new JobViewModel();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var baseBefore = urlHelper.Content("~/Content/img/Rickquest/Before");
            var model = entity.Find(id);

            viewModel.RouteMediaBefore = System.IO.Path.Combine(baseBefore, model.MediaBefore);
            viewModel.Name = model.Name;
            viewModel.StartDate = model.StartDate;
            viewModel.JobId = model.JobId;
            viewModel.Description = model.Description;

            return viewModel;
            
        }

        public List<JobViewModel> GetAll(DbSet<JobModel> entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApplicationDbContext context, JobModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    model.EndDate = DateTime.Now;
                    model.State = "Done";
                    context.Entry(model).State = EntityState.Modified;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}