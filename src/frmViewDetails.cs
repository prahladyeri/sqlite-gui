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
