using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace registratura
{
    public partial class poick_p : Form
    {
        public poick_p()
        {
            InitializeComponent();
        }
     
        private void tabPage1_Enter(object sender, EventArgs e)
        {

            Form1.TableFill("Журнал", "SELECT id_pac as \"Код карты\", concat(pac.fam, ' ', pac.nam, ' ', pac.otch) " +
               "as \"ФИО\", dat_r as \"Дата рождения\"," +
               " pol as \"Пол\", polic as \"Полюс\", snils as \"Снилс\", ser_nom as \"Серия и номер\"" +
               " FROM pac order by \"Код карты\"");

            dataGridView1.DataSource = Form1.ds.Tables["Журнал"].DefaultView;
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Form1.ds.Tables["Журнал"].DefaultView.RowFilter = "ФИО like'%" + textBox1.Text + "%'";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);

            Pas.n = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код карты"].Value.ToString());
            Pas pas = new Pas();

            if (Form1.tabControl1.TabCount > 2)
            {

                Form1.tabControl1.TabPages.RemoveAt(Form1.tabControl1.TabCount - 1);
            }

            Form1.tabControl1.Controls.Add(pas.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }
    }
}
