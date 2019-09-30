namespace WinFormTest
{
    /// <summary>
    /// Emumeration to classify the grid element types
    /// </summary>
    public enum FieldElement { Empty = 0, Wall = 1, Start = 2, Finish = 3};

    /// <summary>
    /// The field grid of cells represeting the maze
    /// </summary>
    public class FieldGrid
    {
        private int mCols;
        private int mRows;
        private FieldElement[,] mGrid;

        /// <summary>
        /// Public constructor 
        /// </summary>
        /// <param name="cols">Wanted columns</param>
        /// <param name="rows">Wanted rows</param>
        public FieldGrid(int cols, int rows)
        {
            mCols = cols;
            mRows = rows;
            mGrid = null;
            Update();
        }

        /// <summary>
        /// Number of columns
        /// </summary>
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

        /// <summary>
        /// Number of rows
        /// </summary>
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

        /// <summary>
        /// Set the cell element type
        /// </summary>
        /// <param name="row">Row coordinate</param>
        /// <param name="col">Column coordinate</param>
        /// <param name="element">Element to be assigned to cell</param>
        public void SetCell(int row, int col, FieldElement element)
        {
            if (row < mGrid.GetLength(0) && col < mGrid.GetLength(1) && row >= 0 && col >= 0)
            {
                mGrid[row, col] = element;
            }

        }

        /// <summary>
        /// Get the cell element type
        /// </summary>
        /// <param name="row">Row coordinate</param>
        /// <param name="col">Column coordinate</param>
        /// <returns>The element contained in the cell grid</returns>
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

        /// <summary>
        /// Clear the cells of the grid from a specific element
        /// </summary>
        /// <param name="element">The element to be cleared</param>
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

        /// <summary>
        /// Initialize the grid elements
        /// </summary>
        /// <param name="grid">The grid to be processed</param>
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

        /// <summary>
        /// Update the grid starting from the selected numeber of Rows and Columns
        /// </summary>
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
