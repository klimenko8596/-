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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pas form = new Pas();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }



        private void врачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vrach form = new Vrach();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

        private void специализацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spec form = new Spec();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }


        private void учётМедицинскихКартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Med_kard form = new Med_kard();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

        private void учётПриёмовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ychet_priem form = new Ychet_priem();
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

        private void отделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Otdel form = new Otdel();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

        private void приёмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priem form = new Priem();
            Form1.tabControl1.Controls.Add(form.tabControl1.TabPages[0]);
            Form1.tabControl1.SelectedIndex = Form1.tabControl1.TabCount - 1;
        }

     
    }
}
