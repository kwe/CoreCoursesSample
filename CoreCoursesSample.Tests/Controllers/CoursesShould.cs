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
            var sut = new CoursesController();
            var result = sut.GetCourses();

            Assert.IsType<List<Course>>(result);
                        
        }
    }
}