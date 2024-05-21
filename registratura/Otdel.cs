using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace registratura
{
    public partial class Otdel : Form
    {
        public Otdel()
        {
            InitializeComponent();
        }
        public static int n = 0;

        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Отделения"].Rows[n]["id_otd"].ToString();
            textBox2.Text = Form1.ds.Tables["Отделения"].Rows[n]["nazv"].ToString();
            textBox3.Text = Form1.ds.Tables["Отделения"].Rows[n]["zav"].ToString();
        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();

        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {

            string sql = "SELECT otd.id_otd AS \"Код отделения\", otd.nazv" +
                " AS \"Название\", otd.zav AS \"Заведующий отделения\"" +
                " FROM otd LEFT JOIN vrach on vrach.id_otd = otd.id_otd ORDER BY \"Код отделения\"";


            Form1.TableFill("Отделения", sql);
            Form1.ds.Tables["Отделения"].DefaultView.Sort = "Название";
            dataGridView1.DataSource = Form1.ds.Tables["Отделения"].DefaultView;
            dataGridView1.Columns["id_otd"].Visible = false;
            dataGridView1.Columns["nazv"].Visible = false;
            dataGridView1.Columns["zav"].Visible = false;
            dataGridView1.Columns["Код отделения"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Enabled = false;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
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
            if (n < Form1.ds.Tables["Отделения"].Rows.Count) n++;
            if (Form1.ds.Tables["Отделения"].Rows.Count > n)
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
            n = Form1.ds.Tables["Отделения"].Rows.Count + 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {

            if (Form1.ds.Tables["Отделения"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
        }
    }
}
