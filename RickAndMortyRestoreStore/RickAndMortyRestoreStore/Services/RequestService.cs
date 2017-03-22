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

        public bool AddNewRequest(RequestViewModel viewModel, HttpPostedFileBase image,string route)
        {
            
            RequestModel model = new RequestModel()
            {
                UserEmail = viewModel.UserEmail,
                Description = viewModel.Description,
                UserName = viewModel.UserName,
                UserPhone = viewModel.UserPhone
            };
            if (image != null)
            {
                if ((image.ContentType.Equals("image/jpeg") || image.ContentType.Equals("image/png")) && image.ContentLength <= 2000000)
                {
                    string imageName = System.IO.Path.GetFileName(image.FileName);
                    string path = System.IO.Path.Combine(route, imageName);
               
                    image.SaveAs(path);
                    model.Media = viewModel.Media;
                }

            }
           
            return repository.Add(Context, model);     
        }

        public List<RequestViewModel> GetRequests()
        {
            var requests = repository.FindByCondition(Context.Requests,r => r.Job == null);
            return requests;
        } 

        public RequestViewModel GetRequest(int id)
        {
            return repository.FindById(Context.Requests,id);
        }
    }
}