using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<AssignmentRepository>
    {
        public AssignmentRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}