using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class ResidentRepository : GenericRepository<ResidentRepository>
    {
        public ResidentRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}