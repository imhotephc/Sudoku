using Sudoku.Model;

namespace Sudoku.Solver
{
    /// <summary>
    /// Interface for solver classes
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// Attach board to solver
        /// </summary>
        /// <param name="boardInstance">board which </param>
        /// <returns>Instance of solver</returns>
        public ISolver SetBoard(SudokuBoard boardInstance);

        /// <summary>
        /// Try to solve board
        /// </summary>
        /// <returns>True if successfull</returns>
        public bool Solve();

        /// <summary>
        /// Board to solve
        /// </summary>
        SudokuBoard Board { get; }

        /// <summary>
        /// Check if board is valid
        /// </summary>
        /// <returns>True if board is valid</returns>
        bool ValidateBoard();

        /// <summary>
        /// Check if value is valid for cell
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="cell">Cell</param>
        /// <returns>True if value is valid for cell</returns>
        bool IsValidValueForCell(int value, Cell cell);
    }
}
