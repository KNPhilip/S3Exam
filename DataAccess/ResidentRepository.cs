using Entities;

namespace DataAccess
{
    public class ResidentRepository : GenericRepository<Resident>
    {
        public ResidentRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}