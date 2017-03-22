using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace RickAndMortyRestoreStore.Repositories
{
    public class CommentsRepository : IRepository<CommentModel, CommentsViewModel>
    {
        public bool Add(ApplicationDbContext context, CommentModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Comments.Add(model);
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

        public bool Delete(ApplicationDbContext context, CommentModel model)
        {
            throw new NotImplementedException();
        }

        public List<CommentsViewModel> FindByCondition(DbSet<CommentModel> entity, Expression<Func<CommentModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public CommentsViewModel FindById(DbSet<CommentModel> entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<CommentsViewModel> GetAll(DbSet<CommentModel> entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApplicationDbContext context, CommentModel model)
        {
            throw new NotImplementedException();
        }
    }
}