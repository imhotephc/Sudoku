using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Model
{
    /// <summary>
    /// Cell details
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Value of cell
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Original value of cell
        /// </summary>
        public int OriginalValue { get; private set; }
        /// <summary>
        /// Position of cell
        /// </summary>
        public Position Position { get; private set; }
        /// <summary>
        /// Unique index of cell
        /// </summary>
        public int Index { get; private set; }

        public HashSet<int> Candidates { get; } = new HashSet<int>(Helpers.Numbers);

        private readonly SudokuBoard _board;

        /// <summary>
        /// Cell constructor
        /// </summary>
        /// <param name="board"></param>
        /// <param name="value"></param>
        /// <param name="position"></param>
        public Cell(SudokuBoard board, int value, Position position, int index)
        {
            _board = board;
            OriginalValue = Value = value;
            Position = position;
            Index = index;
        }

        public void Set(int value, bool refreshCandidates = false)
        {
            int oldValue = Value;
            if (OriginalValue == 0)
                Value = value;
            if (value == 0)
            {
                for (int i = 1; i < 10; i++)
                    Candidates.Add(i);
                if (oldValue > 0)
                    _board.AddCandidates(GetAffectedCells(), oldValue);
            }
            else
            {
                Candidates.Clear();
                _board.RemoveCandidates(GetAffectedCells(), value);
            }
            if (refreshCandidates)
                _board.RefreshCandidates();
        }

        public void SetOriginal(int value)
        {
            OriginalValue = value;
            Set(value);
        }

        /// <summary>
        /// Return cells which are in same row or same column or same group
        /// </summary>
        /// <returns>enumerable of cell</returns>
        public IEnumerable<Cell> GetAffectedCells()
        {
            return _board.Cells
                .Where(p => p.Position.Row == Position.Row ||
                          p.Position.Column == Position.Column ||
                          p.Position.Group == Position.Group)
                .Except(new Cell[] { this });
        }
    }
}
