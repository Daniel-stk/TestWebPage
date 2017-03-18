using RickAndMortyRestoreStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Services
{
    public class ServiceProvider
    {
        private ApplicationDbContext _Context;
        

        public ServiceProvider(ApplicationDbContext context)
        {
            _Context = context; 
        }

        protected ApplicationDbContext Context
        {
            get
            {
                return _Context;
            }
        }
    }
}