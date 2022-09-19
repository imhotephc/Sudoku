namespace Sudoku.UI
{
    partial class SudokuGrid
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SudokuGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "SudokuGrid";
            this.Size = new System.Drawing.Size(450, 450);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SudokuGrid_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SudokuGrid_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SudokuGrid_MouseClick);
            this.Resize += new System.EventHandler(this.SudokuGrid_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
