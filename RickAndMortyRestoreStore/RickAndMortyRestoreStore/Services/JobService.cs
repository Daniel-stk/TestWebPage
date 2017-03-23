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

        public bool AddJob(AddJobViewModel viewModel)
        {
            var model = new JobModel();
            var request = Context.Requests.Find(viewModel.RequestId);
            model.Amount = viewModel.Amount;
            model.Description = viewModel.Description;
            model.MediaBefore = request.Media;
            model.Name = viewModel.Title;
            model.State = "Pending";
            model.StartDate = DateTime.Now;
            model.JobId = viewModel.RequestId;
            
            return repository.Add(Context,model);
        }

        public List<JobViewModel> GetFinishedJobs()
        {
            return repository.FindByCondition(Context.Jobs,j => j.State.Equals("Done"));
            
        }

        public List<JobViewModel> GetPendingJobs()
        {
            return repository.FindByCondition(Context.Jobs, j => j.State.Equals("Pending"));
        }

        public JobViewModel GetJobByTitle(string title)
        {
           return repository.FindByCondition(Context.Jobs, j => j.Name.Equals(title)).FirstOrDefault();
        }

        public JobViewModel GetJobDetails(int JobId)
        {
            return repository.FindById(Context.Jobs, JobId);
        }

        public bool FinishJob(int JobId, HttpPostedFileBase image, string route)
        {
            var modelToUpdate = Context.Jobs.Find(JobId);

            if (image != null)
            {
                if ((image.ContentType.Equals("image/jpeg") || image.ContentType.Equals("image/png")) && image.ContentLength <= 2000000)
                {
                    string imageName = System.IO.Path.GetFileName(image.FileName);
                    string path = System.IO.Path.Combine(route, imageName);

                    image.SaveAs(path);
                    modelToUpdate.MediaAfter = image.FileName;
                }

            }

            repository.Update(Context, modelToUpdate);
            return false;
        }

    }
}