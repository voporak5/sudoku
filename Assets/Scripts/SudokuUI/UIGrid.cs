using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Sudoku.UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class UIGrid : MonoBehaviour
    {
        [SerializeField] private UICell cellPrefab;
        [SerializeField] private RectTransform outlinePrefab;

        private GridLayoutGroup layout;
        private int size;
        private double nestedSize;
        private float nestedWidth;
        private Vector2 origin;

        private void Awake()
        {
            layout = GetComponent<GridLayoutGroup>();
        }

        private void Start()
        {
            RectTransform r = GetComponent<RectTransform>();
            origin = new Vector2(r.rect.width/2, -r.rect.height/2);
        }

        /// <summary>
        /// Builds the grid
        /// </summary>
        /// <param name="size">Number of cells in a row/column</param>
        /// <param name="success"></param>
        public void Init(int size, out bool success)
        {
            nestedSize = Math.Sqrt(size);
            // In sudoku, rows/columns have to be perfect squared numbers 9x9,16x16,25x25
            bool isSizeInvalid = nestedSize % 1 != 0;

            if (isSizeInvalid)
            {
                success = false;
                return;
            }

            this.size = size;

            ConfigureGrid();
            AddCells();
            DrawOutline();

            success = true;
        }

        void ConfigureGrid()
        {            
            layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            layout.constraintCount = size;
            nestedWidth = (float)(nestedSize * layout.cellSize.x);
        }

        void AddCells()
        {
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    UICell c = Instantiate(cellPrefab, transform) as UICell;
                }
            }
        }

        void DrawOutline()
        {
            Vector2 start = origin - new Vector2(nestedWidth, -nestedWidth);

            for (int row = 0; row < nestedSize; row++)
            {
                for (int column = 0; column < nestedSize; column++)
                {
                    Vector2 pos = start + new Vector2(nestedWidth * column, -nestedWidth * row);
                    RectTransform r = Instantiate(outlinePrefab, transform) as RectTransform;

                    r.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nestedWidth);
                    r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, nestedWidth);
                    r.anchoredPosition = pos;
                }
            }
        }
    }
}