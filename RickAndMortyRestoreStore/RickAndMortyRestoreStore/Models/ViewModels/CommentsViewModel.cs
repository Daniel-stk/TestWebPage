﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models.ViewModels
{
    public class CommentsViewModel
    {
        public int JobId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
    }
}