using System;

namespace Sudoku
{
    public interface IGrid
    {
        void ParseData(string[,] s, out bool success);
        void Write(Key k, string val, Action<WriteType> onComplete);
        void FreeAnswers(string[,] s);

    }
}