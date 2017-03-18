using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RickAndMortyRestoreStore.Repositories
{
    public class RequestRepository : IRepository<RequestModel, RequestViewModel>
    {
        public bool Add(DbSet<RequestModel> entity, RequestModel model, Database db)
        {
            using(var transaction = db.BeginTransaction())
            {
                try
                {
                    entity.Add(model);
                    transaction.Commit();
                }catch
                {
                    return false;
                }
            }
            return true;
        }

        public bool Delete(DbSet<RequestModel> entity)
        {
            throw new NotImplementedException();
        }

        public List<RequestViewModel> FindByCondition(DbSet<RequestModel> entity, Expression<Func<RequestModel, bool>> expression)
        {
            List<RequestViewModel> result = new List<RequestViewModel>();
            IQueryable<RequestModel> query = entity.AsQueryable();
            var requests = query.Where(expression);
            foreach (var request in requests)
            {
                result.Add(new RequestViewModel()
                {
                    UserName = request.UserName,
                    UserPhone = request.UserPhone,
                    UserEmail = request.UserEmail,
                    Media = request.Media,
                    Description = request.Description
                });
            }
            return result;
        }

        public RequestViewModel FindById(DbSet<RequestModel> entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<RequestViewModel> GetAll(DbSet<RequestModel> entity)
        {
            List<RequestViewModel> result = new List<RequestViewModel>();
            IEnumerable<RequestModel> dataSet = entity.AsEnumerable();
            foreach(var request in dataSet)
            {
                result.Add(new RequestViewModel() {
                        UserName = request.UserName,
                        UserPhone = request.UserPhone,
                        UserEmail = request.UserEmail,
                        Media = request.Media,
                        Description = request.Description
                });
            }
            return result;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(DbSet<RequestModel> entity)
        {
            throw new NotImplementedException();
        }
    }
}