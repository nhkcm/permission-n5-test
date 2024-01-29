using Microsoft.Extensions.Logging;
using Moq;
using N5TLTest.Commands.Employee;
using N5TLTest.Database.repositories;
using N5TLTest.Handlers;

namespace N5Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public async Task TestAddEmployee()
        {

            var logger = new Mock<ILogger<EmployeesCommandHandler>>() ?? throw new Exception("not initializaced");
            var employeeRepository = new Mock<IEmployeeRepository>() ?? throw new Exception("not initializaced");
            
            employeeRepository.Setup(x => x.Add(It.IsAny<AddEmployeeCommand>())).Returns(Task.FromResult(() => { }));

            var employeesCommandHandler = new EmployeesCommandHandler(employeeRepository.Object, logger.Object);

            var guid = Guid.NewGuid();

            await employeesCommandHandler.Handle(new AddEmployeeCommand
            {
                Id = guid,
                FirstName = "Test",
                LastName = "Test"
            });
            
            employeeRepository.Verify(mock => mock.Add(It.IsAny<AddEmployeeCommand>()), Times.Once());
        }

        [Test]
        public async Task TestGetEmployees()
        {

            var logger = new Mock<ILogger<EmployeesCommandHandler>>() ?? throw new Exception("not initializaced");
            var employeeRepository = new Mock<IEmployeeRepository>() ?? throw new Exception("not initializaced");

            var guid = Guid.NewGuid();

            employeeRepository.Setup(x => x.GetAllEmployees()).Returns(Task.FromResult(new List<Database.models.Employee>() { 
                new Database.models.Employee() { 
                    Id = guid,
                    FirstName = "Test",
                    LastName = "Test"
                } 
            }));            

            var employeesCommandHandler = new EmployeesCommandHandler(employeeRepository.Object, logger.Object);            

            var response = await employeesCommandHandler.Query(new GetEmployeeCommand { 
                PermissionType = null
            });

            Assert.IsTrue(response.Count > 0);
            Assert.That(guid, Is.EqualTo(response.First().Id));
        }

        [Test]
        public async Task TestGetEmployeesByType()
        {

            var logger = new Mock<ILogger<EmployeesCommandHandler>>() ?? throw new Exception("not initializaced");
            var employeeRepository = new Mock<IEmployeeRepository>() ?? throw new Exception("not initializaced");

            var guid = Guid.NewGuid();

            employeeRepository.Setup(x => x.GetEmployeesByPermissionType(It.IsAny<string>())).Returns(Task.FromResult(new List<Database.models.Employee>() {
                new Database.models.Employee() {
                    Id = guid,
                    FirstName = "Test",
                    LastName = "Test"
                }
            }));

            var employeesCommandHandler = new EmployeesCommandHandler(employeeRepository.Object, logger.Object);

            var response = await employeesCommandHandler.Query(new GetEmployeeCommand
            {
                PermissionType = "admin"
            });

            Assert.IsTrue(response.Count > 0);
            Assert.That(guid, Is.EqualTo(response.First().Id));
        }
    }
}