using System;

namespace Sudoku
{
    public class Grid : IGrid
    {
        private int size;
        private Cell[,] grid;

        public void Build(string[,] s1, string[,] s2, out bool success)
        {
            bool s = false;

            ParseData(s1,out s);

            success = s;

            FreeAnswers(s2);
        }

        public void FreeAnswers(string[,] s)
        {
            IterateGrid(c =>
            {
                Key k = c.Key;
                if (s[k.Row, k.Column] == "0") c.Free();
            });
        }

        public void ParseData(string[,] s,out bool success)
        {
            // in 9x9 this will return 9 number of rows
            int rowLength = s.GetLength(0);
            int columnLength = s.GetLength(1);
            //all rows and columns must be some perfect square length
            //and they must match
            bool isDataInvalid = System.Math.Sqrt(rowLength) % 1 != 0 || columnLength != rowLength;

            if (isDataInvalid)
            {
                success = false;
                return;
            }

            grid = new Cell[rowLength, columnLength];

            for(int row = 0;row < rowLength;row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    string value = s[row, column];
                    grid[row, column] = new Cell(row, column, value);
                }
            }

            size = rowLength;
            success = true;

        }

        public void Write(Key k,string val, Action<WriteType> onComplete)
        {

            Cell c = grid[k.Row, k.Column];

            if (c.IsLocked)
            {
                onComplete(WriteType.FAILURE);
                return;
            }

            c.Write(val);

            if (c.IsLocked) onComplete(WriteType.SUCCESS);
            else onComplete(WriteType.ERROR);

        }

        public bool IsFilled(int row, int column)
        {
            return grid[row, column].IsLocked;
        }

        private void IterateGrid(System.Action<Cell> onIterate)
        {
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    onIterate(grid[row, column]);
                }
            }
        }

        public override string ToString()
        {
            string s = string.Format("Size: {0}",size);

            IterateGrid(c =>
            {
                s += string.Format("\n{0}", c.ToString());
            });


            return s;
        }
    }
}