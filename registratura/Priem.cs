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
    public partial class Priem : Form
    {
        public Priem()
        {
            InitializeComponent();
        }
        public static int n = 0;
        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["id_med"].ToString();
            comboBox1.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["id_pac"].ToString();
            comboBox2.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["id_vrach"].ToString();
            if (Form1.ds.Tables["Мед. карта"].Rows[n]["dat_pr"] != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Мед. карта"].Rows[n]["dat_pr"]);
            textBox4.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["simp"].ToString();
            textBox5.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["diag"].ToString();
            textBox6.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["lekar"].ToString();
            textBox7.Text = Form1.ds.Tables["Мед. карта"].Rows[n]["comment"].ToString();
            textBox1.Enabled = false;
        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.ResetText();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Focus(); textBox1.Enabled = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            comboBox2.DataSource = Form1.ds.Tables["Врачи"].DefaultView;
            comboBox2.DisplayMember = "fio";

            comboBox1.DataSource = Form1.ds.Tables["Пациенты"].DefaultView;
            comboBox1.DisplayMember = "fio";


            if (Form1.ds.Tables["Мед. карта"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
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
            if (n < Form1.ds.Tables["Мед. карта"].Rows.Count) n++;
            if (Form1.ds.Tables["Мед. карта"].Rows.Count > n)
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
            n = Form1.ds.Tables["Мед. карта"].Rows.Count + 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string kod2 = Form1.ds.Tables["Врачи"].DefaultView[comboBox2.SelectedIndex]["id_vrach"].ToString();
            string kod = Form1.ds.Tables["Пациенты"].DefaultView[comboBox1.SelectedIndex]["id_pac"].ToString();
            string sql;
            if (n < Form1.ds.Tables["Мед. карта"].Rows.Count)
            {
                sql = "update med set id_pac=" + kod + ", id_vrach=" + kod2 + ", dat_pr='" + dateTimePicker1.Value +
                   "', simp='" + textBox4.Text
                    + "', diag='" + textBox5.Text + "', lekar='" + textBox6.Text +
                    "', comment='" + textBox7.Text
                    + "' where id_med=" + textBox1.Text;
                if (!Form1.ModificationExecute(sql))
                {
                    return;
                }

                Form1.ds.Tables["Мед. карта"].Rows[n].ItemArray = new object[] { textBox1.Text,  comboBox1.Text,
                 comboBox2.Text, dateTimePicker1.Value, textBox4.Text,
                     textBox5.Text, textBox6.Text,
                textBox7.Text};
            }

            else
            {
                sql = "insert into med(id_med, id_pac, id_vrach, dat_pr, simp, diag, lekar, comment) values(" + textBox1.Text + "," + kod + ","
                + kod2 + ",'" + dateTimePicker1.Value + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";

                if (!Form1.ModificationExecute(sql))
                { return; }

                Form1.ds.Tables["Мед. карта"].Rows.Add(new object[] { textBox1.Text,  comboBox1.Text,
                 comboBox2.Text, dateTimePicker1.Value, textBox4.Text,
                     textBox5.Text, textBox6.Text,
                textBox7.Text});
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника карту с кодом " + textBox1.Text + "?";
            string caption = "Удаление карты";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            

            string sql = "delete from med where id_med=" + textBox1.Text;
            Form1.ModificationExecute(sql);

            Form1.ds.Tables["Мед. карта"].Rows.RemoveAt(n);

            if (Form1.ds.Tables["Мед. карта"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }
    }
}
