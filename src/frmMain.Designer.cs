﻿namespace sqlite_gui
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._sql = new System.Windows.Forms.TabPage();
            this.btnRunSQL = new System.Windows.Forms.Button();
            this.dgvSQL = new System.Windows.Forms.DataGridView();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this._sql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQL)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 15);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(59, 26);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(80, 20);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(39, 15);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Ready";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(827, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this._sql);
            this.tabControl1.Location = new System.Drawing.Point(15, 49);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(848, 421);
            this.tabControl1.TabIndex = 0;
            // 
            // _sql
            // 
            this._sql.Controls.Add(this.label1);
            this._sql.Controls.Add(this.btnRunSQL);
            this._sql.Controls.Add(this.dgvSQL);
            this._sql.Controls.Add(this.txtSQL);
            this._sql.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sql.Location = new System.Drawing.Point(4, 24);
            this._sql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._sql.Name = "_sql";
            this._sql.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._sql.Size = new System.Drawing.Size(840, 393);
            this._sql.TabIndex = 0;
            this._sql.Text = "SQL";
            this._sql.UseVisualStyleBackColor = true;
            // 
            // btnRunSQL
            // 
            this.btnRunSQL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSQL.Location = new System.Drawing.Point(3, 187);
            this.btnRunSQL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRunSQL.Name = "btnRunSQL";
            this.btnRunSQL.Size = new System.Drawing.Size(70, 30);
            this.btnRunSQL.TabIndex = 2;
            this.btnRunSQL.Text = "&Run";
            this.btnRunSQL.UseVisualStyleBackColor = true;
            this.btnRunSQL.Click += new System.EventHandler(this.btnRunSQL_Click);
            // 
            // dgvSQL
            // 
            this.dgvSQL.AllowUserToAddRows = false;
            this.dgvSQL.AllowUserToDeleteRows = false;
            this.dgvSQL.AllowUserToOrderColumns = true;
            this.dgvSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSQL.Location = new System.Drawing.Point(3, 221);
            this.dgvSQL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSQL.Name = "dgvSQL";
            this.dgvSQL.ReadOnly = true;
            this.dgvSQL.Size = new System.Drawing.Size(832, 165);
            this.dgvSQL.TabIndex = 1;
            this.dgvSQL.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSQL_CellMouseDoubleClick);
            this.dgvSQL.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSQL_RowsAdded);
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQL.Location = new System.Drawing.Point(3, 4);
            this.txtSQL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(834, 175);
            this.txtSQL.TabIndex = 0;
            this.txtSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQL_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete,
            this.mnuView});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 48);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Visible = false;
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuView
            // 
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(152, 22);
            this.mnuView.Text = "View Details";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "(Press Run button or \'Alt + R\' Keys to Run Query)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnBrowse);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sqlite-gui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this._sql.ResumeLayout(false);
            this._sql.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQL)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.TabPage _sql;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.DataGridView dgvSQL;
        private System.Windows.Forms.Button btnRunSQL;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.Label label1;
    }
}

