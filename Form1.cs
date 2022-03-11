using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Bilet_Satış
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int count = 0;
        private static void DisabledCheckBox(ref Panel pnl)
        {
            foreach (CheckBox item in pnl.Controls)
            {
                if (count == 0)
                    item.Enabled = false;
                else
                    item.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Fast And Furious 10");
            comboBox1.Items.Add("Matrix 4 ");
            comboBox1.Items.Add("Uncharted");
            comboBox1.Items.Add("Moonfall");
            comboBox1.Items.Add("Melih Gökhanı G*tten sikiyor 1080p");

            comboBox2.Items.Add("13.00");
            comboBox2.Items.Add("15.00");
            comboBox2.Items.Add("17.10");
            comboBox2.Items.Add("19.45");
            comboBox2.Items.Add("21.30");

            label4.Text = count.ToString();

            DisabledCheckBox(ref panel2);
        }

        private static void chairControl(ref Panel panelkoltuk, ref Label lbl, ref NumericUpDown nUp, ref NumericUpDown nUp2)
        {
            int temp = 0;
            foreach (CheckBox item in panelkoltuk.Controls)
            {

                DisabledCheckBox(ref panelkoltuk);


                if (item.Checked && temp == 0)
                {
                    temp++;
                    count--;
                    lbl.Text = count.ToString();
                }

                

            }
        }

        private void CumericUpchecked(object sender, EventArgs e)
        {
            chairControl(ref panel2, ref label4, ref numericUpDown1, ref numericUpDown2);
            count = Convert.ToInt32(numericUpDown2.Value) + Convert.ToInt32(numericUpDown1.Value);
            label4.Text = (numericUpDown1.Value + numericUpDown2.Value).ToString();
            DisabledCheckBox(ref panel2);
            if (count >= 55)
            {

                MessageBox.Show("The maximum capacity of the hall is 54.");
            }
        }

        private void fullCheckedChange(object sender, EventArgs e)
        {
            chairControl(ref panel2, ref label4, ref numericUpDown1, ref numericUpDown2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (CheckBox item in panel2.Controls)
            {
                if (item.Checked)
                {
                    item.BackColor = Color.Red;
                    item.Enabled = false;
                }
            }
        }
    }
}
