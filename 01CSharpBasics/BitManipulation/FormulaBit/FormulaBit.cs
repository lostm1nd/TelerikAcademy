using System;

class Program
{
    static void Main()
    {
        //get input data and draw the track
        byte[,] track = new byte[8, 8];
        for (int row = 0; row < 8; row++)
        {
            byte inputNumber = byte.Parse(Console.ReadLine());
            for (int col = 0; col < 8; col++)
            {
                if ((inputNumber >> col & 1) == 1) track[row, col] = 1;
                else track[row, col] = 0;
            }
        }

        //calculate the track length and turns
        byte trackLength = 0;
        byte trackTurns = 0;
        byte rowStatic = 0;
        byte columnStatic = 0;
        bool trackAvailable = true;
        bool trackEnd = false;

        while (trackAvailable)
        {
            //move down
            for (int row = rowStatic; row < 8; row++)
            {
                if (track[rowStatic, columnStatic] == 1)
                {
                    trackAvailable = false;
                    break;
                }
                else if (track[1, 0] == 1)
                {
                    trackAvailable = false;
                    trackLength = 1;
                    break;
                }
                else if (track[row, columnStatic] == 0)
                {
                    trackLength++;
                    rowStatic = (byte)row;
                    if (rowStatic == 7 && columnStatic == 7) trackEnd = true;
                    if (rowStatic == 7 && columnStatic < 7) columnStatic++;
                }
                else if (track[row, columnStatic] == 1)
                {
                    if (row == 7 && columnStatic == 7) trackAvailable = false;
                    if (columnStatic < 7) columnStatic++;
                    break;
                }                
            }
            if (trackAvailable == false || trackEnd == true) break;
            trackTurns++;

            //move left
            for (int col = columnStatic; col < 8; col++)
            {
                if (track[rowStatic, columnStatic] == 1)
                {
                    trackAvailable = false;
                    break;
                }
                else if (track[rowStatic, col] == 0)
                {
                    trackLength++;
                    columnStatic = (byte)col;
                    if (rowStatic == 7 && columnStatic == 7) trackEnd = true;
                    if (columnStatic == 7 && rowStatic > 0) rowStatic--;
                }
                else if (track[rowStatic, col] == 1)
                {
                    if (rowStatic == 7 && col == 7) trackAvailable = false;
                    if (rowStatic > 0) rowStatic--;
                    break;
                }                
            }
            if (trackAvailable == false || trackEnd == true) break;
            trackTurns++;

            //move up
            for (int row = rowStatic; row >= 0; row--)
            {
                if (track[rowStatic, columnStatic] == 1)
                {
                    trackAvailable = false;
                    break;
                }
                else if (track[row, columnStatic] == 0)
                {
                    trackLength++;
                    rowStatic = (byte)row;
                    if (rowStatic == 0 && columnStatic == 7) trackAvailable = false;
                    if (rowStatic == 0 && columnStatic < 7) columnStatic++;
                }
                else if (track[row, columnStatic] == 1)
                {
                    if (columnStatic < 7) columnStatic++;
                    break;
                }
            }
            if (trackAvailable == false || trackEnd == true) break;
            trackTurns++;

            //move left
            for (int col = columnStatic; col < 8; col++)
            {
                if (track[rowStatic, columnStatic] == 1)
                {
                    trackAvailable = false;
                    break;
                }
                else if (track[rowStatic, col] == 0)
                {
                    trackLength++;
                    columnStatic = (byte)col;
                    if (columnStatic == 7 && rowStatic < 7) rowStatic++;
                }
                else if (track[rowStatic, col] == 1)
                {
                    if (rowStatic < 7) rowStatic++;
                    break;
                }
                if (rowStatic == 7 && columnStatic == 7) trackEnd = true;
            }
            if (trackAvailable == false || trackEnd == true) break;
            trackTurns++;
        }

        //output data
        if (trackAvailable)
        {
            Console.WriteLine("{0} {1}", trackLength, trackTurns);
        }
        else
        {
            Console.WriteLine("No {0}", trackLength);
        }
    }
}