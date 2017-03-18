using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RickAndMortyRestoreStore.Repositories
{
    public class JobRepository : IRepository<JobModel, JobViewModel>
    {
        public bool Add(DbSet<JobModel> entity, JobModel model, Database db)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DbSet<JobModel> entity)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> FindByCondition(DbSet<JobModel> entity, Expression<Func<JobModel, bool>> expression)
        {
            List<JobViewModel> result = new List<JobViewModel>();
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
                    Comments = new List<CommentsViewModel>()
                });
                if(Job.Comments != null)
                {
                    result.Where(j => j.JobId == Job.JobId).FirstOrDefault().Comments = (List<CommentsViewModel>)Job.Comments;
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

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(DbSet<JobModel> entity)
        {
            throw new NotImplementedException();
        }
    }
}