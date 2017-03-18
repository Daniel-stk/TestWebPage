using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Repositories;
using RickAndMortyRestoreStore.Models.ViewModels;

namespace RickAndMortyRestoreStore.Services
{
    public class RequestService : ServiceProvider
    {
        private RequestRepository repository;
        public RequestService(ApplicationDbContext context) : base(context)
        {
            repository = new RequestRepository();
        }

        public bool AddNewRequest(RequestViewModel viewModel)
        {
                RequestModel model = new RequestModel()
                {
                    UserEmail = viewModel.UserEmail,
                    Description = viewModel.Description,
                    Media = viewModel.Media,
                    UserName = viewModel.UserName,
                    UserPhone = viewModel.UserPhone
                };
                repository.Add(Context.Requests, model,Context.Database);
                return false;
        }

        public List<RequestViewModel> GetPendingRequest()
        {
            var requests = repository.FindByCondition(Context.Requests,r => r.Job == null);
            return requests;
        } 
    }
}