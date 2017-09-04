using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreCoursesSample.WebApi.Models
{
    public class CoursesDbContext : DbContext
    {
        public  CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Course { get; set;}
    }
}