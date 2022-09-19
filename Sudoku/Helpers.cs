using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sudoku
{
    internal class Helpers
    {
        public static readonly IReadOnlyCollection<int> Numbers = new ReadOnlyCollection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
    }
}
