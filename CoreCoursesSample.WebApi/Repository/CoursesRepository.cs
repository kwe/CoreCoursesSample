using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCoursesSample.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCoursesSample.WebApi.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly CoursesDbContext _context;

        public CoursesRepository(CoursesDbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Courses.SingleOrDefaultAsync ( c => c.ID == id);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
