using SimpleSudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSudokuSolver.Strategies
{
    class SimpleMarkUpStrategy : IStrategy
    {
        private SudokuMapper _sudokuMapper;

        public SimpleMarkUpStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(sudokuBoard, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(sudokuBoard, row, col);

                        sudokuBoard[row, col] = GetPossibilitiesIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                    }
                }
            }

            return sudokuBoard;
        }

        public int GetPossibilitiesInRowAndCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int row = 0; row < 9; row++)
            {
                if (IsValidSingle(sudokuBoard[row, givenCol]))
                {
                    possibilities[sudokuBoard[row, givenCol] - 1] = 0;
                }
            }

            for (int col = 0; col < 9; col++)
            {
                if (IsValidSingle(sudokuBoard[givenRow, col]))
                {
                    possibilities[sudokuBoard[givenRow, col] - 1] = 0;
                }
            }

            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        public int GetPossibilitiesInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sudokuMap = _sudokuMapper.FindStart(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row < sudokuMap.StartRow + 2; row++)
            {
                for (int col = sudokuMap.StartCol; col < sudokuMap.StartCol + 2; col++)
                {
                    if (IsValidSingle(sudokuBoard[row, col]))
                    {
                        possibilities[sudokuBoard[row, col] - 1] = 0;
                    }
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        public int GetPossibilitiesIntersection(int possibilitiesRowCol, int possibilitiesBlock)
        {
            var possibilitiesRowColCharArray = possibilitiesRowCol.ToString().ToCharArray();
            var possibilitiesBlockCharArray = possibilitiesBlock.ToString().ToCharArray();
            var possibilitiesIntersect = possibilitiesRowColCharArray.Intersect(possibilitiesBlockCharArray);

            return Convert.ToInt32(String.Join(string.Empty, possibilitiesIntersect));
        }


        public bool IsValidSingle (int cellDigit)
        {
            return (cellDigit.ToString().Length == 1 && cellDigit != 0);
        }
    }
}
