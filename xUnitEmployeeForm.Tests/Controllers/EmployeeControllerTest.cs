using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeForm.Repository;
using EmployeeForm.Controllers;
using EmployeeForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace xUnitEmployeeForm.Tests.Controllers
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeController = new EmployeeController(_mockEmployeeRepository.Object);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsOkResult()
        {
            var employeeId = 3;
            var employeeFirstName = "Atharva";
            var employee = new Employee { FirstName = "Atharva", LastName = "Amte", EmployeeCode = 1012, Contact = 175291, DoB = Convert.ToDateTime("2000-11-18"), Address = "Dombivli" };

            _mockEmployeeRepository.Setup(service => service.GetEmployeeByIdAsync(employeeId)).ReturnsAsync(employee);

            var result = await _employeeController.GetEmployeeById(employeeId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(employeeFirstName, returnValue.FirstName);
        }

        [Fact]
        public async Task GetEmployeeByID_ReturnsNotFound()
        {
            var employeeId = 1;
            //var employee = new Employee { FirstName = "Atharva", LastName = "Amte", EmployeeCode = 1012, Contact = 175291, DoB = Convert.ToDateTime("2000-11-18"), Address = "Dombivli" };
            
            _mockEmployeeRepository.Setup(service => service.GetEmployeeByIdAsync(employeeId)).ReturnsAsync((Employee)null);

            var result = await _employeeController.GetEmployeeById(employeeId);

            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task GetEmployee_ReturnsBadRequest_ForInvalidId()
        {
            // Arrange
            var invalidEmployeeId = -1;

            // Act
            var result = await _employeeController.GetEmployeeById(invalidEmployeeId);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }


    }
}
