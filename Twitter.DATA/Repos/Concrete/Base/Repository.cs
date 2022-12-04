using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Repos.Base;

namespace Twitter.DATA.Repos.Concrete.Base
{
    public class Repository<MyEntity> : IRepository<MyEntity> where MyEntity : class
    {
        protected readonly DbContext context;
        private readonly DbSet<MyEntity> dbSet;
        public Repository(DbContext eContext)
        {
            if (eContext == null)
            throw new ArgumentNullException("dbContext can not be null.");
            context = eContext;
            dbSet = context.Set<MyEntity>();
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
    }
}
