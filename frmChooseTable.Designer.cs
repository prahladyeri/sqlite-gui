namespace sqlite_gui
{
    partial class frmChooseTable
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(60, 195);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstTables
            // 
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(-1, 3);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(187, 186);
            this.lstTables.TabIndex = 1;
            // 
            // frmChooseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 224);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.Name = "frmChooseTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChooseTable";
            this.Load += new System.EventHandler(this.frmChooseTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lstTables;
    }
}