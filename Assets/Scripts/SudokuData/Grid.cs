using System;

namespace Sudoku.Data
{
    public class Grid
    {
        private int size;
        private Cell[,] grid;

        public void Build()
        {

        }

        public void ParseData(string[,] s,out bool success)
        {
            int numberOfRows = s.GetLength(0);
            int numberOfColumns = s.GetLength(1);
            bool isDataInvalid = Math.Sqrt(numberOfRows) % 1 != 0 || numberOfColumns != numberOfRows;

            if(isDataInvalid)
            {
                success = false;
                return;
            }

            grid = new Cell[numberOfRows, numberOfColumns];

            for(int row = 0; row < numberOfRows;row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    string value = s[row, column];
                    grid[row, column] = new Cell(row, column, value);
                }
            }

            size = numberOfRows;
            success = true;
        }

        public void Write(Key k, string value,Action<WriteType> onComplete = null)
        {
            Cell c = grid[k.Row, k.Column];

            if(c.IsLocked)
            {
                onComplete?.Invoke(WriteType.FAILURE);
                return;
            }

            c.Write(value);

            if (c.IsLocked) onComplete?.Invoke(WriteType.SUCCESS);
            else onComplete?.Invoke(WriteType.ERROR);

        }

        public void FreeAnswers(string[,] s)
        {
            IterateGrid(c =>
            {
                Key k = c.Key;
                if (s[k.Row, k.Column] == "0") c.Free();
            });
        }

        public bool IsLocked(int row, int column)
        {
            return grid[row, column].IsLocked;
        }

        private void IterateGrid(Action<Cell> onIterate)
        {
            for(int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    onIterate(grid[row, column]);
                }
            }
        }
    }
}