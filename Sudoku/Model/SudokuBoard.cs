using Sudoku.Solver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku.Model
{
    /// <summary>
    /// Class of board for Sudoku game
    /// </summary>
    public class SudokuBoard
    {
        private readonly static Random random = new Random();
        private readonly Cell[][] _board;

        /// <summary>
        /// Board cells
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Cell object</returns>
        public Cell this[int x, int y] => _board[x][y];

        /// <summary>
        /// All cells in enumerable form
        /// </summary>
        public IEnumerable<Cell> Cells;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public SudokuBoard(int[][] board)
        {
            int index = 0;
            _board = new Cell[9][];
            List<Cell> list = new List<Cell>();
            for (int x = 0; x < 9; x++)
            {
                _board[x] = new Cell[9];
                for (int y = 0; y < 9; y++)
                {
                    Cell cell = new Cell(this, board[x][y], new Position(x, y), index++);
                    _board[x][y] = cell;
                    list.Add(cell);
                }
            }
            Cells = list;
            RefreshCandidates();
        }

        #region Blank and random game board generator
        public static SudokuBoard Blank
        {
            get
            {
                int[][] board = new int[9][];
                for (int i = 0; i < 9; i++)
                    board[i] = new int[9];
                return new SudokuBoard(board);
            }
        }

        internal static SudokuBoard Random(GameDifficulty difficulty)
        {
            ISolver solver = Solver.Solver.DefaultSolver.SetBoard(Blank);
            solver.Solve();
            var mask = difficulty switch
            {
                GameDifficulty.Easy => GenerateIndexes(random.Next(31, 39), 81),
                GameDifficulty.Medium => GenerateIndexes(random.Next(24, 31), 81),
                GameDifficulty.Hard => GenerateIndexes(random.Next(16, 24), 81),
                _ => throw new NotImplementedException()
            };
            foreach (var cell in solver.Board.Cells)
                cell.SetOriginal(!mask.Contains(cell.Index) ? 0 : cell.Value);
            solver.Board.RefreshCandidates();
            return solver.Board;
        }

        static List<int> GenerateIndexes(int numbers, int total)
        {
            return Enumerable.Range(0, numbers).Select(x => random.Next(0, total)).ToList();
        }

        #endregion

        #region Load and Save

        /// <summary>
        /// Load board from file of 9 lines and 9 numbers on line
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>new Sudoku board</returns>
        /// <exception cref="InvalidDataException">When data file hasn't 9 line or 9 columns</exception>
        public static SudokuBoard Load(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length != 9)
                throw new InvalidDataException("Board musí mít 9 řádků.");
            int[][] board = new int[9][];
            for (int x = 0; x < 9; x++)
            {
                string line = lines[x];
                if (line.Length != 9)
                    throw new InvalidDataException("Řádek musí mít 9 hodnot.");
                board[x] = new int[9];
                for (int y = 0; y < 9; y++)
                {
                    if (int.TryParse(line[y].ToString(), out int value))
                    {
                        board[x][y] = value;
                    }
                }
            }
            return new SudokuBoard(board);
        }

        /// <summary>
        /// Save board to file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void Save(string fileName)
        {
            bool useOriginalValue = Cells.Any(p => p.OriginalValue != 0);
            using (var file = new StreamWriter(fileName))
            {
                for (int x = 0; x < 9; x++)
                {
                    string line = string.Empty;
                    for (int y = 0; y < 9; y++)
                    {
                        Cell cell = this[x, y];
                        if (useOriginalValue)
                            line += cell.OriginalValue == 0 ? "-" : cell.OriginalValue.ToString();
                        else
                            line += cell.Value == 0 ? "-" : cell.Value.ToString();
                    }
                    file.WriteLine(line);
                }
            }
        }

        #endregion
        #region Candidates
        public void AddCandidates(IEnumerable<Cell> cells, int candidate)
        {
            foreach (var cell in cells)
            {
                cell.Candidates.Add(candidate);
            }
        }

        public void RemoveCandidates(IEnumerable<Cell> cells, int candidate)
        {
            foreach (var cell in cells)
            {
                cell.Candidates.Remove(candidate);
            }
        }

        public void RefreshCandidates()
        {
            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    foreach (int i in Helpers.Numbers)
                        this[x, y].Candidates.Add(i);
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Cell cell = this[x, y];
                    if (cell.Value != 0)
                        cell.Set(cell.Value);
                }
            }
        }

        #endregion

        public bool IsFullyFilled() => Cells.All(p => p.Value > 0);

        public bool IsValid() => Solver.Solver.DefaultSolver.SetBoard(this).ValidateBoard();
    }
}
