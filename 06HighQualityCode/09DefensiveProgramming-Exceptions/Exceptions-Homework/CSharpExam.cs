using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get { return this.score; }

        private set
        {
            if (value < CSharpExam.MinScore || value > CSharpExam.MaxScore)
            {
                throw new ArgumentException("Score should be a positive number betwee " +
                                            CSharpExam.MinScore + " - " + CSharpExam.MaxScore);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(CSharpExam.MinScore, CSharpExam.MaxScore, this.Score, "Exam results calculated by score.");
    }
}
