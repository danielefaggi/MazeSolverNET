using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{

    public enum FieldElement { Empty = 0, Wall = 1, Start = 2, Finish = 3};

    class FieldGrid
    {
        private int mCols;
        private int mRows;
        private FieldElement[,] mGrid;

        public FieldGrid(int cols, int rows)
        {
            mCols = cols;
            mRows = rows;
            mGrid = null;
            Update();
        }

        public int Cols
        {
            get
            {
                return mCols;
            }
            set
            {
                mCols = value;
                Update();
            }
        }

        public int Rows
        {
            get
            {
                return mRows;
            }
            set
            {
                mRows = value;
                Update();
            }
        }

        public void SetCell(int row, int col, FieldElement element)
        {
            if (row < mGrid.GetLength(0) && col < mGrid.GetLength(1) && row >= 0 && col >= 0)
            {
                mGrid[row, col] = element;
            }

        }

        public FieldElement GetCell(int row, int col)
        {
            if (row < mGrid.GetLength(0) && col < mGrid.GetLength(1) && row >= 0 && col >= 0)
            {
                return mGrid[row, col];
            }
            else
            {
                return FieldElement.Empty;
            }
        }

        public void ClearCells(FieldElement element)
        {
            for(int r = 0; r < mGrid.GetLength(0); r++)
            {
                for(int c = 0; c < mGrid.GetLength(1); c++)
                {
                    if(mGrid[r, c] == element)
                    {
                        mGrid[r, c] = FieldElement.Empty;
                    }
                }
            }
        }

        private static void InitGrid(FieldElement[,] grid)
        {
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for(int c = 0; c < grid.GetLength(1); c++)
                {
                    grid[r, c] = FieldElement.Empty;
                }
            }

        }

        private void Update()
        {
            FieldElement[,] newgrid = new FieldElement[mRows,mCols];

            InitGrid(newgrid);

            if(mGrid == null)
            {
                mGrid = newgrid;

                return;
            }

            for(int r = 0; r<mRows; r++)
            {
                for(int c = 0; c < mCols; c++)
                {
                    if(r < mGrid.GetLength(0))
                    {
                        if(c < mGrid.GetLength(1))
                        {
                            newgrid[r, c] = mGrid[r, c];
                        }
                    }
                }
            }

            mGrid = newgrid;
        }

    }
}
