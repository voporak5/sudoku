namespace Sudoku
{
    public class Cell
    {
        public Key Key { get; private set; }
        public readonly string Value = string.Empty;
        public string UserValue { get; private set; }
        public bool IsLocked { get; private set; }

        public Cell(int row, int column, string value)
        {
            Key = new Key(row, column);
            Value = UserValue = value;
            IsLocked = true;
        }

        public void Write(string s)
        {
            if (IsLocked) return;

            UserValue = s;
            IsLocked = Value == UserValue;
        }

        public void Free()
        {
            UserValue = string.Empty;
            IsLocked = false;
        }
    }
}