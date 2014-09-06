namespace TelerikAcademy.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using TelerikAcademy.Data;

    class Program
    {
        static void Main()
        {
            // N+1 problem is present in this query
            // this method makes more queries to the database
            // but the performance in time is better
            // than the next method which includes two
            // of the tables that are needed
            PrintEmployeesWithoutInclude();

            // PrintEmployeesWithInclude();

            // Around 300 SQL statements 
            // EmployeesInvokingToListOnEachQuery();

            // Only 1 SQL statement
            // EmployeesFromSofiaOptimized();
        }

        private static void PrintEmployeesWithoutInclude()
        {
            using (var db = new TelerikAcademyDb())
            {
                db.Employees.Count();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach (var employee in db.Employees)
                {
                    Console.WriteLine("Name: {0}; Dep: {1}; Town: {2}",
                        employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
                }
                sw.Stop();
                Console.WriteLine("Time elapsed: " + sw.Elapsed);
            }
        }

        private static void PrintEmployeesWithInclude()
        {
            using (var db = new TelerikAcademyDb())
            {
                db.Employees.Count();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach (var employee in db.Employees.Include("Department").Include("Address"))
                {
                    Console.WriteLine("Name: {0}; Dep: {1}; Town: {2}",
                        employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
                }
                sw.Stop();
                Console.WriteLine("Time elapsed: " + sw.Elapsed);
            }
        }

        private static void EmployeesInvokingToListOnEachQuery()
        {
            using (var db = new TelerikAcademyDb())
            {
                db.Employees.Count();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                var employees = db.Employees.ToList();
                var addresses = employees.Select(emp => emp.Address).ToList();
                var towns = addresses.Select(adr => adr.Town).ToList();
                var sofia = towns.Where(town => town.Name == "Sofia").ToList();

                Console.WriteLine("Employees from Sofia: " + sofia.Count);

                sw.Stop();
                Console.WriteLine("Time elapsed: " + sw.Elapsed);
            }
        }

        private static void EmployeesFromSofiaOptimized()
        {
            using (var db = new TelerikAcademyDb())
            {
                db.Employees.Count();

                Stopwatch sw = new Stopwatch();
                sw.Start();

                var employeesFromSofia = db.Employees.Where(emp => emp.Address.Town.Name == "Sofia");

                sw.Stop();
                Console.WriteLine("Employees from Sofia: " + employeesFromSofia.Count());
                Console.WriteLine("Time elapsed: " + sw.Elapsed);
            }
        }
    }
}