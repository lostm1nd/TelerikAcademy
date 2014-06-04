namespace Assertions_Homework
{
    using System;

    class AssertionsHomework
    {
        static void Main()
        {
            int[] testNumbers = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("before sort = [{0}]", string.Join(", ", testNumbers));

            SelectionSort.Sort(testNumbers);
            Console.WriteLine("after sort = [{0}]", string.Join(", ", testNumbers));

            SelectionSort.Sort(new int[0]); // Test sorting empty array
            SelectionSort.Sort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch.Search(testNumbers, -1000));
            Console.WriteLine(BinarySearch.Search(testNumbers, 0));
            Console.WriteLine(BinarySearch.Search(testNumbers, 17));
            Console.WriteLine(BinarySearch.Search(testNumbers, 10));
            Console.WriteLine(BinarySearch.Search(testNumbers, 1000));
        }
    }
}
