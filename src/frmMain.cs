#region License Information (Apache 2.0)
/*
   Copyright 2023 Prahlad Yeri

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;
using System.Collections.Generic;

namespace sqlite_gui
{
    public partial class frmMain : Form
    {
        private SQLiteConnection conn = null;
        private DataSet dsAllTables = null;
        private Dictionary<string, SQLiteDataAdapter> adapters = new System.Collections.Generic.Dictionary<string, SQLiteDataAdapter>();
        private Dictionary<string, DataSet> datasets = new System.Collections.Generic.Dictionary<string, DataSet>();

        public frmMain()
        {
            InitializeComponent();
        }


        private void setGridAll() {
            //clear sql tab
            //dgvSQL.Rows.Clear();
            //dgvSQL.Refresh();
            txtSQL.Text = "";
            dgvSQL.DataSource = null;
            dgvSQL.DataMember = null;
            dgvSQL.Refresh();
            //clear tabs
            while (tabControl1.TabPages.Count > 1) tabControl1.TabPages.RemoveAt(1); 
            //addSQLTab();
            foreach (DataRow row in dsAllTables.Tables[0].Rows) { 
                string tableName = row[0].ToString();
                if (tableName.StartsWith("sqlite_")) continue;
                tabControl1.TabPages.Add(tableName, tableName);
                DataGridView dgv = new DataGridView();
                dgv.Name = "dgv";
                dgv.ContextMenuStrip = this.contextMenuStrip1;
                dgv.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvSQL_CellMouseDoubleClick);
                dgv.Dock = DockStyle.Fill;
                tabControl1.TabPages[tableName].Controls.Add(dgv);
                //
                SQLiteCommandBuilder builder;
                try
                {
                    adapters[tableName] = new SQLiteDataAdapter("select * from `" + tableName + "` where 1=1;", conn);
                    builder = new SQLiteCommandBuilder(adapters[tableName]);
                    datasets[tableName] = new DataSet();
                    adapters[tableName].Fill(datasets[tableName]);
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                    continue;
                }
                //generate commands using command builder
                try
                {
                    var uc = builder.GetUpdateCommand().CommandText;
                    var ic = builder.GetInsertCommand().CommandText;
                    var dc = builder.GetDeleteCommand().CommandText;

                    //MessageBox.Show("auto generated update command: " + uc);
                    //MessageBox.Show("auto generated insert command: " + ic);
                    //MessageBox.Show("auto generated delete command: " + dc);
                    dgv.ReadOnly = false;
                }
                catch
                {
                    MessageBox.Show(tableName + ": tables without primary key cannot be edited/deleted");
                    dgv.ReadOnly = true;
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToDeleteRows = false;
                }

                dgv.AutoGenerateColumns = true;
                dgv.DataSource = datasets[tableName];
                dgv.DataMember = datasets[tableName].Tables[0].TableName; //tableName;

            }
        }


        private void openConn(string filename) {
            string connstr = @"Data Source=" + filename + @";Version=3;New=True;Compress=True";
            conn = new SQLiteConnection(connstr);
            SQLiteDataAdapter da = new SQLiteDataAdapter("", conn);
            dsAllTables = new DataSet();
            da.SelectCommand.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1;";
            da.Fill(dsAllTables);
            setGridAll();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello, World!");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductMajorPart + "." +  fvi.ProductMinorPart;
            this.Text += " " + version;
            new ToolTip().SetToolTip(this.btnSave, "Commit Changes");
        }

        private bool havePendingChanges() {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Name == "_sql") continue;
                DataTable changes = datasets[tab.Name].Tables[0].GetChanges();
                if (changes != null && changes.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (havePendingChanges())
            {
                MessageBox.Show("You have pending changes, commit them before opening a new database.");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.db,*.sqlite,*.sqlite3)|*.db;*.sqlite3;*.sqlite";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) {
                var filename = ofd.FileName;
                lblPath.Text = filename;
                //MessageBox.Show(fn);
                openConn(filename);
                txtSQL.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!havePendingChanges()) {
                MessageBox.Show("No changes to save.");
                return;
            }
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Name == "_sql") continue;
                DataTable changes = datasets[tab.Name].Tables[0].GetChanges();
                if (changes != null && changes.Rows.Count > 0)
                {
                    try
                    {
                        adapters[tab.Name].Update(datasets[tab.Name]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception occurred: " + ex.ToString());
                    }

                    
                }
            }
            MessageBox.Show("Data Saved");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)tabControl1.SelectedTab.Controls["dgv"];
            if (dgv.SelectedRows.Count == 0) {
                MessageBox.Show("No rows selected.");
                return;
            }
            foreach (DataGridViewRow row in dgv.SelectedRows) {
                dgv.Rows.RemoveAt(row.Index);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (havePendingChanges()) {
                DialogResult result = MessageBox.Show("You have pending changes. Are you sure you want to exit sqlite-qui?", null, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        private void btnRunSQL_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(txtSQL.Text, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvSQL.AutoGenerateColumns = true;
                dgvSQL.DataSource = ds;
                dgvSQL.DataMember = ds.Tables[0].TableName; //tableName;
            }
            catch (Exception ex) {
                MessageBox.Show("Error occurred" + ex.Message,"", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) txtSQL.SelectAll();
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            DataGridView dgv;
            if (tabControl1.SelectedTab.Name == "_sql")
            {
                dgv = dgvSQL;
            }
            else
            {
                dgv = (DataGridView)tabControl1.SelectedTab.Controls["dgv"];
            }
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("No rows selected.");
                return;
            }
            DataGridViewRow row = dgv.CurrentRow; //#dgv.SelectedRows[0];
            //
            frmViewDetails view = new frmViewDetails(row);
            view.ShowDialog();
        }

        private void dgvSQL_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == -1)
            {
                mnuView_Click(null, null);
            }
        }

        private void dgvSQL_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Button btn = new Button();
            //btn attributes
            //dgvSQL.Rows[e.RowIndex].Cells[0].Value = new Button();
            //System.Diagnostics.Debug.Print("row_added::" + e.RowIndex.ToString() + "::" + e.RowCount.ToString());
        }
    }
}
