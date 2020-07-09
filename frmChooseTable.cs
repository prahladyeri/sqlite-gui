using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace sqlite_gui
{
    public partial class frmChooseTable : Form
    {
        public String tableName = "";
        private ArrayList al = null;

        public frmChooseTable(ArrayList al)
        {
            this.al = al;
            InitializeComponent();
        }

        private void frmChooseTable_Load(object sender, EventArgs e)
        {
            foreach (String s in al)
            {
                lstTables.Items.Add(s);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.tableName = lstTables.SelectedItem.ToString();
            this.Close();
        }
    }
}
