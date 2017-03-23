using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;
using RickAndMortyRestoreStore.Repositories;

namespace RickAndMortyRestoreStore.Services
{
    public class CommentService : ServiceProvider
    {
        CommentsRepository repository;
        public CommentService(ApplicationDbContext context) : base(context)
        {
            repository = new CommentsRepository();
        }

        public bool PostComment(JobViewModel payload)
        {
            CommentModel model = new CommentModel() {
                    JobId = payload.JobId,
                    UserName = payload.UserName,
                    CommentText = payload.Comment
            };
            return repository.Add(Context,model);
        }

        public List<CommentsViewModel> GetCommentsByJobId(int JobId)
        {
            return repository.FindByCondition(Context.Comments,c => c.JobId == JobId);
        }
    }
}