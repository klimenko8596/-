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
    public partial class poisk_p_pas : Form
    {
        public poisk_p_pas()
        {
            InitializeComponent();
        }
        public static string n = null;
      
     


        private void tabPage1_Enter(object sender, EventArgs e)
        {
            int i = 0;
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

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(n);
            string sql = "update pac set fam='" + textBox2.Text +
                    "', nam='" + textBox6.Text +
                    "', otch='" + textBox9.Text +
                    "', pol='" + textBox3.Text +
                    "', dat_r='" + dateTimePicker1.Value +
                    "', polic='" + textBox4.Text +
                    "', snils='" + textBox7.Text +
                    "', ser_nom='" + textBox8.Text +
                    "', obl='" + textBox5.Text +
                    "', reg='" + textBox10.Text +
                    "', gorod='" + textBox11.Text +
                    "', yl='" + textBox12.Text +
                    "', dom='" + textBox13.Text +
                    "', kvar='" + textBox14.Text +
                    "' where id_pac=" + textBox1.Text + "";
                Form1.ModificationExecute(sql);

            Form1.ds.Tables["Пациенты"].Rows[v].ItemArray = new object[] {
                    textBox1.Text,
                    textBox2.Text,
                    textBox6.Text,
                    textBox9.Text,
                    textBox3.Text,
                    dateTimePicker1.Value,
                    textBox4.Text,
                    textBox7.Text,
                    textBox8.Text,
                    textBox5.Text,
                    textBox10.Text,
                    textBox11.Text,
                    textBox12.Text,
                    textBox13.Text,
                    textBox14.Text};
        }

            private void button6_Click(object sender, EventArgs e)
        {
           

            string message = "Вы точно хотите удалить из справочника пациента с кодом " + textBox1.Text + "?";
            string caption = "Удаление пациента";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }
            Form1.TableFill("Мед. карта", "select * from med");

            for (int i = 0; i < Form1.ds.Tables["Мед. карта"].DefaultView.Count; i++)
                if (Form1.ds.Tables["Мед. карта"].DefaultView[i]["id_med"].ToString() == textBox1.Text)
                {
                    MessageBox.Show("Пациент\"" + textBox2.Text + "\" входит в состав информации о карте с кодом " +
                        Form1.ds.Tables["Мед. карта"].DefaultView[i]["id_med"].ToString(), "Ошибка удаления");
                    return;
                }

            string sql = "delete from pac where id_pac=" + textBox1.Text;
            Form1.ModificationExecute(sql);

          

            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }
    }
}
