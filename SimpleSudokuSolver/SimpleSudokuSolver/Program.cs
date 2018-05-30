using SimpleSudokuSolver.Strategies;
using SimpleSudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
            SudokuMapper sudokuMapper = new SudokuMapper();
            Displayer displayer = new Displayer();
            SudokuEngine sudokuEngine = new SudokuEngine(sudokuBoardStateManager, sudokuMapper);
            SudokuFileReader sudokuFileReader = new SudokuFileReader();

            string fileName = "SudokuEasy.txt";

            var sudokuBoard = sudokuFileReader.FileReader(fileName);

            displayer.Display("initial", sudokuBoard);

            sudokuEngine.SolveSudoku(sudokuBoard);

            displayer.Display("final", sudokuBoard);

            Console.ReadKey();


        }
    }
}
