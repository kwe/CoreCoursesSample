using System;
using System.Collections.Generic;
using System.Linq;
using CoreCoursesSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CoreCoursesSample.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly CoursesDbContext _context;

        public CoursesController(CoursesDbContext context)
        {
            _context = context;
        }

        // Get: api/Courses
        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses;
        }
    }
}