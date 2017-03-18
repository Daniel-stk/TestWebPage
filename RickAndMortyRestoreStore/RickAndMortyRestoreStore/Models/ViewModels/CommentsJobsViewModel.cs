using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models.ViewModels
{
    public class CommentsJobsViewModel
    {
        public JobViewModel Job { get; set; }
        public CommentsViewModel Comments { get; set; }
    }
}