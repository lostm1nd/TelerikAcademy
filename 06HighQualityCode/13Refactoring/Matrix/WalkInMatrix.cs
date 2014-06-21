using System;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class WalkInMatrix
    {
        private int row = 0;
        private int col = 0;
        private int counter = 1;
        private int dirX = 1;
        private int dirY = 1;

        private int[,] matrix;

        public WalkInMatrix(int size)
        {
            this.SetMatrixSize(size);
        }

        public int[,] Matrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    result.AppendFormat("{0, -4}", this.matrix[i, j]);
                }
                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }

        public void Walk()
        {
            this.FillMatrix();

            this.FindFirstEmptyCell();

            if (this.row != 0 && this.col != 0)
            {
                this.dirX = 1;
                this.dirY = 1;
                this.counter += 1;

                this.FillMatrix();
            }
        }

        private void FillMatrix()
        {
            while (true)
            {
                this.matrix[this.row, this.col] = this.counter;

                if (!this.IsWalkingPossible())
                {
                    break;
                }

                while (IsDirectionInvalid())
                {
                    ChangeDirection();
                }

                this.row += this.dirX;
                this.col += this.dirY;
                this.counter += 1;
            }
        }

        private bool IsWalkingPossible()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (this.row + directionsX[i] >= this.matrix.GetLength(0) || this.row + directionsX[i] < 0)
                {
                    directionsX[i] = 0;
                }

                if (this.col + directionsY[i] >= this.matrix.GetLength(1) || this.col + directionsY[i] < 0)
                {
                    directionsY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.matrix[this.row + directionsX[i], this.col + directionsY[i]] == 0)
                {
                    return true;
                }
            } 

            return false;
        }

        private bool IsDirectionInvalid()
        {
            bool outOfHorizontalBounds = this.row + this.dirX < 0 || this.row + this.dirX >= this.matrix.GetLength(0);
            bool outOfVerticalBounds = this.col + this.dirY < 0 || this.col + this.dirY >= this.matrix.GetLength(1);
            // bool isNextCellOccupied = this.matrix[this.row + this.dirX, this.col + this.dirY] != 0;

            bool result = outOfHorizontalBounds || outOfVerticalBounds ||
                this.matrix[this.row + this.dirX, this.col + this.dirY] != 0;

            return result;
        }

        private void ChangeDirection()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int newDirectionIndex = 0;

            for (int i = 0; i < 8; i++)
            {
                if (directionsX[i] == this.dirX && directionsY[i] == this.dirY)
                {
                    newDirectionIndex = i;
                    break;
                }
            }

            if (newDirectionIndex == 7)
            {
                this.dirX = directionsX[0];
                this.dirY = directionsY[0];
                return;
            }

            this.dirX = directionsX[newDirectionIndex + 1];
            this.dirY = directionsY[newDirectionIndex + 1];
        }

        private void FindFirstEmptyCell()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        this.row = i;
                        this.col = j;
                        return;
                    }
                }
            }
        }

        private void SetMatrixSize(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("The size of the matrix should be at least 1.");
            }

            this.matrix = new int[size, size];
        }
    }
}
