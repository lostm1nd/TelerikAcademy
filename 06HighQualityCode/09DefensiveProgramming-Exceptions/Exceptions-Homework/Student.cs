using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get { return this.firstName; }

        private set
        {
            if (value == null || value.Length < 2)
            {
                throw new ArgumentException("First name cannot be null or less than 2 symbols.");
            }

            this.firstName = value;
        } 
    }

    public string LastName
    {
        get { return this.lastName; }

        private set
        {
            if (value == null || value.Length < 2)
            {
                throw new ArgumentException("Last name cannot be null or less than 2 symbols.");
            }

            this.lastName = value;
        } 
    }

    public IList<Exam> Exams
    {
        get { return new List<Exam>(this.exams); }

        private set
        {
            if (value == null)
            {
                this.exams = new List<Exam>();
            }
            else
            {
                this.exams = value;
            }
        }
    }

    /// <summary>
    /// Checks the result for all the exams the student has taken.
    /// </summary>
    /// <returns>An empty list if the student has no exams.</returns>
    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    /// <summary>
    /// Calculates the average score of all the exams
    /// the student has taken.
    /// </summary>
    /// <returns>Returns the average score or 0 if no exams exist.</returns>
    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            return 0;
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
