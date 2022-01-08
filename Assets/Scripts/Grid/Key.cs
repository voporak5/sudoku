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

        public override string ToString()
        {
            return string.Format("Row: {0} Column: {1}", Row, Column);
        }
    }
}
