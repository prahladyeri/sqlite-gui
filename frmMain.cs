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

        public frmMain()
        {
            InitializeComponent();
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
                MessageBox.Show(chooseTable.tableName + " chosen");
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
                //MessageBox.Show(fn);
                openConn(filename);
            }
        }
    }
}
