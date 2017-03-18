using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RickAndMortyRestoreStore.Models;
using RickAndMortyRestoreStore.Models.ViewModels;

namespace RickAndMortyRestoreStore.Services
{
    public class CommentService : ServiceProvider
    {
        public CommentService(ApplicationDbContext context) : base(context)
        {
        }

        public bool PostComment(CommentsViewModel payload)
        {
            return false;
        }
    }
}