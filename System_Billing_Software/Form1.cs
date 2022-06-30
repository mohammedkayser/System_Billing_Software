using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Billing_Software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Found = false;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) == CmbProduct.Text && Convert.ToString(row.Cells[1].Value) == TxtPrice.Text)
                    {
                        row.Cells[2].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[2].Value));
                        Found = true;
                    }
                }
                if (!Found)
                {
                    dataGridView1.Rows.Add(CmbProduct.Text, TxtPrice.Text, 1);
                }

            }
            else
            {
                dataGridView1.Rows.Add(CmbProduct.Text, TxtPrice.Text, 1);
            }

            //amount = price * qty

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[dataGridView1.Columns["amount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["qty"].Index].Value));

            }

            //Total Qty
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox1.Text = sum.ToString();
            //total amount
            int sum1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox2.Text = sum.ToString();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
