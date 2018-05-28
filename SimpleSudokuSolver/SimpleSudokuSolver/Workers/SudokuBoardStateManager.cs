using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSudokuSolver.Workers
{
    class SudokuBoardStateManager
    {
        public string GenerateState(int[,] sudokuBoard)
        {
            StringBuilder key = new StringBuilder();

            for(int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    key.Append(sudokuBoard[row, col]);
                }
            }

            return key.ToString();
        }

        public bool IsSolved(int[,] sudokuBoard)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1) return false;
                }
            }
            return true;
        }
    }
}
