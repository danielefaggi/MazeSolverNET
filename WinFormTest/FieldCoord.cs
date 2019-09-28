using System.Collections.Generic;

namespace WinFormTest
{
    class FieldCoord: IComparer<FieldCoord>
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public FieldCoord(int Row, int Col)
        {
            this.Row = Row;
            this.Col = Col;
        }


        public int Compare(FieldCoord x, FieldCoord y)
        {
            FieldCoord fx = (FieldCoord) x;
            FieldCoord fy = (FieldCoord) y;

            if (x.Row < x.Row)
            {
                return -1;
            }
            else if (x.Row == y.Row)
            {
                if (x.Col < y.Col)
                {
                    return -1;
                }
                else if (x.Col > y.Col)
                {
                    return 1;
                }
            }
            else if (x.Row > y.Row)
            {
                return 1;
            }

            return 0;
        }
    }
}
