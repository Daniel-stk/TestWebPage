using Microsoft.Ajax.Utilities;
using RickAndMortyRestoreStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyRestoreStore.Repositories
{
    interface IRepository<T,K> where T :class  where K: class
    {
       
        bool Add(ApplicationDbContext context,T model);
        bool Update(ApplicationDbContext context,T model);
        bool Delete(ApplicationDbContext context, T model);
        List<K> GetAll(DbSet<T> entity);
        K FindById(DbSet<T> entity, int id);
        List<K> FindByCondition(DbSet<T> entity,Expression<Func<T,bool>> expression);

    }
}
