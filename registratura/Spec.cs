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
    public partial class Spec : Form
    {
        public Spec()
        {
            InitializeComponent();
        }
        public static int n = 0;
        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Специализация"].Rows[n]["id_spec"].ToString();
            textBox2.Text = Form1.ds.Tables["Специализация"].Rows[n]["nazv"].ToString();
            textBox3.Text = Form1.ds.Tables["Специализация"].Rows[n]["opis"].ToString();
           
        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (Form1.ds.Tables["Специализация"].Rows.Count > n)
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
            if (n < Form1.ds.Tables["Специализация"].Rows.Count) n++;
            if (Form1.ds.Tables["Специализация"].Rows.Count > n)
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
            n = Form1.ds.Tables["Специализация"].Rows.Count + 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if (n < Form1.ds.Tables["Специализация"].Rows.Count)
            {
                sql = "update spec set nazv='" + textBox2.Text + "', opis='" + textBox3.Text +  "' where id_spec=" + textBox1.Text;
                if (!Form1.ModificationExecute(sql))
                {
                    return;
                }

                Form1.ds.Tables["Специализация"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text};
            }

            else
            {
                sql = "insert into spec(id_spec, nazv, opis) values(" + textBox1.Text + ",'" + textBox2.Text + "','"+ textBox3.Text + "')";

                if (!Form1.ModificationExecute(sql))
                { return; }

                Form1.ds.Tables["Специализация"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text});
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string message = "Вы точно хотите удалить из справочника специальность с кодом " + textBox1.Text + "?";
            string caption = "Удаление специальности";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }
            Form1.TableFill("Врачи", "select * from vrach");

            for (int i = 0; i < Form1.ds.Tables["Врачи"].DefaultView.Count; i++)
                if (Form1.ds.Tables["Врачи"].DefaultView[i]["id_spec"].ToString() == textBox1.Text)
                {
                    MessageBox.Show("Специальность\"" + textBox2.Text + "\" входит в состав информации о враче с кодом " +
                        Form1.ds.Tables["Врачи"].DefaultView[i]["id_vrach"].ToString(), "Ошибка удаления");
                    return;
                }

            string sql = "delete from spec where id_spec=" + textBox1.Text;
            Form1.ModificationExecute(sql);

            Form1.ds.Tables["Специализация"].Rows.RemoveAt(n);

            if (Form1.ds.Tables["Специализация"].Rows.Count > n)
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
