using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace registratura
{
    public partial class Med_kard : Form
    {
        public Med_kard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Form1.TableFill("Журнал", "SELECT id_med as \"Код карты\", concat(pac.fam, ' ', pac.nam, ' ', pac.otch) " +
                "as \"ФИО пациента\", concat(vrach.fam, ' ', vrach.nam, ' ', vrach.otch) as \"ФИО врача\", dat_pr as \"Дата приёма\"," +
                " simp as \"Симптомы\", diag as \"Диагноз\", lekar as \"Лекарства\"," +
                " FROM med join vrach on med.id_vrach = vrach.id_vrach join pac on med.id_pac = pac.id_pac order by \"Код карты\"");


            dataGridView1.DataSource = Form1.ds.Tables["Журнал"].DefaultView;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

            this.AcceptButton = button1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application Excel_ = new Excel.Application();
            Excel_.Visible = true;
            Excel.Workbook Workbook_ = Excel_.Workbooks.Add();
            Excel.Worksheet Sheet_ = (Excel.Worksheet)Workbook_.Sheets[1];

            Sheet_.Cells[1, 1].Value = "Учет медицинских карт пациентов";
            Sheet_.Range[Sheet_.Cells[1, 1], Sheet_.Cells[1, 6]].Merge();
            //Sheet_.Cells[1, 1].HorizontalAlignmet = 3;

            Sheet_.Cells[2, 1].Value = dataGridView1.Columns["Код карты"].HeaderText;
            Sheet_.Cells[2, 2].Value = dataGridView1.Columns["ФИО пациента"].HeaderText;
            Sheet_.Cells[2, 3].Value = dataGridView1.Columns["ФИО врача"].HeaderText;
            Sheet_.Cells[2, 4].Value = dataGridView1.Columns["Дата приёма"].HeaderText;
            Sheet_.Cells[2, 5].Value = dataGridView1.Columns["Симптомы"].HeaderText;
            Sheet_.Cells[2, 6].Value = dataGridView1.Columns["Диагноз"].HeaderText;
            Sheet_.Cells[2, 7].Value = dataGridView1.Columns["Лекарства"].HeaderText;

            //  Sheet_.Range[Sheet_.Cells[2, 1], Sheet_.Cells[2, 6]].HorizontalAlignmet = 3;
            int n = 3;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Sheet_.Cells[n, 1].Value = dataGridView1.Rows[i].Cells["Код карты"].Value;
                Sheet_.Cells[n, 2].Value = dataGridView1.Rows[i].Cells["ФИО пациента"].Value;
                Sheet_.Cells[n, 3].Value = dataGridView1.Rows[i].Cells["ФИО врача"].Value;
                Sheet_.Cells[n, 4].Value = dataGridView1.Rows[i].Cells["Дата приёма"].Value;
                Sheet_.Cells[n, 5].Value = dataGridView1.Rows[i].Cells["Симптомы"].Value;
                Sheet_.Cells[n, 6].Value = dataGridView1.Rows[i].Cells["Диагноз"].Value;
                Sheet_.Cells[n, 7].Value = dataGridView1.Rows[i].Cells["Лекарства"].Value;
                n++;
            }
            Sheet_.Cells.Columns.EntireColumn.AutoFit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kod;
            try
            {
                kod = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код карты"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не указан удаляемый экземпляр!", "Ошибка"); return;
            }

            string message = "Вы точно хотите удалить карту под номером" + kod + "?";
            string caption = "Удаление карты";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                return;
            }

            string sql = "Delete from med where id_med=" + kod;
            Form1.ModificationExecute(sql);

            for (int i = Form1.ds.Tables["Журнал"].Rows.Count - 1; i >= 0; i--)
            {
                if (Form1.ds.Tables["Журнал"].Rows[i]["Код карты"].ToString() == kod)
                {
                    Form1.ds.Tables["Журнал"].Rows.RemoveAt(i);
                    dataGridView1.CurrentCell = null;
                    return;
                }
            }   }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить информацию обо всех картах?";
            string caption = "Очистка журнала";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                return;
            }
            string sql = "Delete from med";
            Form1.ModificationExecute(sql);
            Form1.ds.Tables["Журнал"].Clear();
        }

    
    }
}
