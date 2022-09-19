using Sudoku.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku.UI
{
    public partial class SudokuGrid : UserControl
    {
        public SudokuBoard Board { get; private set; }
        public bool ShowCandidates
        {
            get => showCandidates;
            set
            {
                showCandidates = value;
                ReDraw();
            }
        }

        public event EventHandler<EventArgs> SolutionFound;

        private Cell selectedCell = null;
        private Color _CustomValueColor = Color.Crimson;
        private bool showCandidates;

        public SudokuGrid()
        {
            InitializeComponent();
            ShowCandidates = false;
        }

        public void Assign(SudokuBoard board)
        {
            Board = board;
            ReDraw();
        }

        private void SudokuGrid_Paint(object sender, PaintEventArgs e)
        {
            Font font = base.Font;
            Font fontMini = new Font(font.FontFamily, font.Size / 2f);

            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

            //boxy
            float width = Width / 3f;
            float height = Height / 3f;
            bool b = true;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var rectangle = new Rectangle((int)(width * x + 1), (int)(height * y + 1), (int)(width - 2), (int)(height - 2));
                    e.Graphics.FillRectangle((b = !b) ? Brushes.AliceBlue : Brushes.GhostWhite, rectangle);
                    e.Graphics.DrawRectangle(Pens.Black, rectangle);
                }
            }

            //pole
            width = Width / 9f;
            height = Height / 9f;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, width * x, height * y, width, height);
                    if (Board == null)
                        continue;
                    int value = Board[y, x].Value;
                    var rect = new Rectangle((int)(width * x), (int)(height * y), (int)width, (int)height);
                    if (selectedCell != null && selectedCell.Position.Row == y && selectedCell.Position.Column == x)
                    {
                        TextRenderer.DrawText(e.Graphics,
                            "_", font, rect,
                            Color.Crimson, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    if (value != 0)
                    {
                        TextRenderer.DrawText(e.Graphics,
                            value.ToString(), font, rect,
                            value == Board[y, x].OriginalValue ? Color.Black : _CustomValueColor,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    else if (ShowCandidates)
                    {
                        foreach (int c in Board[y, x].Candidates)
                        {
                            e.Graphics.DrawString(c.ToString(), fontMini, Brushes.Crimson,
                                (width * x) + fontMini.Size / 4 + (((c - 1) % 3) * (width / 3)),
                                (height * y) + (((c - 1) / 3) * (height / 3)));
                        }
                    }
                }
            }
        }

        private void SudokuGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (selectedCell == null)
                return;
            if (e != null &&
                ((e.KeyChar == '0' && selectedCell.Value != 0) ||
                 (e.KeyChar > '0' && e.KeyChar <= '9')))
            {
                selectedCell.Set(e.KeyChar - '0', true);
                ReDraw();
                if (Board.IsFullyFilled() && Board.IsValid())
                    OnSolutionFound();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                selectedCell = selectedCell == null ? Board[1, 1] : Board[selectedCell.Position.Row < 8 ? selectedCell.Position.Row + 1 : selectedCell.Position.Row, selectedCell.Position.Column];
                ReDraw();
                return true;
            }
            if (keyData == Keys.Left)
            {
                selectedCell = selectedCell == null ? Board[1, 1] : Board[selectedCell.Position.Row, selectedCell.Position.Column > 0 ? selectedCell.Position.Column - 1 : selectedCell.Position.Column];
                ReDraw();
                return true;
            }
            if (keyData == Keys.Up)
            {
                selectedCell = selectedCell == null ? Board[1, 1] : Board[selectedCell.Position.Row > 0 ? selectedCell.Position.Row - 1 : selectedCell.Position.Row, selectedCell.Position.Column];
                ReDraw();
                return true;
            }
            if (keyData == Keys.Right)
            {
                selectedCell = selectedCell == null ? Board[1, 1] : Board[selectedCell.Position.Row, selectedCell.Position.Column < 8 ? selectedCell.Position.Column + 1 : selectedCell.Position.Column];
                ReDraw();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SudokuGrid_Resize(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void ReDraw()
        {
            Invalidate();
        }

        private Cell GetCellFromMouseLocation(Point point)
        {
            return Board == null ? null : Board[point.Y / (Height / 9), point.X / (Width / 9)];
        }

        private void SudokuGrid_MouseClick(object sender, MouseEventArgs e)
        {
            selectedCell = GetCellFromMouseLocation(e.Location);
            ReDraw();
        }

        protected void OnSolutionFound()
        {
            SolutionFound?.Invoke(this, EventArgs.Empty);
        }
    }
}
