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
    public partial class poisk_vrach : Form
    {
        public poisk_vrach()
        {
            InitializeComponent();
        }

      
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Form1.ds.Tables["Журнал1"].DefaultView.RowFilter = "ФИО like'%" + textBox1.Text + "%'";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);

            Vrach.n = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код врача"].Value.ToString());
            Vrach vrach = new Vrach();

            if (Form1.tabControl1.TabCount > 2)
            {

                Form1.tabControl1.TabPages.RemoveAt(Form1.tabControl1.TabCount - 1);
            }

            Form1.tabControl1.Controls.Add(vrach.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Form1.TableFill("Журнал1", "SELECT id_vrach as \"Код врача\", concat(vrach.fam, ' ', vrach.nam, ' ', vrach.otch) " +
               "as \"ФИО\", dat_r as \"Дата рождения\"," +
               " otd.nazv as \"Отделение\", spec.nazv as \"Специальность\"" +
               " FROM vrach join spec on vrach.id_spec = spec.id_spec join otd on vrach.id_otd = otd.id_otd order by \"Код врача\"");

            dataGridView1.DataSource = Form1.ds.Tables["Журнал1"].DefaultView;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

            this.AcceptButton = button7;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }
    }
}
