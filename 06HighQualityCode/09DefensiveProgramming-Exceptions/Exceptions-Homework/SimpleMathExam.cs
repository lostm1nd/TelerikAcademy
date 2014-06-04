using System;

public class SimpleMathExam : Exam
{
    private const int MinResult = 2;
    private const int MaxResult = 6;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get { return this.problemsSolved; }

        private set
        {
            if (value < 0)
            {
                this.problemsSolved = 0;
            }
            else if (value > 2)
            {
                this.problemsSolved = 2;
            }
            else
            {
                this.problemsSolved = value;
            }
        }
    }

    public override ExamResult Check()
    {
        ExamResult result;
        if (this.ProblemsSolved == 0)
        {
            result = new ExamResult(SimpleMathExam.MinResult, SimpleMathExam.MaxResult, 2, "Bad result: nothing done.");
            return result;
        }
        else if (this.ProblemsSolved == 1)
        {
            result = new ExamResult(SimpleMathExam.MinResult, SimpleMathExam.MaxResult, 4, "Average result: 1 task done.");
            return result;
        }
        else
        {
            result = new ExamResult(SimpleMathExam.MinResult, SimpleMathExam.MaxResult, 6, "Excellent result: 2 tasks done.");
            return result;
        }
    }
}
