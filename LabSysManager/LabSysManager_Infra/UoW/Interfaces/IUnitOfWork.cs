using System.Threading.Tasks;

namespace LabSysManager_Infra.UoW.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        void Dispose();
    }
}
