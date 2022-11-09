using Entities;


namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private readonly SOSUPowerContext context;
        private AssignmentRepository assignmentRepository;
        private EmployeeRepository employeeRepository;
        private ResidentRepository residentRepository;

        public UnitOfWork(SOSUPowerContext context)
        {
            this.context = context;
        }

        public AssignmentRepository AssignmentRepository
        {
            get
            {
                this.assignmentRepository ??= new AssignmentRepository(context);
                return assignmentRepository;
            }
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                this.employeeRepository ??= new EmployeeRepository(context);
                return employeeRepository;
            }
        }

        public ResidentRepository ResidentRepository
        {
            get
            {
                this.residentRepository ??= new ResidentRepository(context);
                return residentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}