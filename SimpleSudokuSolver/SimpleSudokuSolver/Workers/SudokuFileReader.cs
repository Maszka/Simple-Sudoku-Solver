using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleSudokuSolver.Workers
{
    class SudokuFileReader
    {
        public int[,] FileReader(string fileName)
        {
            int[,] sudokuBoard = new int[9, 9];

            string[] sudokuAllLines = File.ReadAllLines(fileName);

            int row = 0;
            foreach (var sudokuLine in sudokuAllLines)
            {
                string[] sudokuBoardLineElements = sudokuLine.Split('|').Skip(1).Take(9).ToArray();

                int col = 0;
                foreach(var sudokuBoardElement in sudokuBoardLineElements)
                {
                    sudokuBoard[row, col] = sudokuBoardElement.Equals(" ") ? 0 : Convert.ToInt16(sudokuBoardElement);
                    col++;
                }
                row++;
            }

            return sudokuBoard;
        }
    }
}
