using Entities;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class GenericRepositoryMethodsTests
    {
        [Fact]
        public void AssignmentRepositoryGetByIdMethodReturnsCorrectOutput()
        {
            //Arrange
            SOSUPowerContext context = new();
            UnitOfWork unitOfWork = new(context);
            GenericRepository<Assignment> a = unitOfWork.AssignmentRepository;
            int AssignmentId = 1;
            int expectedOutputAssignment = AssignmentId;
            int actualOutputAssignment;

            //Act
            Assignment assignment = a.GetByID(AssignmentId);
            actualOutputAssignment = assignment.Id;

            //Assert
            Assert.Equal(expectedOutputAssignment, actualOutputAssignment);
        }

        [Fact]
        public void ResidentRepositoryGetByIdMethodReturnsCorrectOutput()
        {
            //Arrange
            SOSUPowerContext context = new();
            UnitOfWork unitOfWork = new(context);
            GenericRepository<Resident> r = unitOfWork.ResidentRepository;
            int ResidentId = 2;
            int expectedOutputResident = ResidentId;
            int actualOutputResident;

            //Act
            Resident resident = r.GetByID(ResidentId);
            actualOutputResident = resident.Id;

            //Assert
            Assert.Equal(expectedOutputResident, actualOutputResident);
        }

        [Fact]
        public void EmployeeRepositoryGetByIdMethodReturnsCorrectOutput()
        {
            //Arrange
            SOSUPowerContext context = new();
            UnitOfWork unitOfWork = new(context);
            GenericRepository<Employee> e = unitOfWork.EmployeeRepository;
            int EmployeeId = 2;
            int expectedOutputEmployee = EmployeeId;
            int actualOutputEmployee;

            //Act
            Employee employee = e.GetByID(EmployeeId);
            actualOutputEmployee = employee.Id;

            //Assert
            Assert.Equal(expectedOutputEmployee, actualOutputEmployee);
        }
    }
}