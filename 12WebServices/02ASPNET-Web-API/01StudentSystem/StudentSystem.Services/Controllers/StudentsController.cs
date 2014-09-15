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

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData studentSystemData)
        {
            this.data = studentSystemData;
        }

        [HttpGet]
        public IHttpActionResult AllStudents()
        {
            var students = this.data.Students.All().ToList().Select(s => StudentServiceModel.ConvertFromStudent(s));

            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult StudentById(int id)
        {
            var student = this.GetStudentById(id);

            return Ok(StudentServiceModel.ConvertFromStudent(student));
        }

        [HttpPost]
        public IHttpActionResult AddStudent(StudentServiceModel newStudent)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            Student student = newStudent.ConverToStudent();

            this.data.Students.Add(student);
            this.data.SaveChanges();

            newStudent.Id = student.StudentId;
            return Ok(newStudent);
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, StudentServiceModel updatedStudent)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var oldStudent = this.GetStudentById(id);

            oldStudent.FirstName = updatedStudent.FirstName;
            oldStudent.LastName = updatedStudent.LastName;
            foreach (var courseName in updatedStudent.Courses)
            {
                if (!oldStudent.Courses.Any(c => c.Name == courseName))
                {
                    oldStudent.Courses.Add(new Course
                    {
                        Name = courseName
                    });
                }
            }

            this.data.Students.SaveChanges();

            return Ok(StudentServiceModel.ConvertFromStudent(oldStudent));
        }

        [HttpPut]
        public IHttpActionResult EnrollInCourse(int studentId, CourseServiceModel newCourse)
        {
            var student = this.GetStudentById(studentId);
            
            var course = newCourse.ConvertToCourse();

            student.Courses.Add(course);
            this.data.SaveChanges();

            return Ok(StudentServiceModel.ConvertFromStudent(student));
        }

        [HttpPut]
        public IHttpActionResult EnrollInCourse(int studentId, Guid courseId)
        {
            var student = this.GetStudentById(studentId);

            var course = this.data.Courses.All().FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                BadRequest("Invalud course id" + courseId);
            }

            student.Courses.Add(course);

            return Ok(StudentServiceModel.ConvertFromStudent(student));
        }

        [HttpDelete]
        public IHttpActionResult RemoveStudent(int id)
        {
            var student = this.GetStudentById(id);

            this.data.Students.Delete(student);
            this.data.Students.SaveChanges();

            return Ok(StudentServiceModel.ConvertFromStudent(student));
        }

        private Student GetStudentById(int id)
        {
            var student = this.data.Students.All().FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                throw new HttpRequestException("Invalid student id: " + id);
            }

            return student;
        }
    }
}