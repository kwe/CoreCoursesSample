using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreCoursesSample.WebApi.Models;

namespace CoreCoursesSample.WebApi.Repository
{
    public interface ICoursesRepository
    {
        Task<List<Course>> GetCoursesAsync();
        Task<Course> GetCourseAsync(int id);
        Task<Course> InsertCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
    }
}
