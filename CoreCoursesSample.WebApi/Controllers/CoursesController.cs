

using System.Collections.Generic;
using CoreCoursesSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCoursesSample.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {

        // Get: api/Courses
        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            return (new List<Course>());
        }
    }
}