using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CoreCoursesSample.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using CoreCoursesSample.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Configuration;
using CoreCoursesSample.WebApi.Repository;

namespace CoreCoursesSample.Tests
{
    public class CoursesShould
    {
        private Course _course;
        private List<Course> _courses;

        [Fact]
        public async Task ReturnCourses()
        {
            var repo = new Mock<ICoursesRepository>();
            _courses = new List<Course>();

            _course = new Course { ID = 1, NumberOfStudents = 100, Title = "Biology" };
            _courses.Add(_course);
            _course = new Course { ID = 2, NumberOfStudents = 65, Title = "Mafs" };
            _courses.Add(_course);

            repo.Setup(c => c.GetCoursesAsync()).ReturnsAsync(_courses);

            var sut = new CoursesController(repo.Object);
            var result = await sut.GetCourses();
            Assert.IsType<OkObjectResult>(result);

            var them = result as OkObjectResult;
            var courses = them.Value as List<Course>;

            Assert.Equal(2,courses.Count);
        }

        [Fact]
        public async Task ReturnsCourseByID()
        {
            var repo = new Mock<ICoursesRepository>();
            _course = new Course { ID = 1, NumberOfStudents = 100, Title = "Biology" };

            repo.Setup(c => c.GetCourseAsync(1)).ReturnsAsync(_course);

            var sut = new CoursesController(repo.Object);
            var result = await sut.GetCourse(1);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task ReturnsNotFound()
        {
            var repo = new Mock<ICoursesRepository>();

            // Mock a null course for any int passed
            repo.Setup(c => c.GetCourseAsync(It.IsAny<int>())).Returns(Task.FromResult<Course>(null));

            var sut = new CoursesController(repo.Object);
            var result = await sut.GetCourse(1);

            Assert.IsType<NotFoundResult>(result);

        }
    }
}