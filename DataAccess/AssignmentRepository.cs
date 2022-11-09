using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Identity.Client;

namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<Assignment>
    {
        public AssignmentRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}