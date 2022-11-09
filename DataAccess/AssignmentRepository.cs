using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Identity.Client;

namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<AssignmentRepository>
    {
        public AssignmentRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}