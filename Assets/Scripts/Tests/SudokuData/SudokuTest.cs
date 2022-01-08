using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Sudoku;

namespace Tests
{
    public class SudokuTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ValidGridParseTest()
        {
            string[,] testGrid = new string[9, 9] {
                {"2","1","9","5","4","3","6","7","8"},
                {"5","4","3","8","7","6","9","1","2"},
                {"8","7","6","2","1","9","3","4","5"},
                {"4","3","2","7","6","5","8","9","1"},
                {"7","6","5","1","9","8","2","3","4"},
                {"1","9","8","4","3","2","5","6","7"},
                {"3","2","1","6","5","4","7","8","9"},
                {"6","5","4","9","8","7","1","2","3"},
                {"9","8","7","3","2","1","4","5","6"}
            };

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsTrue(success);
        }

        [Test]
        public void InvalidColumnGridParseTest()
        {
            string[,] testGrid = new string[9, 8] {
                {"2","1","9","5","4","3","6","7"},
                {"5","4","3","8","7","6","9","1"},
                {"8","7","6","2","1","9","3","4"},
                {"4","3","2","7","6","5","8","9"},
                {"7","6","5","1","9","8","2","3"},
                {"1","9","8","4","3","2","5","6"},
                {"3","2","1","6","5","4","7","8"},
                {"6","5","4","9","8","7","1","2"},
                {"9","8","7","3","2","1","4","5"}
            };

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsFalse(success);
        }

        [Test]
        public void InvalidRowGridParseTest()
        {
            string[,] testGrid = new string[8, 9] {
                {"2","1","9","5","4","3","6","7","8"},
                {"5","4","3","8","7","6","9","1","2"},
                {"8","7","6","2","1","9","3","4","5"},
                {"4","3","2","7","6","5","8","9","1"},
                {"7","6","5","1","9","8","2","3","4"},
                {"1","9","8","4","3","2","5","6","7"},
                {"3","2","1","6","5","4","7","8","9"},
                {"6","5","4","9","8","7","1","2","3"}
            };

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsFalse(success);
        }

        [Test]
        public void InvalidNotPerfectSquareGridParseTest()
        {
            string[,] testGrid = new string[8, 8] {
                {"2","1","9","5","4","3","6","7"},
                {"5","4","3","8","7","6","9","1"},
                {"8","7","6","2","1","9","3","4"},
                {"4","3","2","7","6","5","8","9"},
                {"7","6","5","1","9","8","2","3"},
                {"1","9","8","4","3","2","5","6"},
                {"3","2","1","6","5","4","7","8"},
                {"6","5","4","9","8","7","1","2"},
            };

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsFalse(success);
        }

        [Test]
        public void ValidFreeCellTest()
        {
            string[,] testGrid = new string[9, 9] {
                {"2","1","9","5","4","3","6","7","8"},
                {"5","4","3","8","7","6","9","1","2"},
                {"8","7","6","2","1","9","3","4","5"},
                {"4","3","2","7","6","5","8","9","1"},
                {"7","6","5","1","9","8","2","3","4"},
                {"1","9","8","4","3","2","5","6","7"},
                {"3","2","1","6","5","4","7","8","9"},
                {"6","5","4","9","8","7","1","2","3"},
                {"9","8","7","3","2","1","4","5","6"}
            };

            string[,] testPuzzle = new string[9, 9] {
                {"1","1","1","1","1","0","1","1","1"},
                {"1","0","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","0","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","0","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"}
            };            

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsTrue(success);

            grid.FreeAnswers(testPuzzle);

            Assert.IsTrue(grid.IsLocked(0,4));
            Assert.IsTrue(grid.IsLocked(0,6));
            Assert.IsTrue(grid.IsLocked(8, 8));
            Assert.IsTrue(grid.IsLocked(4, 0));
            Assert.IsFalse(grid.IsLocked(0,5));
            Assert.IsFalse(grid.IsLocked(1, 1));
            Assert.IsFalse(grid.IsLocked(4, 6));
            Assert.IsFalse(grid.IsLocked(6, 2));
        }

        [Test]
        public void WriteTest()
        {
            string[,] testGrid = new string[9, 9] {
                {"2","1","9","5","4","3","6","7","8"},
                {"5","4","3","8","7","6","9","1","2"},
                {"8","7","6","2","1","9","3","4","5"},
                {"4","3","2","7","6","5","8","9","1"},
                {"7","6","5","1","9","8","2","3","4"},
                {"1","9","8","4","3","2","5","6","7"},
                {"3","2","1","6","5","4","7","8","9"},
                {"6","5","4","9","8","7","1","2","3"},
                {"9","8","7","3","2","1","4","5","6"}
            };

            string[,] testPuzzle = new string[9, 9] {
                {"1","1","1","1","1","0","1","1","1"},
                {"1","0","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","0","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","0","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"},
                {"1","1","1","1","1","1","1","1","1"}
            };

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsTrue(success);

            grid.FreeAnswers(testPuzzle);

            Assert.IsTrue(grid.IsLocked(0, 4));
            Assert.IsTrue(grid.IsLocked(0, 6));
            Assert.IsTrue(grid.IsLocked(8, 8));
            Assert.IsTrue(grid.IsLocked(4, 0));
            Assert.IsFalse(grid.IsLocked(0, 5));
            Assert.IsFalse(grid.IsLocked(1, 1));
            Assert.IsFalse(grid.IsLocked(4, 6));
            Assert.IsFalse(grid.IsLocked(6, 2));


            grid.Write(new Key(0,5),"3");
            Assert.IsTrue(grid.IsLocked(0, 5));

            grid.Write(new Key(0, 5), "2");
            Assert.IsTrue(grid.IsLocked(0, 5));

            grid.Write(new Key(1, 1), "3");
            Assert.IsFalse(grid.IsLocked(1, 1));

            grid.Write(new Key(1, 1), "4");
            Assert.IsTrue(grid.IsLocked(1, 1));
        }
    }
}
