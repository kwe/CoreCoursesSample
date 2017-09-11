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

namespace CoreCoursesSample.Tests
{
    public class CoursesShould
    {
        [Fact]
        public async Task ReturnCourses()
        {
            var options = new DbContextOptionsBuilder<CoursesDbContext>()
                .UseInMemoryDatabase(databaseName: "CoursesMEM")
                .Options;

            using (var context = new CoursesDbContext(options))
            {
                context.Courses.Add(new Course { Title = "Test Course"});
                context.Courses.Add(new Course { Title = "Another Silly Course"});
                context.SaveChanges();
            }
            using (var context = new CoursesDbContext(options))
            {
                var sut = new CoursesController(context);
                var result = await sut.Courses();
                Assert.IsType<OkObjectResult>(result);

                var them = result as OkObjectResult;
                var courses = them.Value as List<Course>;

                Assert.Equal(courses.Count, 2);
            }
        }
    }
}