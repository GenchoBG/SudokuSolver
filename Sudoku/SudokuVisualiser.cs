using System;

namespace Sudoku
{
    public class SudokuVisualiser
    {
        private readonly Sudoku sudoku;

        public SudokuVisualiser(Sudoku sudoku)
        {
            this.sudoku = sudoku;
        }

        private void PrintBorder()
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('#');
            Console.ForegroundColor = old;
        }


        private void PrintBorderLine()
        {
            for (int i = 0; i < Sudoku.Size + 2; i++)
            {
                this.PrintBorder();
            }
            Console.WriteLine();
        }

        private void PrintNumber(int num)
        {
            var old = Console.ForegroundColor;
            if (num != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(num);
            }
            else
            {
                Console.Write(' ');
            }
            Console.ForegroundColor = old;
        }

        public void PrintSudoku()
        {
            for (int i = 0; i < Sudoku.Size; i++)
            {
                for (int j = 0; j < Sudoku.Size; j++)
                {
                    if (j % (Sudoku.Size / 3) == 0 && j != 0)
                    {
                        this.PrintBorder();
                    }
                    this.PrintNumber(this.sudoku.Board[i][j]);
                }
                Console.WriteLine();
                if ((i + 1) % (Sudoku.Size / 3) == 0 && i != Sudoku.Size - 1)
                {
                    this.PrintBorderLine();
                }
            }
        }
    }
}