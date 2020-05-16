using LabSysManager_Infra.UoW.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LabSysManager_Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext DbContext;
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> Commit()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
