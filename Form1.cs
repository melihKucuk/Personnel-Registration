using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KayıtListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;
        bool control = false;
        bool control2 = true;
        bool control3 = true;
        int temp;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = "", adsoyad = "", yas = "", mezuniyet = "", cinsiyet = "", dogumyeri = "", telno = "";
            tc = maskedTextBox1.Text;
            adsoyad = textBox2.Text;

            int dogumyili = dateTimePicker1.Value.Year;
            int buyil = DateTime.Now.Year;
            int yasdeger = buyil - dogumyili;
            yas = yasdeger.ToString();

            mezuniyet = comboBox1.Text;
            dogumyeri = textBox3.Text;
            telno = textBox4.Text;

            if (radioButton1.Checked == true)
                cinsiyet = radioButton1.Text;
            else if (radioButton2.Checked == true)
                cinsiyet = radioButton2.Text;

            string[] bilgiler = { tc, adsoyad, yas, mezuniyet, cinsiyet, dogumyeri, telno };
            bool kayitkontrol = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == maskedTextBox1.Text)
                {
                    kayitkontrol = true;
                    MessageBox.Show(maskedTextBox1.Text + " Eklemek İstediğiniz Tc Kimlik Numarası Zaten Mevcut.");
                }
            }
            if (kayitkontrol == false)
            {
                ListViewItem lst = new ListViewItem(bilgiler);
                if (tc != "" && adsoyad != "" && yas != "" && mezuniyet != "" && cinsiyet != "" && dogumyeri != "" && telno != "")
                {
                    listView1.Items.Add(lst);
                }
                else
                    MessageBox.Show("Lütfen Tüm Boşlukları Doldurunuz!!");
            }
            kayitsayisiyazdir();
            
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("TC KİMLİK NO", 150);
            listView1.Columns.Add("ADI SOYADI", 200);
            listView1.Columns.Add("YAŞI", 100);
            listView1.Columns.Add("MEZUNİYETİ", 150);
            listView1.Columns.Add("CİNSİYETİ", 125);
            listView1.Columns.Add("DOĞUM YERİ", 125);
            listView1.Columns.Add("TELEFON NO", 130);
            listView1.GridLines = true;

            string[] mezuniyet = { "İlköğretim", "Ortaöğretim", "Ön Lisans", "Lisans", "Yüksek Lisans", "Doktora" };
            comboBox1.Items.AddRange(mezuniyet);

            kayitsayisiyazdir();

            progressBar1.Step = 100;
            progressBar1.Maximum = 800;

            maskedTextBox1.Mask = "00000000000";
            maskedTextBox1.Focus();
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.SetToolTip(this.textBox2, "selam");


        }

        private void kayitsayisiyazdir()
        {
            int kayitsayisi = listView1.Items.Count;
            label8.Text = Convert.ToString(kayitsayisi);





        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilensayisi = listView1.CheckedItems.Count;
            foreach (ListViewItem secilenkayitbilgisi in listView1.CheckedItems)
            {
                secilenkayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayıt Silindi");
            kayitsayisiyazdir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int secilensayisi = listView1.SelectedItems.Count;
            foreach (ListViewItem secilenkayitbilgisi in listView1.SelectedItems)
            {
                secilenkayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayıt Silindi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            kayitsayisiyazdir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool aranankayitkontrolu = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == maskedTextBox1.Text)
                {
                    aranankayitkontrolu = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[3].Text;
                    if (listView1.Items[i].SubItems[4].Text == "Bay")
                    {
                        radioButton2.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[4].Text == "Bayan")
                    {
                        radioButton1.Checked = true;
                    }

                    textBox3.Text = listView1.Items[i].SubItems[5].Text;
                    textBox4.Text = listView1.Items[i].SubItems[6].Text;
                    textBox2.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    comboBox1.Enabled = false;
                    groupBox1.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                }
            }
            if (aranankayitkontrolu == false)
            {
                MessageBox.Show(maskedTextBox1.Text + " TC Kimlik Numaralı Kayıt Bulunamadı");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            groupBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                progressBar1.Value -= 100;
                control2 = true;
            }
            else if (textBox2.Text != string.Empty && control2)
            {
                progressBar1.Value += 100;
                control2 = false;
            }
            
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text.Length == 11)
            {
                progressBar1.Value += 100;
                control = true;
            }
            else if (maskedTextBox1.Text.Length < 11 && control)
            {
                progressBar1.Value -= 100;
                control = false;
            }
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

