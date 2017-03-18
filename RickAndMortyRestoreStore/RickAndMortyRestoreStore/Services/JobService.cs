using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using RickAndMortyRestoreStore.Repositories;

namespace RickAndMortyRestoreStore.Services
{
    public class JobService : ServiceProvider
    {
        private JobRepository repository;
        public JobService(ApplicationDbContext context) : base(context)
        {
            repository = new JobRepository();
        }

        public List<JobViewModel> GetFinishedJobs()
        {
            return repository.FindByCondition(Context.Jobs,j => j.State.Equals("Done"));
            
        }

        public JobViewModel GetJobByTitle(string title)
        {
            return repository.FindByCondition(Context.Jobs, j => j.Name.Equals(title)).FirstOrDefault();
        }


    }
}