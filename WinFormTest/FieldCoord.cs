using System.Collections.Generic;

namespace WinFormTest
{
    /// <summary>
    /// Class that identifies a coordinate in a grid system
    /// </summary>
    public class FieldCoord 
    {
        public int Row { get; set; }
        public int Col { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="Row">Referenced row</param>
        /// <param name="Col">Referenced column</param>
        public FieldCoord(int Row, int Col)
        {
            this.Row = Row;
            this.Col = Col;
        }

    }
}
