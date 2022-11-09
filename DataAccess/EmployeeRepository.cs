using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(SOSUPowerContext context) : base(context)
        {
        }
    }
}