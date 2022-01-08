namespace Sudoku
{
    public class Key
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Key(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}