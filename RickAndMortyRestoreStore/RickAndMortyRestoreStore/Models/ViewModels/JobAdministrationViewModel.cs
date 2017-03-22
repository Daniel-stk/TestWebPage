using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models.ViewModels
{
    public class JobAdministrationViewModel
    {
        public List<JobViewModel> PendingJobs { get; set; }
        public List<JobViewModel> FinishedJobs { get; set; }
        public List<RequestViewModel> Rickquests { get; set; }
    }

    public class RequestToJobViewModel
    {
        public RequestViewModel Request { get; set; }
        public AddJobViewModel JobField { get; set; }
    }

    public class AddJobViewModel
    {
        public int RequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

    }
}