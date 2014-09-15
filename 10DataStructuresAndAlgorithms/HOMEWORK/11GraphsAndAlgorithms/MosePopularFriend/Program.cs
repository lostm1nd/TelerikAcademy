namespace MosePopularFriend
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            bool[,] matrix = new bool[size, size];

            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        matrix[i, j] = true;
                    }
                }
            }

            int maxFriends = 0;
            for (int user1 = 0; user1 < matrix.GetLength(0); user1++)
            {
                int currentUserFriens = 0;
                for (int user2 = 0; user2 < matrix.GetLength(1); user2++)
                {
                    if (user1 == user2)
                    {
                        continue;
                    }

                    // user1 and user2 are friends
                    if (matrix[user1, user2])
                    {
                        currentUserFriens += 1;
                    }
                    else
                    {
                        for (int user3 = 0; user3 < matrix.GetLength(0); user3++)
                        {
                            // user1 and user2 are indirect friends through user3
                            if (matrix[user1, user3] && matrix[user2, user3])
                            {
                                currentUserFriens += 1;
                                break;
                            }
                        }
                    }
                }

                if (currentUserFriens > maxFriends)
                {
                    maxFriends = currentUserFriens;
                }
            }

            Console.WriteLine(maxFriends);
        }
    }
}