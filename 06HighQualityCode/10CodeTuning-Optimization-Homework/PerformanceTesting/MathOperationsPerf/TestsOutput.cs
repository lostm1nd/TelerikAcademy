namespace MathOperationsPerf
{
    using System;
    using System.Diagnostics;

    class TestsOutput
    {
        static void Main()
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Result based on 100 000 loops");

            // floats test
            timer.Start();
            FloatTests.SquareRoot();
            timer.Stop();
            Console.WriteLine("Float sqrt -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();
            timer.Start();
            FloatTests.NaturalLogarithm();
            timer.Stop();
            Console.WriteLine("Float log -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();
            timer.Start();
            FloatTests.Sinus();
            timer.Stop();
            Console.WriteLine("Float sin -> ".PadRight(24) + timer.Elapsed);

            // doubles test
            Console.WriteLine(new string('-', 50));
            timer.Reset();
            timer.Start();
            DoubleTests.SquareRoot();
            timer.Stop();
            Console.WriteLine("Double sqrt -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();
            timer.Start();
            DoubleTests.NaturalLogarithm();
            timer.Stop();
            Console.WriteLine("Double log -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();
            timer.Start();
            DoubleTests.Sinus();
            timer.Stop();
            Console.WriteLine("Double sin -> ".PadRight(24) + timer.Elapsed);

            // decimal test
            Console.WriteLine(new string('-', 50));
            timer.Reset();
            timer.Start();
            DecimalTests.SquareRoot();
            timer.Stop();
            Console.WriteLine("Decimal sqrt -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();
            timer.Start();
            DecimalTests.NaturalLogarithm();
            timer.Stop();
            Console.WriteLine("Decimal log -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();
            timer.Start();
            DecimalTests.Sinus();
            timer.Stop();
            Console.WriteLine("Decimal sin -> ".PadRight(24) + timer.Elapsed);
        }
    }
}
