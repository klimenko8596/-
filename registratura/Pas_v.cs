using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registratura
{
    public partial class Pas_v : Form
    {
        public Pas_v()
        {
            InitializeComponent();
        }
        public static int n = 0;
        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Пациенты"].Rows[n]["id_pac"].ToString();
            textBox2.Text = Form1.ds.Tables["Пациенты"].Rows[n]["fam"].ToString();
            textBox3.Text = Form1.ds.Tables["Пациенты"].Rows[n]["pol"].ToString();
            if (Form1.ds.Tables["Пациенты"].Rows[n]["dat_r"] != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Пациенты"].Rows[n]["dat_r"]);
            textBox4.Text = Form1.ds.Tables["Пациенты"].Rows[n]["polic"].ToString();
            textBox5.Text = Form1.ds.Tables["Пациенты"].Rows[n]["obl"].ToString();
            textBox6.Text = Form1.ds.Tables["Пациенты"].Rows[n]["nam"].ToString();
            textBox7.Text = Form1.ds.Tables["Пациенты"].Rows[n]["snils"].ToString();
            textBox8.Text = Form1.ds.Tables["Пациенты"].Rows[n]["ser_nom"].ToString();
            textBox9.Text = Form1.ds.Tables["Пациенты"].Rows[n]["otch"].ToString();
            textBox10.Text = Form1.ds.Tables["Пациенты"].Rows[n]["reg"].ToString();
            textBox11.Text = Form1.ds.Tables["Пациенты"].Rows[n]["gorod"].ToString();
            textBox12.Text = Form1.ds.Tables["Пациенты"].Rows[n]["yl"].ToString();
            textBox13.Text = Form1.ds.Tables["Пациенты"].Rows[n]["dom"].ToString();
            textBox14.Text = Form1.ds.Tables["Пациенты"].Rows[n]["kvar"].ToString();
            textBox1.Enabled = false;
        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.ResetText();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox1.Focus();
            textBox1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = 0;
            FieldsForm_Fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--;
                FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < Form1.ds.Tables["Пациенты"].Rows.Count) n++;
            if (Form1.ds.Tables["Пациенты"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FieldsForm_Clear();
            n = Form1.ds.Tables["Пациенты"].Rows.Count + 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (Form1.ds.Tables["Пациенты"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
            poick_p poick = new poick_p();
            this.Size = new Size(872, 470);

            if (Form1.tabControl1.TabCount > 2)
            {
                Form1.tabControl1.TabPages.RemoveAt(Form1.tabControl1.TabCount - 1);
            }
            Form1.tabControl1.Controls.Add(poick.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }
    }
}
