namespace AlgorithmsPerf
{
    using System;
    using System.Diagnostics;

    class TestsOutput
    {
        // 20 item arrays
        static String[] unsortedWords = 
            { "wysiwyg", "editors", "are", "really", "quite", "stupid", "or", "awesome", "for", "some",
                "that", "do", "get", "them", "for", "free", "what", "do", "you", "know" };

        static int[] unsortedNumbers = { 1, 20, -2, 5, 123, 95, 2002, 154333, 4, 22,
                                    673, 1293, 8, -222, 3466, 85, 99, 552, 210, 0};

        static double[] unsortedDoubles = { 0.23, 0.01, -2.3, 6.335, 78.02, 1.01, 33.33, -2.223, 20.20, 0.152,
                                       55.555, 89.02, 33.32, 45.54, 88.812, 6.36, 100.01, 21.12, 25.25, 11 };

        static void Main()
        {
            TestInsertionSort();

            // TestSelectionSort();

            // TestQuickSort();
        }

        static void TestInsertionSort()
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            Algorithms.InsertionSort(unsortedNumbers);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on random ints");

            timer.Restart();
            Algorithms.InsertionSort(unsortedDoubles);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on random doubles");

            timer.Restart();
            Algorithms.InsertionSort(unsortedWords);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on random strings");

            timer.Restart();
            Algorithms.InsertionSort(unsortedNumbers);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on sorted ints");

            timer.Restart();
            Algorithms.InsertionSort(unsortedDoubles);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on sorted doubles");

            timer.Restart();
            Algorithms.InsertionSort(unsortedWords);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on sorted strings");

            Array.Reverse(unsortedWords);
            Array.Reverse(unsortedNumbers);
            Array.Reverse(unsortedDoubles);

            timer.Restart();
            Algorithms.InsertionSort(unsortedNumbers);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on reversed ints");

            timer.Restart();
            Algorithms.InsertionSort(unsortedDoubles);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on reversed doubles");

            timer.Restart();
            Algorithms.InsertionSort(unsortedWords);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Insertion sort on reversed strings");
        }

        static void TestSelectionSort()
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            Algorithms.SelectionSort(unsortedNumbers);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on random ints");

            timer.Restart();
            Algorithms.SelectionSort(unsortedDoubles);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on random doubles");

            timer.Restart();
            Algorithms.SelectionSort(unsortedWords);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on random strings");

            timer.Restart();
            Algorithms.SelectionSort(unsortedNumbers);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on sorted ints");

            timer.Restart();
            Algorithms.SelectionSort(unsortedDoubles);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on sorted doubles");

            timer.Restart();
            Algorithms.SelectionSort(unsortedWords);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on sorted strings");

            Array.Reverse(unsortedWords);
            Array.Reverse(unsortedNumbers);
            Array.Reverse(unsortedDoubles);

            timer.Restart();
            Algorithms.SelectionSort(unsortedNumbers);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on reversed ints");

            timer.Restart();
            Algorithms.SelectionSort(unsortedDoubles);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on reversed doubles");

            timer.Restart();
            Algorithms.SelectionSort(unsortedWords);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Selection sort on reversed strings");
        }

        static void TestQuickSort()
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            Algorithms.QuickSort(unsortedNumbers, 0, unsortedNumbers.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on random ints");

            timer.Restart();
            Algorithms.QuickSort(unsortedDoubles, 0, unsortedDoubles.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on random doubles");

            timer.Restart();
            Algorithms.QuickSort(unsortedWords, 0, unsortedWords.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on random strings");

            timer.Restart();
            Algorithms.QuickSort(unsortedNumbers, 0, unsortedNumbers.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on sorted ints");

            timer.Restart();
            Algorithms.QuickSort(unsortedDoubles, 0, unsortedDoubles.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on sorted doubles");

            timer.Restart();
            Algorithms.QuickSort(unsortedWords, 0, unsortedWords.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on sorted strings");

            Array.Reverse(unsortedWords);
            Array.Reverse(unsortedNumbers);
            Array.Reverse(unsortedDoubles);

            timer.Restart();
            Algorithms.QuickSort(unsortedNumbers, 0, unsortedNumbers.Length - 1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on reversed ints");

            timer.Restart();
            Algorithms.QuickSort(unsortedDoubles, 0, unsortedDoubles.Length-1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on reversed doubles");

            timer.Restart();
            Algorithms.QuickSort(unsortedWords, 0, unsortedWords.Length-1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " - Quick sort on reversed strings");
        }
    }
}
