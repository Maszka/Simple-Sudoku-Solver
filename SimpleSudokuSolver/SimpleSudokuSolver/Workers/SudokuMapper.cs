using SimpleSudokuSolver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSudokuSolver.Workers
{
    class SudokuMapper
    {
        public SudokuMap FindStart(int row, int col)
        {
            SudokuMap map = new SudokuMap();

            if ((row >= 0 && row < 3) && (col>=0 && col<3))
            {
                map.StartRow = 0;
                map.StartCol = 0;
            }

            if ((row >= 0 && row < 3) && (col >= 3 && col < 6))
            {
                map.StartRow = 0;
                map.StartCol = 3;
            }

            if ((row >= 0 && row < 3) && (col >= 6 && col < 9))
            {
                map.StartRow = 0;
                map.StartCol = 6;
            }

            if ((row >= 3 && row < 6) && (col >= 0 && col < 3))
            {
                map.StartRow = 3;
                map.StartCol = 0;
            }

            if ((row >= 3 && row < 6) && (col >= 3 && col < 6))
            {
                map.StartRow = 3;
                map.StartCol = 3;
            }

            if ((row >= 3 && row < 6) && (col >= 6 && col < 9))
            {
                map.StartRow = 3;
                map.StartCol = 6;
            }

            if ((row >= 6 && row < 9) && (col >= 0 && col < 3))
            {
                map.StartRow = 6;
                map.StartCol = 0;
            }

            if ((row >= 6 && row < 9) && (col >= 3 && col < 6))
            {
                map.StartRow = 6;
                map.StartCol = 3;
            }

            if ((row >= 6 && row < 9) && (col >= 6 && col < 9))
            {
                map.StartRow = 6;
                map.StartCol = 6;
            }

            return map;
        }

    }
}
