using System.Collections.Generic;

namespace WinFormTest
{
    class MazeSolver
    {

        private FieldGrid mGrid;

        private FieldCoord mStart = null;
        private FieldCoord mFinish = null;

        private List<List<FieldCoord>> mSolutions;

        public MazeSolver(FieldGrid fieldgrid)
        {
            mGrid = fieldgrid;
            mSolutions = new List<List<FieldCoord>>();
        }

        public List<List<FieldCoord>> GetSolutions()
        {
            return mSolutions;
        }

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

        public void Solve()
        {
            mStart = FindFieldElement(FieldElement.Start);

            mFinish = FindFieldElement(FieldElement.Finish);

            if (mStart == null || mFinish == null) return;

            List<FieldCoord> path = new List<FieldCoord>();
            path.Add(mStart);

            ProcessNode(mStart, path);
        }

        private List<FieldCoord> GetBorder(FieldCoord node)
        {
            List<FieldCoord> border = new List<FieldCoord>();

            if (node.Row - 1 >= 0)
            {
                FieldElement elem = mGrid.GetCell(node.Row - 1, node.Col);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row - 1, node.Col));
                }
            }

            if (node.Row + 1 < mGrid.Rows)
            {
                FieldElement elem = mGrid.GetCell(node.Row + 1, node.Col);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row + 1, node.Col));
                }
            }

            if (node.Col - 1 >= 0)
            {
                FieldElement elem = mGrid.GetCell(node.Row, node.Col - 1);
                if (elem == FieldElement.Empty || elem == FieldElement.Finish)
                {
                    border.Add(new FieldCoord(node.Row, node.Col - 1));
                }
            }

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
}
