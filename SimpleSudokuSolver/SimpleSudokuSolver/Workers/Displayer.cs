using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSudokuSolver.Workers
{
    class Displayer
    {
        public void Display(string title, int[,] sudokuBoard)
        {
            Console.WriteLine(title + ":");

            for (int row = 0; row < 9; row++)
            {
                Console.Write("|");

                for (int col = 0; col < 9; col++)
                {
                    Console.Write(sudokuBoard[row,col] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
