using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class EmployeeRepository : GenericRepository<EmployeeRepository>
    {
        public EmployeeRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}