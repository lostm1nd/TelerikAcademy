using System;
using System.Diagnostics;

namespace OperatorsPerformance
{
    class TestsOutput
    {
        static void Main()
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Results based on 100 000 loops");

            // integer tests
            timer.Start();
            IntegerTests.Addition();
            timer.Stop();
            Console.WriteLine("Int addition -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            IntegerTests.Subtraction();
            timer.Stop();
            Console.WriteLine("Int subtraction -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            IntegerTests.Division();
            timer.Stop();
            Console.WriteLine("Int division -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            IntegerTests.Multiplication();
            timer.Stop();
            Console.WriteLine("Int multi -> ".PadRight(24) + timer.Elapsed);

            // long tests
            Console.WriteLine(new string('=', 50));
            timer.Reset();

            timer.Start();
            LongTests.Addition();
            timer.Stop();
            Console.WriteLine("Long addition -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            LongTests.Subtraction();
            timer.Stop();
            Console.WriteLine("Long subtraction -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            LongTests.Division();
            timer.Stop();
            Console.WriteLine("Long division -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            LongTests.Multiplication();
            timer.Stop();
            Console.WriteLine("Long multi -> ".PadRight(24) + timer.Elapsed);

            // float tests
            Console.WriteLine(new string('=', 50));
            timer.Reset();

            timer.Start();
            FloatTests.Addition();
            timer.Stop();
            Console.WriteLine("Float addition -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            FloatTests.Subtraction();
            timer.Stop();
            Console.WriteLine("Float subtraction -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            FloatTests.Division();
            timer.Stop();
            Console.WriteLine("Float division -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            FloatTests.Multiplication();
            timer.Stop();
            Console.WriteLine("Float multi -> ".PadRight(24) + timer.Elapsed);

            // double tests
            Console.WriteLine(new string('=', 50));
            timer.Reset();

            timer.Start();
            DoubleTests.Addition();
            timer.Stop();
            Console.WriteLine("Double addition -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            DoubleTests.Subtraction();
            timer.Stop();
            Console.WriteLine("Double subtraction -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            DoubleTests.Division();
            timer.Stop();
            Console.WriteLine("Double division -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            DoubleTests.Multiplication();
            timer.Stop();
            Console.WriteLine("Double multi -> ".PadRight(24) + timer.Elapsed);

            // decimal tests
            Console.WriteLine(new string('=', 50));
            timer.Reset();

            timer.Start();
            DecimalTests.Addition();
            timer.Stop();
            Console.WriteLine("Decimal addition -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            DecimalTests.Subtraction();
            timer.Stop();
            Console.WriteLine("Decimal subtraction -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            DecimalTests.Division();
            timer.Stop();
            Console.WriteLine("Decimal division -> ".PadRight(24) + timer.Elapsed);

            timer.Reset();

            timer.Start();
            DecimalTests.Multiplication();
            timer.Stop();
            Console.WriteLine("Decimal multi -> ".PadRight(24) + timer.Elapsed);
        }
    }
}
