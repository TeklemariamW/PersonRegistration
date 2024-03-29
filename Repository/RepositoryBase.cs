using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repoContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repoContext= repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
           return _repoContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _repoContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity)
        {
            _repoContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _repoContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _repoContext.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _repoContext.SaveChanges();
        }
    }
}
