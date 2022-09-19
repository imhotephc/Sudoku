namespace Sudoku.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.sudoku = new Sudoku.UI.SudokuGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripSplitButton();
            this.prázdnéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lehkáObtížnostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.středníObtížnostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.těžkáObtížnostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.solveButton = new System.Windows.Forms.ToolStripButton();
            this.showCandidatesButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.sudoku);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(569, 452);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(569, 523);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // sudoku
            // 
            this.sudoku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sudoku.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sudoku.Location = new System.Drawing.Point(0, 0);
            this.sudoku.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.sudoku.Name = "sudoku";
            this.sudoku.ShowCandidates = false;
            this.sudoku.Size = new System.Drawing.Size(569, 452);
            this.sudoku.TabIndex = 1;
            this.sudoku.SolutionFound += new System.EventHandler<System.EventArgs>(this.sudoku_SolutionFound);
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            this.toolStripSeparator1,
            this.solveButton,
            this.showCandidatesButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(370, 71);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prázdnéToolStripMenuItem,
            this.lehkáObtížnostToolStripMenuItem,
            this.středníObtížnostToolStripMenuItem,
            this.těžkáObtížnostToolStripMenuItem});
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 68);
            this.newButton.Text = "Nové Sudoku";
            this.newButton.ButtonClick += new System.EventHandler(this.newButton_ButtonClick);
            // 
            // prázdnéToolStripMenuItem
            // 
            this.prázdnéToolStripMenuItem.Name = "prázdnéToolStripMenuItem";
            this.prázdnéToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.prázdnéToolStripMenuItem.Text = "Prázdné";
            this.prázdnéToolStripMenuItem.Click += new System.EventHandler(this.prázdnéToolStripMenuItem_Click);
            // 
            // lehkáObtížnostToolStripMenuItem
            // 
            this.lehkáObtížnostToolStripMenuItem.Name = "lehkáObtížnostToolStripMenuItem";
            this.lehkáObtížnostToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.lehkáObtížnostToolStripMenuItem.Text = "Lehká obtížnost";
            this.lehkáObtížnostToolStripMenuItem.Click += new System.EventHandler(this.lehkáObtížnostToolStripMenuItem_Click);
            // 
            // středníObtížnostToolStripMenuItem
            // 
            this.středníObtížnostToolStripMenuItem.Name = "středníObtížnostToolStripMenuItem";
            this.středníObtížnostToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.středníObtížnostToolStripMenuItem.Text = "Střední obtížnost";
            this.středníObtížnostToolStripMenuItem.Click += new System.EventHandler(this.středníObtížnostToolStripMenuItem_Click);
            // 
            // těžkáObtížnostToolStripMenuItem
            // 
            this.těžkáObtížnostToolStripMenuItem.Name = "těžkáObtížnostToolStripMenuItem";
            this.těžkáObtížnostToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.těžkáObtížnostToolStripMenuItem.Text = "Těžká obtížnost";
            this.těžkáObtížnostToolStripMenuItem.Click += new System.EventHandler(this.těžkáObtížnostToolStripMenuItem_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(68, 68);
            this.openButton.Text = "Otevřít";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(68, 68);
            this.saveButton.Text = "Uložit";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // solveButton
            // 
            this.solveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solveButton.Image = ((System.Drawing.Image)(resources.GetObject("solveButton.Image")));
            this.solveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(68, 68);
            this.solveButton.Text = "Vyřešit";
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // showCandidatesButton
            // 
            this.showCandidatesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showCandidatesButton.Image = ((System.Drawing.Image)(resources.GetObject("showCandidatesButton.Image")));
            this.showCandidatesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showCandidatesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showCandidatesButton.Name = "showCandidatesButton";
            this.showCandidatesButton.Size = new System.Drawing.Size(68, 68);
            this.showCandidatesButton.Text = "Zobrazit možnosti";
            this.showCandidatesButton.Click += new System.EventHandler(this.showCandidatesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 523);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(450, 515);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private UI.SudokuGrid sudoku;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton showCandidatesButton;
        private System.Windows.Forms.ToolStripSplitButton newButton;
        private System.Windows.Forms.ToolStripMenuItem lehkáObtížnostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem středníObtížnostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem těžkáObtížnostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prázdnéToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton solveButton;
    }
}
