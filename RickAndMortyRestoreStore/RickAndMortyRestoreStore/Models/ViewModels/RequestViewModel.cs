using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models.ViewModels
{
    public class RequestViewModel
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string Description { get; set; }
        public string Media { get; set; }
    }
}