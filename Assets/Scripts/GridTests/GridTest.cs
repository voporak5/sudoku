using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Sudoku;

namespace Tests
{
    public class GridTest
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
            grid.ParseData(testGrid,out success);
            Debug.Log(grid.ToString());
            Assert.IsTrue(success);

        }

        [Test]
        public void InvalidGridParseTest()
        {
            string[,] testGrid = new string[8, 8] {
                {"2","1","9","5","4","3","6","7"},
                {"5","4","3","8","7","6","9","1"},
                {"8","7","6","2","1","9","3","4"},
                {"4","3","2","7","6","5","8","9"},
                {"7","6","5","1","9","8","2","3"},
                {"1","9","8","4","3","2","5","6"},
                {"3","2","1","6","5","4","7","8"},
                {"6","5","4","9","8","7","1","2"}
            };

            bool success = false;
            Sudoku.Grid grid = new Sudoku.Grid();
            grid.ParseData(testGrid, out success);

            Assert.IsFalse(success);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GridTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
