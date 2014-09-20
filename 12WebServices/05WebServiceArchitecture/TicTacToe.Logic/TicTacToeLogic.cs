namespace TicTacToe.Logic
{
    public class TicTacToeLogic : ITicTacToeLogic
    {
        public GameResult GetResult(string board)
        {
            string firstRow = board.Substring(0, 3);
            GameResult result = this.CheckSequenceOfThree(firstRow);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string secondRow = board.Substring(3, 3);
            result = this.CheckSequenceOfThree(secondRow);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string thirdRow = board.Substring(6, 3);
            result = this.CheckSequenceOfThree(secondRow);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string firstCol = "" + board[0] + board[3] + board[6];
            result = this.CheckSequenceOfThree(firstCol);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string secondCol = "" + board[1] + board[4] + board[7];
            result = this.CheckSequenceOfThree(secondCol);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string thirdCol = "" + board[2] + board[5] + board[8];
            result = this.CheckSequenceOfThree(thirdCol);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string leftToRightDiagonal = "" + board[0] + board[4] + board[8];
            result = this.CheckSequenceOfThree(leftToRightDiagonal);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            string rightToLeftDiagonal = "" + board[2] + board[4] + board[6];
            result = this.CheckSequenceOfThree(rightToLeftDiagonal);
            if (result != GameResult.NotFinished)
            {
                return result;
            }

            int freePositions = board.IndexOf('-');
            if (freePositions == -1)
            {
                return GameResult.Draw;
            }

            return GameResult.NotFinished;
        }

        private GameResult CheckSequenceOfThree(string sequence)
        {
            if (sequence == "XXX")
            {
                return GameResult.WonByX;
            }
            else if (sequence == "OOO")
            {
                return GameResult.WonByO;
            }
            else
            {
                return GameResult.NotFinished;
            }
        }
    }
}
