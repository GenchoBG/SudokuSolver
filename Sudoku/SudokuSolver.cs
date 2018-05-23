namespace Sudoku
{
    public class SudokuSolver
    {
        private bool solved;
        private readonly Sudoku sudoku;
        private readonly SudokuVisualiser visualiser;

        public SudokuSolver(Sudoku sudoku, SudokuVisualiser visualiser)
        {
            this.solved = false;
            this.sudoku = sudoku;
            this.visualiser = visualiser;
        }

        (int row, int col) GetNextPos(int row, int col)
        {
            var newRow = row;
            var newCol = col;
            do
            {
                newCol++;
                if (newCol >= Sudoku.Size)
                {
                    newCol %= Sudoku.Size;
                    newRow++;
                    if (newRow >= Sudoku.Size)
                    {
                        newRow %= Sudoku.Size;
                    }
                }
            } while (this.sudoku.Board[newRow][newCol] != 0);

            return (newRow, newCol);
        }

        public void Solve(int row = 0, int col = -1)
        {
            if (this.solved)
            {
                return;
            }

            if (row == Sudoku.Size - 1 && col == Sudoku.Size - 1)
            {
                this.solved = true;
                this.visualiser.PrintSudoku();
                return;
            }

            var nextPos = this.GetNextPos(row, col);

            for (int currentValue = 1; currentValue <= Sudoku.Size; currentValue++)
            {
                if (this.sudoku.IsValidMove(nextPos.row, nextPos.col, currentValue))
                {
                    this.sudoku.Board[nextPos.row][nextPos.col] = currentValue;
                    this.Solve(nextPos.row, nextPos.col);
                    this.sudoku.Board[nextPos.row][nextPos.col] = 0;
                }
            }
        }
    }
}