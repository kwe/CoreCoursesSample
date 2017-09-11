using System;
using System.Collections.Generic;
using System.Linq;
using CoreCoursesSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(List<Course>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]

        public async Task<ActionResult> Courses()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync();
                return Ok(courses);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}