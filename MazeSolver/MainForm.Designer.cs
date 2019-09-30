namespace WinFormTest
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panToolbox = new System.Windows.Forms.Panel();
            this.butClear = new System.Windows.Forms.Button();
            this.butLoad = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butGo = new System.Windows.Forms.Button();
            this.radFinish = new System.Windows.Forms.RadioButton();
            this.radStart = new System.Windows.Forms.RadioButton();
            this.radWall = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.panView = new System.Windows.Forms.Panel();
            this.panGrid = new System.Windows.Forms.Panel();
            this.hsView = new System.Windows.Forms.HScrollBar();
            this.vsView = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panToolbox.SuspendLayout();
            this.panView.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panToolbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panView);
            this.splitContainer1.Panel2.Controls.Add(this.hsView);
            this.splitContainer1.Panel2.Controls.Add(this.vsView);
            this.splitContainer1.Size = new System.Drawing.Size(759, 408);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 0;
            // 
            // panToolbox
            // 
            this.panToolbox.Controls.Add(this.butClear);
            this.panToolbox.Controls.Add(this.butLoad);
            this.panToolbox.Controls.Add(this.butSave);
            this.panToolbox.Controls.Add(this.butGo);
            this.panToolbox.Controls.Add(this.radFinish);
            this.panToolbox.Controls.Add(this.radStart);
            this.panToolbox.Controls.Add(this.radWall);
            this.panToolbox.Controls.Add(this.label2);
            this.panToolbox.Controls.Add(this.label1);
            this.panToolbox.Controls.Add(this.txtRows);
            this.panToolbox.Controls.Add(this.txtCols);
            this.panToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panToolbox.Location = new System.Drawing.Point(0, 0);
            this.panToolbox.Name = "panToolbox";
            this.panToolbox.Size = new System.Drawing.Size(214, 408);
            this.panToolbox.TabIndex = 0;
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(57, 217);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(104, 23);
            this.butClear.TabIndex = 10;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butLoad
            // 
            this.butLoad.Location = new System.Drawing.Point(57, 295);
            this.butLoad.Name = "butLoad";
            this.butLoad.Size = new System.Drawing.Size(104, 23);
            this.butLoad.TabIndex = 9;
            this.butLoad.Text = "Load";
            this.butLoad.UseVisualStyleBackColor = true;
            this.butLoad.Click += new System.EventHandler(this.butLoad_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(57, 265);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(104, 23);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butGo
            // 
            this.butGo.Location = new System.Drawing.Point(57, 187);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(104, 23);
            this.butGo.TabIndex = 7;
            this.butGo.Text = "Solve";
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // radFinish
            // 
            this.radFinish.Appearance = System.Windows.Forms.Appearance.Button;
            this.radFinish.Location = new System.Drawing.Point(57, 143);
            this.radFinish.Name = "radFinish";
            this.radFinish.Size = new System.Drawing.Size(104, 24);
            this.radFinish.TabIndex = 6;
            this.radFinish.Text = "Place Finish";
            this.radFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radFinish.UseVisualStyleBackColor = true;
            // 
            // radStart
            // 
            this.radStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.radStart.Location = new System.Drawing.Point(57, 114);
            this.radStart.Name = "radStart";
            this.radStart.Size = new System.Drawing.Size(104, 24);
            this.radStart.TabIndex = 5;
            this.radStart.Text = "Place Start";
            this.radStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radStart.UseVisualStyleBackColor = true;
            // 
            // radWall
            // 
            this.radWall.Appearance = System.Windows.Forms.Appearance.Button;
            this.radWall.Checked = true;
            this.radWall.Location = new System.Drawing.Point(57, 85);
            this.radWall.Name = "radWall";
            this.radWall.Size = new System.Drawing.Size(104, 24);
            this.radWall.TabIndex = 4;
            this.radWall.TabStop = true;
            this.radWall.Text = "Toggle Wall";
            this.radWall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radWall.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columns";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(100, 40);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 20);
            this.txtRows.TabIndex = 1;
            this.txtRows.Text = "10";
            this.txtRows.Enter += new System.EventHandler(this.txtRows_Enter);
            this.txtRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRows_KeyPress);
            this.txtRows.Leave += new System.EventHandler(this.txtRows_Leave);
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(100, 14);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(100, 20);
            this.txtCols.TabIndex = 0;
            this.txtCols.Text = "10";
            this.txtCols.Enter += new System.EventHandler(this.txtCols_Enter);
            this.txtCols.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCols_KeyPress);
            this.txtCols.Leave += new System.EventHandler(this.txtCols_Leave);
            // 
            // panView
            // 
            this.panView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panView.Controls.Add(this.panGrid);
            this.panView.Location = new System.Drawing.Point(3, 3);
            this.panView.Name = "panView";
            this.panView.Size = new System.Drawing.Size(518, 384);
            this.panView.TabIndex = 2;
            // 
            // panGrid
            // 
            this.panGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panGrid.Location = new System.Drawing.Point(3, 3);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(156, 131);
            this.panGrid.TabIndex = 0;
            this.panGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.panGrid_Paint);
            this.panGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panGrid_MouseDown);
            this.panGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panGrid_MouseMove);
            // 
            // hsView
            // 
            this.hsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hsView.Location = new System.Drawing.Point(0, 391);
            this.hsView.Name = "hsView";
            this.hsView.Size = new System.Drawing.Size(523, 17);
            this.hsView.TabIndex = 1;
            this.hsView.Visible = false;
            // 
            // vsView
            // 
            this.vsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vsView.Location = new System.Drawing.Point(524, 0);
            this.vsView.Name = "vsView";
            this.vsView.Size = new System.Drawing.Size(17, 387);
            this.vsView.TabIndex = 0;
            this.vsView.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 408);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Maze Solver";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panToolbox.ResumeLayout(false);
            this.panToolbox.PerformLayout();
            this.panView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panToolbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.Panel panView;
        private System.Windows.Forms.Panel panGrid;
        private System.Windows.Forms.HScrollBar hsView;
        private System.Windows.Forms.VScrollBar vsView;
        private System.Windows.Forms.RadioButton radFinish;
        private System.Windows.Forms.RadioButton radStart;
        private System.Windows.Forms.RadioButton radWall;
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.Button butLoad;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butClear;
    }
}

