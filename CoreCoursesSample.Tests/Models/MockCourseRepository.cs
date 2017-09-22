using System;
using Moq;
using CoreCoursesSample.WebApi.Models;
using CoreCoursesSample.WebApi.Repository;
using System.Collections.Generic;

namespace CoreCoursesSample.Tests.Models
{
    public class MockCoursesRepository
    {
        public static Mock <ICoursesRepository>GetMockCoursesRepository()
        {
            List<Course> courses = new List<Course>
            {
                new Course
                {
                    ID = 1,
                    Title = "Mafs",
                    NumberOfStudents = 200
                },
                new Course
                {
                    ID = 2,
                    Title = "Biology",
                    NumberOfStudents = 190

                }
            };

            var course = new Course
            {
                ID = 1,
                Title = "A single course for local people",
                NumberOfStudents = 344
            };
            var mockCoursesRepository = new Mock<ICoursesRepository>();
            mockCoursesRepository.Setup(c => c.GetCoursesAsync()).ReturnsAsync(courses);
            mockCoursesRepository.Setup(c => c.GetCourseAsync(1)).ReturnsAsync(courses[0]);
            mockCoursesRepository.Setup(c => c.InsertCourseAsync(course)).ReturnsAsync(course);


            return mockCoursesRepository;

        }
    }
}
