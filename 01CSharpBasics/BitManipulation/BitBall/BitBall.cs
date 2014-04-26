using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //team top
        byte[] teamTop = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            teamTop[i] = byte.Parse(Console.ReadLine());
        }
        //team bottom
        byte[] teamBottom = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            teamBottom[i] = byte.Parse(Console.ReadLine());
        }
        //playfield with both teams on it without players who commited fouls
        byte[] playfield = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            playfield[i] = (byte)(teamTop[i] ^ teamBottom[i]);
        }
        //remove players who commit fouls from each team
        for (int i = 0; i < 8; i++)
        {
            teamTop[i] = (byte)(teamTop[i] & playfield[i]);
            teamBottom[i] = (byte)(teamBottom[i] & playfield[i]);
        }

        //move players from team top
        byte teamTopScore = 0;
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
				//checks if the bit on this position is 1; if it is there is a player
                if ((teamTop[row] >> col & 1) == 1) 
                {
                    if (row == playfield.Length - 1) teamTopScore++;
                    else
                    {
						//checks every bit in the same colum from top to bottom
                        for (int nextrow = row + 1; nextrow < 8; nextrow++) 
                        {
							//if the player encounter another bit it does not score
                            if ((teamTop[row] >> col & 1) == (playfield[nextrow] >> col & 1)) 
                            {
                                break;
                            }
							//if there is no other 1 bit and the player is at the bottom he scores
                            else if (nextrow == playfield.Length - 1) 
                            {
                                teamTopScore++;
                            }
                        }
                    }
                }
            }
        }

        //move players from team top
        byte teamBottomScore = 0;
        for (int row = playfield.Length -1; row >= 0; row--)
        {
            for (int col = 0; col < 8; col++)
            {
				//checks if the bit on this position is 1; if it is there is a player
                if ((teamBottom[row] >> col & 1) == 1) 
                {
                    if (row == 0) teamBottomScore++;
                    else
                    {
						//checks every bit in the same column from top to bottom
                        for (int nextrow = row - 1; nextrow >= 0; nextrow--) 
                        {
							//if the player encounter another bit it does not score
                            if ((teamBottom[row] >> col & 1) == (playfield[nextrow] >> col & 1)) 
                            {
                                break;
                            }
							//if there is no other 1 bit and the player is at the bottom he scores
                            else if (nextrow == 0)
                            {
                                teamBottomScore++;
                            }
                        }
                    }
                }
            }
        }

        //output result
        Console.WriteLine("{0}:{1}", teamTopScore, teamBottomScore);
    }
}