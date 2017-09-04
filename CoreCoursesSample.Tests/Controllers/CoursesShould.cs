using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CoreCoursesSample.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using CoreCoursesSample.WebApi.Models;
using System.Linq;

namespace CoreCoursesSample.Tests
{
    public class CoursesShould
    {
        [Fact]
        public void ReturnCourses()
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
                var result = sut.GetCourses();
                Assert.Equal(2, result.Count());
            }
        }
    }
}