using Entities;

namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<Assignment>
    {
        public AssignmentRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}