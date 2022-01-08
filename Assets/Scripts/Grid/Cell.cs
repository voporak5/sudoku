namespace Sudoku
{
    public class Cell
    {
        public Key Key { get; private set; }
        public string Value { get; private set; }
        public string FilledValue { get; private set; }
        public bool IsLocked { get; private set; }
        public Cell(int row,int column,string value)
        {
            Key = new Key(row,column);
            Value = value;
        }

        public void Write(string value)
        {
            if (IsLocked) return;

            FilledValue = value;

            if (Value == FilledValue) IsLocked = true;
        }

        public void Free()
        {
            FilledValue = string.Empty;
            IsLocked = false;
        }

        public override string ToString()
        {
            return string.Format("Key: {0}, Value: {1}",Key.ToString(),Value);
        }
    }
}