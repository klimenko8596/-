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
    public partial class poisk_v_pac : Form
    {
        public poisk_v_pac()
        {
            InitializeComponent();
        }
        public static string n = null;
        public static int i = 0;
        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Пациенты"].Rows[i]["id_pac"].ToString();
            textBox2.Text = Form1.ds.Tables["Пациенты"].Rows[i]["fam"].ToString();
            textBox3.Text = Form1.ds.Tables["Пациенты"].Rows[i]["pol"].ToString();
            if (Form1.ds.Tables["Пациенты"].Rows[i]["dat_r"] != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Пациенты"].Rows[i]["dat_r"]);
            textBox4.Text = Form1.ds.Tables["Пациенты"].Rows[i]["polic"].ToString();
            textBox5.Text = Form1.ds.Tables["Пациенты"].Rows[i]["obl"].ToString();
            textBox6.Text = Form1.ds.Tables["Пациенты"].Rows[i]["nam"].ToString();
            textBox7.Text = Form1.ds.Tables["Пациенты"].Rows[i]["snils"].ToString();
            textBox8.Text = Form1.ds.Tables["Пациенты"].Rows[i]["ser_nom"].ToString();
            textBox9.Text = Form1.ds.Tables["Пациенты"].Rows[i]["otch"].ToString();
            textBox10.Text = Form1.ds.Tables["Пациенты"].Rows[i]["reg"].ToString();
            textBox11.Text = Form1.ds.Tables["Пациенты"].Rows[i]["gorod"].ToString();
            textBox12.Text = Form1.ds.Tables["Пациенты"].Rows[i]["yl"].ToString();
            textBox13.Text = Form1.ds.Tables["Пациенты"].Rows[i]["dom"].ToString();
            textBox14.Text = Form1.ds.Tables["Пациенты"].Rows[i]["kvar"].ToString();
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
            private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            while (Form1.ds.Tables["Пациенты"].Rows[i]["id_pac"].ToString() != n) i++;
            textBox1.Text = Form1.ds.Tables["Пациенты"].Rows[i]["id_pac"].ToString();
            textBox2.Text = Form1.ds.Tables["Пациенты"].Rows[i]["fam"].ToString();
            textBox3.Text = Form1.ds.Tables["Пациенты"].Rows[i]["pol"].ToString();
            if (Form1.ds.Tables["Пациенты"].Rows[i]["dat_r"] != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Пациенты"].Rows[i]["dat_r"]);
            textBox4.Text = Form1.ds.Tables["Пациенты"].Rows[i]["polic"].ToString();
            textBox5.Text = Form1.ds.Tables["Пациенты"].Rows[i]["obl"].ToString();
            textBox6.Text = Form1.ds.Tables["Пациенты"].Rows[i]["nam"].ToString();
            textBox7.Text = Form1.ds.Tables["Пациенты"].Rows[i]["snils"].ToString();
            textBox8.Text = Form1.ds.Tables["Пациенты"].Rows[i]["ser_nom"].ToString();
            textBox9.Text = Form1.ds.Tables["Пациенты"].Rows[i]["otch"].ToString();
            textBox10.Text = Form1.ds.Tables["Пациенты"].Rows[i]["reg"].ToString();
            textBox11.Text = Form1.ds.Tables["Пациенты"].Rows[i]["gorod"].ToString();
            textBox12.Text = Form1.ds.Tables["Пациенты"].Rows[i]["yl"].ToString();
            textBox13.Text = Form1.ds.Tables["Пациенты"].Rows[i]["dom"].ToString();
            textBox14.Text = Form1.ds.Tables["Пациенты"].Rows[i]["kvar"].ToString();
            textBox1.Enabled = false;
        }
    }
}
