using LabSysManager_Domain_Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabSysManager_Infra.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity<T>
    {
        Task Create(T entity);
        Task<IEnumerable<T>> ReadAll();
    }
}
