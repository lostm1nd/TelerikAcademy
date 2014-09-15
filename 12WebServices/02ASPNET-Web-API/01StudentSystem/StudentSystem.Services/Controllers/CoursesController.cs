namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData studentSystemData)
        {
            this.data = studentSystemData;
        }

        [HttpGet]
        public IHttpActionResult AllCourses()
        {
            var courses = this.data.Courses.All().ToList().Select(c => CourseServiceModel.ConvertFromCourse(c));

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult CourseById(Guid id)
        {
            var course = this.GetCourseById(id);

            return Ok(CourseServiceModel.ConvertFromCourse(course));
        }

        [HttpPost]
        public IHttpActionResult AddCourse(CourseServiceModel newCourse)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            Course course = newCourse.ConvertToCourse();

            this.data.Courses.Add(course);
            this.data.SaveChanges();

            newCourse.Id = course.Id;
            return Ok(newCourse);
        }

        [HttpPut]
        public IHttpActionResult UpdateCourse(Guid id, CourseServiceModel updatedCourse)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var oldCourse = this.GetCourseById(id);

            oldCourse.Name = updatedCourse.Name;
            oldCourse.Description = updatedCourse.Description;
            foreach (var studentNames in updatedCourse.Students)
            {
                string[] names = studentNames.Split(' ');
                oldCourse.Students.Add(new Student
                {
                    FirstName = names[0],
                    LastName = names[1]
                });
            }

            this.data.SaveChanges();

            return Ok(CourseServiceModel.ConvertFromCourse(oldCourse));
        }

        [HttpPut]
        public IHttpActionResult AddStudent(Guid courseId, StudentServiceModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var course = this.GetCourseById(courseId);

            course.Students.Add(studentModel.ConverToStudent());
            this.data.SaveChanges();

            return Ok(CourseServiceModel.ConvertFromCourse(course));
        }

        [HttpDelete]
        public IHttpActionResult RemoveCourse(Guid id)
        {
            var course = this.GetCourseById(id);

            this.data.Courses.Delete(course);
            this.data.SaveChanges();

            return Ok(CourseServiceModel.ConvertFromCourse(course));
        }

        private Course GetCourseById(Guid id)
        {
            var course = this.data.Courses.All().FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new HttpRequestException("Invalid course id: " + id);
            }

            return course;
        }
    }
}