using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCoursesSample.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreCoursesSample.WebApi.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly CoursesDbContext _context;
        private readonly ILogger _Logger;

        public CoursesRepository(CoursesDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _Logger = loggerFactory.CreateLogger("CoursesRepository");
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Courses.SingleOrDefaultAsync ( c => c.ID == id);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> InsertCourseAsync(Course course)
        {
            _context.Add(course);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _Logger.LogError($"Error in {nameof(InsertCourseAsync)}: " + exp.Message);
            }

            return course;
        }
    }
}
