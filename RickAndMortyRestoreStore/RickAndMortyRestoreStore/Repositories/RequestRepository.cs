using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RickAndMortyRestoreStore.Repositories
{
    public class RequestRepository : IRepository<RequestModel, RequestViewModel>
    {
        
        public bool Add(ApplicationDbContext context, RequestModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Requests.Add(model);
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

        public bool Delete(ApplicationDbContext context, RequestModel model)
        {
            throw new NotImplementedException();
        }

        public List<RequestViewModel> FindByCondition(DbSet<RequestModel> entity, Expression<Func<RequestModel, bool>> expression)
        {
            List<RequestViewModel> result = new List<RequestViewModel>();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var baseMedia = urlHelper.Content("~/Content/img/Rickquest/Before");
            IQueryable<RequestModel> query = entity.AsQueryable();
            var requests = query.Where(expression);
            foreach (var request in requests)
            {
                result.Add(new RequestViewModel()
                {
                    RequestId = request.RequestId,
                    UserName = request.UserName,
                    UserPhone = request.UserPhone,
                    UserEmail = request.UserEmail,
                    Media = request.Media,
                    Description = request.Description,
                    RouteMedia = System.IO.Path.Combine(baseMedia, request.Media)
                });
            }
            return result;
        }

        public RequestViewModel FindById(DbSet<RequestModel> entity, int id)
        {
            var record = entity.Find(id);
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var baseMedia = urlHelper.Content("~/Content/img/Rickquest/Before");
            var result = new RequestViewModel();

            result.RequestId = record.RequestId;
            result.UserEmail = record.UserEmail;
            result.UserName = record.UserName;
            result.UserPhone = record.UserPhone;
            result.Media = record.Media;
            result.Description = record.Description;
            result.RouteMedia = System.IO.Path.Combine(baseMedia, result.Media);

            return result;
        }

        public List<RequestViewModel> GetAll(DbSet<RequestModel> entity)
        {
            List<RequestViewModel> result = new List<RequestViewModel>();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var baseMedia = urlHelper.Content("~/Content/img/Rickquest/Before");
            IEnumerable<RequestModel> dataSet = entity.AsEnumerable();
            foreach(var request in dataSet)
            {
                result.Add(new RequestViewModel() {
                        UserName = request.UserName,
                        UserPhone = request.UserPhone,
                        UserEmail = request.UserEmail,
                        Media = request.Media,
                        Description = request.Description,
                        RouteMedia = System.IO.Path.Combine(baseMedia,request.Media)

            });
            }
            return result;
        }

        public bool Update(ApplicationDbContext context, RequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}