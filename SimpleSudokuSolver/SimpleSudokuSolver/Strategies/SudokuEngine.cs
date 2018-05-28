using SimpleSudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSudokuSolver.Strategies
{
    class SudokuEngine
    {
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuEngine(SudokuBoardStateManager sudokuBoardStateManager, SudokuMapper sudokuMapper)
        {
            _sudokuBoardStateManager = sudokuBoardStateManager;
            _sudokuMapper = sudokuMapper;
        }

        public bool SolveSudoku(int[,] sudokuBoard)
        {
            List<IStrategy> strategies = new List<IStrategy>()
            {

            };

            var currentState = _sudokuBoardStateManager.GenerateState(sudokuBoard);
            var nextState = _sudokuBoardStateManager.GenerateState(strategies.First().Solve(sudokuBoard));

            if (!_sudokuBoardStateManager.IsSolved(sudokuBoard))
            {
                nextState = currentState;

                foreach (var strategy in strategies)
                {
                    nextState = _sudokuBoardStateManager.GenerateState(strategy.Solve(sudokuBoard));
                }
            }

            return _sudokuBoardStateManager.IsSolved(sudokuBoard);
        }
    }
}
