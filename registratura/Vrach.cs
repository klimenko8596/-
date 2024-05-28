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
    public partial class Vrach : Form
    {
        public Vrach()
        {
            InitializeComponent();
        }
        public static int n = 0;
        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Врачи"].Rows[n]["id_vrach"].ToString();
            textBox4.Text = Form1.ds.Tables["Врачи"].Rows[n]["fam"].ToString();
            textBox6.Text = Form1.ds.Tables["Врачи"].Rows[n]["nam"].ToString();
            textBox9.Text = Form1.ds.Tables["Врачи"].Rows[n]["otch"].ToString();
            if (Form1.ds.Tables["Врачи"].Rows[n]["dat_r"] != DBNull.Value)
                dateTimePicker2.Value = Convert.ToDateTime(Form1.ds.Tables["Врачи"].Rows[n]["dat_r"]);
            comboBox2.Text = Form1.ds.Tables["Врачи"].Rows[n]["id_otd"].ToString();
            textBox3.Text = Form1.ds.Tables["Врачи"].Rows[n]["kab"].ToString();
            comboBox1.Text = Form1.ds.Tables["Врачи"].Rows[n]["id_spec"].ToString();
            textBox2.Text = Form1.ds.Tables["Врачи"].Rows[n]["login"].ToString();
            textBox5.Text = Form1.ds.Tables["Врачи"].Rows[n]["password"].ToString();
            textBox1.Enabled = false;

        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            dateTimePicker2.ResetText();
            comboBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
            textBox1.Enabled = true;

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

       private void tabPage1_Enter(object sender, EventArgs e)
        {
            comboBox2.DataSource = Form1.ds.Tables["Отделения"].DefaultView;
            comboBox2.DisplayMember = "nazv";

            comboBox1.DataSource = Form1.ds.Tables["Специализация"].DefaultView;
            comboBox1.DisplayMember = "nazv";


            if (Form1.ds.Tables["Врачи"].Rows.Count > n)
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
            if (n < Form1.ds.Tables["Врачи"].Rows.Count) n++;
            if (Form1.ds.Tables["Врачи"].Rows.Count > n)
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
            n = Form1.ds.Tables["Врачи"].Rows.Count + 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string kod = Form1.ds.Tables["Отделения"].DefaultView[comboBox2.SelectedIndex]["id_otd"].ToString();
            string kod2 = Form1.ds.Tables["Специализация"].DefaultView[comboBox1.SelectedIndex]["id_spec"].ToString();
            string sql;
            if (n < Form1.ds.Tables["Врачи"].Rows.Count)
            {
                sql = "update vrach set fam='" + textBox4.Text + "', nam='" + textBox6.Text + "', otch='" + textBox9.Text +
                   "', dat_r='" + dateTimePicker2.Value
                    + "', id_otd=" + kod + ", kab='" + textBox3.Text +
                    "', id_spec=" + kod2 + ", login='" + textBox2.Text + "', password='" + textBox5.Text
                    + "' where id_vrach=" + textBox1.Text;
                if (!Form1.ModificationExecute(sql))
                {
                    return;
                }

                Form1.ds.Tables["Врачи"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox4.Text,
                textBox6.Text, textBox9.Text, dateTimePicker2.Value,  comboBox2.Text, textBox3.Text,
                     comboBox1.Text, textBox2.Text,
                textBox5.Text};
            }

            else
            {
                sql = "insert into vrach(id_vrach, fam, nam, otch, dat_r, id_otd, kab, id_spec, login, password) values(" + textBox1.Text + ",'" + textBox4.Text + "','"
                + textBox6.Text + "','" + textBox9.Text + "','" + dateTimePicker2.Value + "','" + kod
                 + "','" + textBox3.Text + "','" + kod2 + "','" + textBox2.Text + "','" + textBox5.Text + "')";

                if (!Form1.ModificationExecute(sql))
                { return; }

                Form1.ds.Tables["Врачи"].Rows.Add(new object[] { textBox1.Text, textBox4.Text,
                textBox6.Text, textBox9.Text, dateTimePicker2.Value,  comboBox2.Text, textBox3.Text,
                     comboBox1.Text, textBox2.Text,
                textBox5.Text});
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника врача с кодом " + textBox1.Text + "?";
            string caption = "Удаление врача";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }
            Form1.TableFill("Мед. карта", "select * from med");

            for (int i = 0; i < Form1.ds.Tables["Мед. карта"].DefaultView.Count; i++)
                if (Form1.ds.Tables["Мед. карта"].DefaultView[i]["id_med"].ToString() == textBox1.Text)
                {
                    MessageBox.Show("Врач\"" + textBox2.Text + "\" входит в состав информации о карте с кодом " +
                        Form1.ds.Tables["Мед. карта"].DefaultView[i]["id_med"].ToString(), "Ошибка удаления");
                    return;
                }

            string sql = "delete from vrach where id_vrach=" + textBox1.Text;
            Form1.ModificationExecute(sql);

            Form1.ds.Tables["Врачи"].Rows.RemoveAt(n);

            if (Form1.ds.Tables["Врачи"].Rows.Count > n)
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
