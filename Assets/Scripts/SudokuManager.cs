using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sudoku.Data;
using Sudoku.UI;

namespace Sudoku
{
    public class SudokuManager : MonoBehaviour
    {
        [SerializeField] UIGrid uiGrid;
        [SerializeField] bool success;
        [SerializeField] int size;
       
        [ContextMenu("Initialize Grid")]
        void InitializeGrid()
        {
            uiGrid.Init(size, out success);
        }

    }
}