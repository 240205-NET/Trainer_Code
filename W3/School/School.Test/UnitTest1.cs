using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NuGet.Frameworks;
using School.API.Controllers;
using School.Data;
using School.Logic;

namespace School.Test
{
    public class StudentControllerTests
    {
        [Fact]
        public void Smoke_Test()
        {
            Assert.Equal(true, true);
        }

        [Fact]
        public async void GetStudentByIdAsyncTest()
        {
            // Arrange

            // Prepare a result object...
            Student resultStudent = new Student(3, "test student", "test@gmail.com", "address1", "address2", "city", "state", "12345");
            ActionResult<Student> expected = new ActionResult<Student>(resultStudent);
            
            // After including the Moq library/package we spin up a new mocked repository object.
            // update the mock object to fulfill only the methods you require.
            Mock<IRepository> mockedRepo = new Mock<IRepository>();            
            mockedRepo.Setup(repo => repo.GetStudentByIdAsync(3)).ReturnsAsync(resultStudent);
          
            // 
            ILogger<StudentController> logger = Mock.Of<ILogger<StudentController>>();

            StudentController controller = new StudentController(mockedRepo.Object, logger );

            // Act
            // Task<Student>
            var result = await controller.GetStudentByIdAsync(3);

            // Assert
            //certain asserts, like IsType, will return an object of type <T>.
            var studentResult = Assert.IsType<ActionResult<Student>>(result);
            var returnValue = Assert.IsType<Student>(studentResult.Value);
            // while others, like Equal, have no return.
            Assert.Equal(resultStudent.email, returnValue.email);
        }
    }
}