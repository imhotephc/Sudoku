using Sudoku.Model;
using Sudoku.Solver;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sudoku.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MinimumSize = new Size(sudoku.MinimumSize.Width, sudoku.MinimumSize.Height + toolStrip1.Height);
        }

        private void Assign(SudokuBoard board, string name)
        {
            sudoku.Assign(board);
            Text = $"Sudoku - {name}";
            showCandidatesButton.Checked = false;
            sudoku.ShowCandidates = false;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Title = "Otevřít soubor",
                Filter = "Soubor TXT|*.txt",
                InitialDirectory = Path.GetFullPath(Directory.GetCurrentDirectory())
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SudokuBoard board;
                try
                {
                    board = SudokuBoard.Load(dialog.FileName);
                }
                catch (InvalidDataException)
                {
                    MessageBox.Show("Nesprávný obsah souboru.");
                    return;
                }
                catch
                {
                    MessageBox.Show("Chyba při načítání souboru.");
                    return;
                }
                board.RefreshCandidates();
                Assign(board, Path.GetFileNameWithoutExtension(dialog.FileName));
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                Title = "Uložit soubor",
                Filter = "Soubor TXT|*.txt",
                InitialDirectory = Path.GetFullPath(Directory.GetCurrentDirectory())
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sudoku.Board.Save(dialog.FileName);
                MessageBox.Show("Sudoku uloženo.", Text);
            }
        }

        private void showCandidatesButton_Click(object sender, EventArgs e) =>
            sudoku.ShowCandidates = showCandidatesButton.Checked = !showCandidatesButton.Checked;

        private void lehkáObtížnostToolStripMenuItem_Click(object sender, EventArgs e) =>
            Assign(SudokuBoard.Random(GameDifficulty.Easy), "Nový lehký");

        private void prázdnéToolStripMenuItem_Click(object sender, EventArgs e) =>
            Assign(SudokuBoard.Blank, "Nový");

        private void středníObtížnostToolStripMenuItem_Click(object sender, EventArgs e) =>
            Assign(SudokuBoard.Random(GameDifficulty.Medium), "Nový střední");

        private void těžkáObtížnostToolStripMenuItem_Click(object sender, EventArgs e) =>
            Assign(SudokuBoard.Random(GameDifficulty.Hard), "Nový těžký");

        private void solveButton_Click(object sender, EventArgs e)
        {
            ISolver solver = Solver.Solver.DefaultSolver;
            bool result = solver.SetBoard(sudoku.Board).Solve();
            sudoku.Invalidate();
            MessageBox.Show($"Řešení se {(result ? "" : "ne")}podařilo najít.", Text, MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation);
        }

        private void newButton_ButtonClick(object sender, EventArgs e) =>
            prázdnéToolStripMenuItem_Click(sender, e);

        private void sudoku_SolutionFound(object sender, EventArgs e) =>
            MessageBox.Show("Gratulujeme, řešení bylo nalezeno.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
