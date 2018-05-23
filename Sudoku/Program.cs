using System;
using System.Diagnostics;

namespace Sudoku
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var sudoku = new Sudoku("./input.txt");
            var visualiser = new SudokuVisualiser(sudoku);
            var solver = new SudokuSolver(sudoku, visualiser);
            solver.Solve();

            stopWatch.Stop();
            Console.WriteLine($"Finished in {stopWatch.Elapsed}");
        }
    }
}
