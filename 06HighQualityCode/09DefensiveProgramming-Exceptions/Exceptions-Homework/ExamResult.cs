using System;

public class ExamResult
{
    private int minGrade;
    private int maxGrade;
    private int grade;
    private string comments;

    public ExamResult(int minGrade, int maxGrade, int grade, string comments)
    {
        
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;

        this.Grade = grade;
        this.Comments = comments;
    }

    public int MinGrade
    {
        get { return this.minGrade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Minimum grade cannot be negative.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }

        private set
        {
            if (value < 0 || value < this.MinGrade)
            {
                throw new ArgumentException("Maximum grade should be a positive integer, larger than the minimum grade.");
            }

            this.maxGrade = value;
        }
    }

    public int Grade
    {
        get { return this.grade; }

        private set
        {
            if (value < this.MinGrade || value > this.MaxGrade)
            {
                throw new ArgumentException("Grades are in range " + this.MinGrade + " - " + this.MaxGrade);
            }

            this.grade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }

        set
        {
            if (value == null || value == String.Empty)
            {
                this.comments = "No comments";
            }
            else
            {
                this.comments = value;
            }
        }
    }
}
