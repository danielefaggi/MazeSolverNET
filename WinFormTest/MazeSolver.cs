using System.Collections.Generic;

namespace WinFormTest
{
    /// <summary>
    /// Class that implements a solver for a maze with depth first algorithm
    /// </summary>
    public class MazeSolver
    {

        private FieldGrid mGrid;

        private FieldCoord mStart = null;
        private FieldCoord mFinish = null;

        private List<List<FieldCoord>> mSolutions;

        /// <summary>
        /// Public constructor, it gets the grid on which work on
        /// </summary>
        /// <param name="fieldgrid"></param>
        public MazeSolver(FieldGrid fieldgrid)
        {
            mGrid = fieldgrid;
            mSolutions = new List<List<FieldCoord>>();
        }

        /// <summary>
        /// Get the solutions in order of match
        /// </summary>
        /// <returns>The list containing the solutions</returns>
        public List<List<FieldCoord>> GetSolutions()
        {
            return mSolutions;
        }

        /// <summary>
        /// Gets the solutions in order of number of steps
        /// </summary>
        /// <returns>The list conaining the solutions</returns>
        public List<List<FieldCoord>> GetSortedSolutions()
        {
            List <List<FieldCoord>> s = new List<List<FieldCoord>>(mSolutions);
            s.Sort(new CompareSolution());
            //s.Reverse();
            return s;
        }

        /// <summary>
        /// Find the coordinates of a specific FieldElement element
        /// </summary>
        /// <param name="element">The element to be found</param>
        /// <returns>The coordinates of the element found of null if it is not found</returns>
        private FieldCoord FindFieldElement(FieldElement element)
        {
            for(int r = 0; r < mGrid.Rows; r++)
            {
                for(int c = 0; c < mGrid.Cols; c++)
                {
                    if(mGrid.GetCell(r, c) == element)
                    {
                        return new FieldCoord(r, c);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Found the solutions of the maze with depth first algorithm
        /// </summary>
        public void Solve()
        {
            mStart = FindFieldElement(FieldElement.Start);

            mFinish = FindFieldElement(FieldElement.Finish);

            if (mStart == null || mFinish == null) return;

            List<FieldCoord> path = new List<FieldCoord>();
            path.Add(mStart);

            ProcessNode(mStart, path);
        }

        /// <summary>
        /// Get the closest elements to this grid cell
        /// </summary>
        /// <param name="node">The coodinates related to the current grid cell</param>
        /// <returns>The elements in the border</returns>
        private List<FieldCoord> GetBorder(FieldCoord node)
        {
            List<FieldCoord> border = new List<FieldCoord>();

            // North
            if (node.Row - 1 >= 0)
            {
                FieldElement elem = mGrid.GetCell(node.Row - 1, node.Col);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row - 1, node.Col));
                }
            }

            // South
            if (node.Row + 1 < mGrid.Rows)
            {
                FieldElement elem = mGrid.GetCell(node.Row + 1, node.Col);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row + 1, node.Col));
                }
            }

            // West
            if (node.Col - 1 >= 0)
            {
                FieldElement elem = mGrid.GetCell(node.Row, node.Col - 1);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row, node.Col - 1));
                }
            }

            // East
            if (node.Col + 1 < mGrid.Cols)
            {
                FieldElement elem = mGrid.GetCell(node.Row, node.Col + 1);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row, node.Col + 1));
                }
            }

            return border;
        }

        /// <summary>
        /// Process a node, finding new paths
        /// </summary>
        /// <param name="node">The current node</param>
        /// <param name="path">The path travelled so far</param>
        public void ProcessNode(FieldCoord node, List<FieldCoord> path)
        {
            List<FieldCoord> border = GetBorder(node);

            foreach(FieldCoord newnode in border)
            {
                bool present = false;
                foreach(FieldCoord fc in path)
                {
                    if(fc.Row == newnode.Row && fc.Col == newnode.Col)
                    {                        
                        present = true;
                        break;
                    }
                }

                if(!present)
                {

                    List<FieldCoord> newpath = new List<FieldCoord>(path);

                    newpath.Add(newnode);
                    if (mGrid.GetCell(newnode.Row, newnode.Col) == FieldElement.Finish)
                    {
                        mSolutions.Add(newpath);
                    }
                    else
                    {
                        ProcessNode(newnode, newpath);
                    }
                }
            }

        }
    }

    /// <summary>
    /// Utility class to sort the found solutions
    /// </summary>
    public class CompareSolution : IComparer<List<FieldCoord>>
    {
        public int Compare(List<FieldCoord> x, List<FieldCoord> y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Count.CompareTo(y.Count);
        }
    }
}
