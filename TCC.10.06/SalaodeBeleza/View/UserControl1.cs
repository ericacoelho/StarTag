using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalaodeBeleza.View
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("08:00");
            dataGridView1.Rows.Add("08:30");
            dataGridView1.Rows.Add("09:00");
            dataGridView1.Rows.Add("09:30");
            dataGridView1.Rows.Add("10:00");
        }
    }
}
