using Sudoku.Model;
using System.Linq;

namespace Sudoku.Solver
{
    /// <summary>
    /// Abstract implementation of solver
    /// </summary>
    public abstract class Solver : ISolver
    {
        /// <summary>
        /// Global default solver class
        /// </summary>
        public static ISolver DefaultSolver => new RandomBruteForceSolver();

        /// <summary>
        /// Board to solve
        /// </summary>
        public SudokuBoard Board => board;
        protected SudokuBoard board;


        public virtual ISolver SetBoard(SudokuBoard boardInstance)
        {
            board = boardInstance ?? SudokuBoard.Blank;
            return this;
        }

        public abstract bool Solve();

        public bool ValidateBoard() =>
        board.Cells
            .Where(c => c.Value > 0)
            .FirstOrDefault(c => c.Value > 0 && !IsValidValueForCell(c.Value, c)) == null;

        public bool IsValidValueForCell(int value, Cell cell) =>
            board.Cells
                .Where(c => c.Position != cell.Position &&
                    (c.Position.Group == cell.Position.Group || c.Position.Row == cell.Position.Row || c.Position.Column == cell.Position.Column))
                .FirstOrDefault(p => p.Value == value) == null;

    }
}
