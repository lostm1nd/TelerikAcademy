using System;

namespace Matrix
{
    class Start
    {
        static void Main()
        {
            WalkInMatrix matrix = new WalkInMatrix(2);
            matrix.Walk();
            matrix.Print();
        }
    }
}
