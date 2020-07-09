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

namespace sqlite_gui
{
    public partial class frmMain : Form
    {
        private SQLiteConnection conn = null;
        private SQLiteDataAdapter adapter = null;
        private DataSet dataset = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void setGrid(string tableName) {
            adapter = new SQLiteDataAdapter("select * from " + tableName + " where 1=1;", conn);
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            dataset = new DataSet();
            adapter.Fill(dataset);

            //generate commands using command builder
            try
            {
                var uc = builder.GetUpdateCommand().CommandText;
                var ic = builder.GetInsertCommand().CommandText;
                var dc = builder.GetDeleteCommand().CommandText;

                //MessageBox.Show("auto generated update command: " + uc);
                //MessageBox.Show("auto generated insert command: " + ic);
                //MessageBox.Show("auto generated delete command: " + dc);
                dgvMain.ReadOnly = false;
            }
            catch {
                MessageBox.Show("Tables without primary key cannot be edited/deleted");
                dgvMain.ReadOnly = true;
            }

            this.dgvMain.AutoGenerateColumns = true;
            this.dgvMain.DataSource = dataset;
            this.dgvMain.DataMember = dataset.Tables[0].TableName; //tableName;
        }

        private void openConn(string filename) {
            string connstr = @"Data Source=" + filename + @";Version=3;New=True;Compress=True";
            conn = new SQLiteConnection(connstr);
            SQLiteDataAdapter da = new SQLiteDataAdapter("", conn);
            DataSet ds = new DataSet();
            da.SelectCommand.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1;";
            da.Fill(ds);

            ArrayList al = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows) {
                //MessageBox.Show("TABLE: " + row[0]);
                al.Add(row[0]);
            }
            frmChooseTable chooseTable = new frmChooseTable(al);
            chooseTable.ShowDialog();
            if (chooseTable.tableName != "") {
                //MessageBox.Show(chooseTable.tableName + " chosen");
                setGrid(chooseTable.tableName);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello, World!");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQLITE Database Files|*.sqlite3;*.db;";
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
            adapter.Update(dataset);
        }
    }
}
