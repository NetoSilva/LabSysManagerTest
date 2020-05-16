using LabSysManager_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LabSysManager_Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
