namespace StudentDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<Student> businessStudents = new List<Student>()
            {
                new Student("John", "Smith", "johnSmith@gmail.com", "(4441)-453-341", 2102, 5, new List<byte>() {5, 5, 4, 6, 4}),
                new Student("Peter", "Kalkov", "peshoto@mail.bg", "(3592)-923-23-11", 1206, 2, new List<byte>() {6, 6, 3, 5}),
                new Student("Jessica", "Parker", "jessTheMess@yahoo.com", "(9922)-23-44-11", 5305, 3, new List<byte>() {3, 5, 5, 5}),
                new Student("Kalin", "Kalinov", "kalinov@gmail.com", "(35943)-23-122-12", 3401, 2, new List<byte>() {4, 5, 5, 3}),
                new Student("Jamie", "Trent", "theTrend@sugar.info", "(3233)-145-74-31", 2306, 6, new List<byte>() {6, 6, 2, 5}),
                new Student("Georgi", "Tomov", "tomahawk@abv.bg", "(3592)-981-62-11", 1111, 9, new List<byte>() {2, 6, 6, 6, 2})
            };

            // task 09
            var stundentsGroupTwo =
                from student in businessStudents
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("----Group 2 with LINQ query-----");
            foreach (var stud in stundentsGroupTwo)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.GroupNumber);
            }

            // task 10
            var studentsGroupTwoExtensions = businessStudents.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName);

            Console.WriteLine("----Group 2 with extension-----");
            foreach (var stud in studentsGroupTwoExtensions)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.GroupNumber);
            }

            // task 11
            var emailAtAbv =
                from student in businessStudents
                where student.Email.Split('@').Last() == "abv.bg"
                select student;

            Console.WriteLine("---Students with email at abv.bg with LINQ query-----");
            foreach (var stud in emailAtAbv)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.Email);
            }

            // taks 12
            var phonesInSofia =
                from student in businessStudents
                where student.TelNumber.IndexOf("(3592)") != -1
                select student;

            Console.WriteLine("-----Students with telephones from Sofia with LINQ query-----");
            foreach (var stud in phonesInSofia)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + " " + stud.TelNumber);
            }

            // task 13
            var oneExcellentMark =
                from student in businessStudents
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.Lastname, Marks = student.Marks };

            Console.WriteLine("-----Students with at least one 6 mark with LINQ query-----");
            foreach (var stud in oneExcellentMark)
            {
                Console.WriteLine(stud.FullName + "->" + string.Join(" ", stud.Marks));
            }

            // task 14
            var twoPoorMarks = businessStudents.Where(x => x.Marks.FindAll(y => y == 2).Count == 2);

            Console.WriteLine("----Students with exactly 2 poor marks with extensions-----");
            foreach (var stud in twoPoorMarks)
            {
                Console.WriteLine(stud.FirstName + " " + stud.Lastname + "->" + string.Join(" ", stud.Marks));
            }

            // task 15 -- convert the number to string and take the desired element as char
            var extractAllMarks =
                from student in businessStudents
                where student.FacultyNumber.ToString()[2] == '0'
                      && student.FacultyNumber.ToString()[3] == '6'
                select student.Marks;

            Console.WriteLine("----Marks of students enrolled in 2006 with LINQ query-----");
            foreach (var stud in extractAllMarks)
            {
                Console.WriteLine(string.Join(", ", stud));
            }
        }
    }
}
