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
            SudokuFileReader fileReader = new SudokuFileReader();

            var table = fileReader.FileReader("SudokuEasy.txt");

            foreach(var t in table)
            {
                Console.WriteLine(t);
            }

            Console.ReadKey();
        }
    }
}
