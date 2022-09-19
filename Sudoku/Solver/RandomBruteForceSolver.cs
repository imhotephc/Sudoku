using Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Solver
{
    internal class RandomBruteForceSolver : Solver
    {
        List<int> filledCells = new List<int>();
        List<List<int>> blackListCells;
        Random random = new Random();

        public override ISolver SetBoard(SudokuBoard boardInstance)
        {
            base.SetBoard(boardInstance);
            blackListCells = new List<List<int>>(board.Cells.Count());
            for (int i = 0; i < blackListCells.Capacity; i++)
                blackListCells.Add(new List<int>());
            return this;
        }

        public override bool Solve()
        {
            if (!ValidateBoard())
                return false;

            filledCells.Clear();
            filledCells.AddRange(board.Cells.Where(p => p.Value > 0).Select(s => s.Index));

            ClearBlackList();

            int currentCellIndex = 0;
            var cells = board.Cells.ToArray();

            while (currentCellIndex < cells.Count())
            {
                Cell currentCell = cells[currentCellIndex];
                if (filledCells.Contains(currentCellIndex))
                {
                    ++currentCellIndex;
                    continue;
                }
                ClearBlackList(currentCellIndex + 1);
                int number = GetValidNumberForCell(currentCellIndex, currentCell);
                if (number == 0)
                    currentCellIndex = BackTrackTo(currentCellIndex);
                else
                {
                    currentCell.Set(number);
                    ++currentCellIndex;
                }
            }

            return true;
        }

        int BackTrackTo(int index)
        {
            while (filledCells.Contains(--index)) ;
            Cell backTrackedCell = board.Cells.First(p => p.Index == index);
            AddToBlackList(backTrackedCell.Value, index);
            backTrackedCell.Set(0);
            ClearBlackList(index + 1);
            return index;
        }

        int GetValidNumberForCell(int index, Cell cell)
        {
            int number = 0;
            var valid = cell.Candidates.Where(p => !blackListCells[index].Contains(p)).ToArray();
            if (valid.Length > 0)
            {
                number = valid[random.Next(valid.Length)];
            }
            do
            {
                if (number != 0 && !IsValidValueForCell(number, cell))
                    AddToBlackList(number, index);
                else
                    break;
                number = GetValidNumberForCell(index, cell);
            } while (number != 0);
            return number;
        }

        void ClearBlackList(int startIndex = 0)
        {
            for (int i = startIndex; i < blackListCells.Count; i++)
                blackListCells[i].Clear();
        }

        void AddToBlackList(int number, int index) => blackListCells[index].Add(number);

    }

}
