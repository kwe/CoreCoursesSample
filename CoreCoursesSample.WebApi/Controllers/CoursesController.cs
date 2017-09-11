using System;
using System.Collections.Generic;
using System.Linq;
using CoreCoursesSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoreCoursesSample.WebApi.Repository;


namespace CoreCoursesSample.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/courses")]
    public class CoursesController : Controller
    {
        ICoursesRepository _coursesRepository;

        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        // Get: api/Courses
        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]

        public async Task<ActionResult> Courses()
        {
            try
            {
                var courses = await _coursesRepository.GetCoursesAsync();
                return Ok(courses);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}