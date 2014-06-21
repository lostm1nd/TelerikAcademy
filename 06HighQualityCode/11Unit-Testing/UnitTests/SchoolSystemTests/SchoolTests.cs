using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SchoolSystem;
using System.Collections.Generic;

// cannot check the test coverage since
// there is no such option in VS2013 Pro

namespace SchoolSystemTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolCreationWithNullName()
        {
            School school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolCreationWithEmptyName()
        {
            School school = new School("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseCreationWithNullName()
        {
            Course school = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseCreationWithEmptyName()
        {
            Course course = new Course("");
        }

        [TestMethod]
        public void TestAddingStudentsToCourse()
        {
            Course course = new Course("JavaScript");

            for (int i = 0; i < 10; i++)
            {
                course.AddStudent(new Student("Johny"));
            }

            Assert.AreEqual(10, course.Students.Count, "Adding students to a course does not work correctly. " +
                                                        "Added 10 students and got a count of " + course.Students.Count);
        }

        [TestMethod]
        public void TestRemovingStudentsFromCourse()
        {
            Course course = new Course("JavaScript");
            Student[] students = new Student[10];

            for (int i = 0; i < 10; i++)
            {
                students[i] = new Student("Johny");
                course.AddStudent(students[i]);
            }

            course.RemoveStudent(students[0]);
            course.RemoveStudent(students[5]);
            course.RemoveStudent(students[9]);

            Assert.AreEqual(7, course.Students.Count, "Removing students to a course does not work correctly. " +
                                                        "Added 10 students, removed 3 and got a count of " + course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseFullException))]
        public void TestAddingTooManyStudentsToCourse()
        {
            Course course = new Course("CSharp");

            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(new Student("Johny"));
            }
        }

        [TestMethod]
        public void TestIfAllStudetnsIdsAreUnique()
        {
            School school = new School("Telerik Academy");

            Course courseJs = new Course("JavaScript");
            Course courseCSharp = new Course("CSharp");
            Course courseOop = new Course("OOP");

            for (int i = 0; i < 27; i++)
            {
                courseJs.AddStudent(new Student("Johny"));
            }

            for (int i = 0; i < 22; i++)
            {
                courseCSharp.AddStudent(new Student("Mary"));
            }

            for (int i = 0; i < 25; i++)
            {
                courseOop.AddStudent(new Student("Dan"));
            }

            school.AddCourse(courseJs);
            school.AddCourse(courseCSharp);
            school.AddCourse(courseOop);

            List<Student> allStudents = school.Students;
            bool doSameIdsExist = false;

            for (int i = 0; i < allStudents.Count; i++)
            {
                for (int j = i+1; j < allStudents.Count; j++)
                {
                    if (allStudents[i].Id == allStudents[j].Id)
                    {
                        doSameIdsExist = true;
                    }
                }
            }

            Assert.AreEqual(false, doSameIdsExist, "Same students ids appear in the school system");
        }
    }
}
