using System;
using System.Collections.Generic;
using System.Linq;
using CoreCoursesSample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        ILogger _Logger;

        public CoursesController(ICoursesRepository coursesRepository, ILoggerFactory loggerFactory)
        {
            _coursesRepository = coursesRepository;
            _Logger = loggerFactory.CreateLogger(nameof(CoursesController));

        }

        // Get: api/Courses
        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]

        public async Task<ActionResult> GetCourses()
        {
            try
            {
                var courses = await _coursesRepository.GetCoursesAsync();
                return Ok(courses);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        // GET api/course/5
        [HttpGet("{id}", Name = "GetCourseRoute")]
        [ProducesResponseType(typeof(Course), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        public async Task<ActionResult> GetCourse(int id)
        {
            try
            {
                var course = await _coursesRepository.GetCourseAsync(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return NotFound();
            }
        }

        // POST api/course
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]

        public async Task<ActionResult> CreateCourse([FromBody]Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newCourse = await _coursesRepository.InsertCourseAsync(course);
                if (newCourse == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetCourseRoute", new { id = newCourse.ID },
                        new ApiResponse { Status = true, Course = newCourse });

            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }

        }
        // PUT api/course
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]

        public async Task<ActionResult> UpdateCourse(int id, [FromBody]Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }
            
            try
            {
                var status = await _coursesRepository.UpdateCourseAsync(course);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, Course = course });

            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }

        }



    }
}