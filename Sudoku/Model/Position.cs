namespace Sudoku.Model
{
    /// <summary>
    /// Position details
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Row
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// Column
        /// </summary>
        public int Column { get; private set; }

        /// <summary>
        /// Group
        /// </summary>
        public int Group { get; private set; }

        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="row">row of position</param>
        /// <param name="column">column of position</param>
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
            Group = (row / 3) + (3 * (column / 3));
        }
    }
}
