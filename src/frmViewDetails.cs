using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sqlite_gui
{
    public partial class frmViewDetails : Form
    {
        DataGridViewRow theRow = null;

        public frmViewDetails(DataGridViewRow row)
        {
            this.theRow = row;

            InitializeComponent();
        }

        private void frmViewDetails_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
            for (int i = 0; i < theRow.DataGridView.Columns.Count; i++)
            {
                var index = this.dataGridView1.Rows.Add();
                DataGridViewColumn column = theRow.DataGridView.Columns[i];
                this.dataGridView1.Rows[index].Cells[0].Value = column.HeaderText;
                if (column.CellType == typeof(DataGridViewTextBoxCell))
                {
                    this.dataGridView1.Rows[index].Cells[1].Value = theRow.Cells[i].Value;
                }
                else
                {
                    bool found = false;
                    for (int j = 2; j < this.dataGridView1.Columns.Count; j++) {
                        if (dataGridView1.Columns[j].CellType == column.CellType) {
                            found = true;
                            this.dataGridView1.Rows[index].Cells[j].Value = theRow.Cells[i].Value;
                        }
                    }
                    if (!found) {
                        int pos = dataGridView1.Columns.Add(new DataGridViewColumn(theRow.Cells[i]));
                        this.dataGridView1.Rows[index].Cells[pos].Value = theRow.Cells[i].Value;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
