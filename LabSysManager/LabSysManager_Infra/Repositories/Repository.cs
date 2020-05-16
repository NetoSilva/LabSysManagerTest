using LabSysManager_Domain_Core.Models;
using LabSysManager_Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysManager_Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
        private DbContext DbContext;
        private DbSet<T> DbSet;
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            if (entity != null)
            {
                await DbSet.AddAsync(entity);
            }
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
    }
}
