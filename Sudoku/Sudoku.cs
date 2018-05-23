using System.IO;
using System.Linq;

namespace Sudoku
{
    public class Sudoku
    {
        public const int Size = 9;

        public Sudoku(string inputPath)
        {
            var data = File.ReadAllLines(inputPath);
            this.Board = new int[Size][];
            for (int i = 0; i < Size; i++)
            {
                this.Board[i] = data[i].ToCharArray().Select(c => c - '0').ToArray();
            }
        }

        public int[][] Board { get; set; }

        public bool IsValidMove(int row, int col, int value)
        {

            //check horizontal
            for (int currentCol = 0; currentCol < Size; currentCol++)
            {
                if (this.Board[row][currentCol] == value)
                {
                    return false;
                }
            }

            //check vertical
            for (int currentRow = 0; currentRow < Size; currentRow++)
            {
                if (this.Board[currentRow][col] == value)
                {
                    return false;
                }
            }

            //check cell
            var cellRow = row / 3;
            var cellCol = col / 3;
            for (int currentRow = cellRow * 3; currentRow < cellRow + 3; currentRow++)
            {
                for (int currentCol = cellCol * 3; currentCol < cellCol + 3; currentCol++)
                {
                    if (this.Board[currentRow][currentCol] == value)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}