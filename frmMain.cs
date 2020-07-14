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
            tabControl1.TabPages.Clear();
            foreach (DataRow row in dsAllTables.Tables[0].Rows) { 
                string tableName = row[0].ToString();
                tabControl1.TabPages.Add(tableName, tableName);
                DataGridView dgv = new DataGridView();
                dgv.Name = "dgv";
                dgv.ContextMenuStrip = this.contextMenuStrip1;
                dgv.Dock = DockStyle.Fill;
                
                //dgv.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
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

            //ArrayList al = new ArrayList();
            //foreach (DataRow row in dsAllTables.Tables[0].Rows) {
            //    //MessageBox.Show("TABLE: " + row[0]);
            //    al.Add(row[0]);
            //}
            //frmChooseTable chooseTable = new frmChooseTable(al);
            //chooseTable.ShowDialog();
            //if (chooseTable.tableName != "") {
                //MessageBox.Show(chooseTable.tableName + " chosen");
                //setGrid(chooseTable.tableName);
            //}
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQLITE Database Files|*.db;*.sqlite3;*.sqlite";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) {
                var filename = ofd.FileName;
                lblPath.Text = filename;
                //MessageBox.Show(fn);
                openConn(filename);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) {
                MessageBox.Show("No selected data tab.");
                return;
            }
            string currentTab = tabControl1.SelectedTab.Name;
            //MessageBox.Show("current tab: " + currentTab);
            adapters[currentTab].Update(datasets[currentTab]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (tabControl1.SelectedTab == null) return;
            string currentTab = tabControl1.SelectedTab.Name;
            DataTable changes = datasets[currentTab].Tables[0].GetChanges();
            if (changes != null && changes.Rows.Count > 0) {
                DialogResult result= MessageBox.Show("You have pending changes. Are you sure you want to exit sqlite-qui?", null, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }
    }
}
