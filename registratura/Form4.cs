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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void приёмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priem form = new Priem();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pas_v form = new Pas_v();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (Form1.tabControl1.TabCount > 0)
                Form1.tabControl1.TabPages.RemoveAt(Form1.tabControl1.TabCount - 1);
            Form2 form2 = new Form2();
            Form1.tabControl1.Controls.Add(form2.tabControl1.TabPages[0]);
        }
    }
}
